import io
import os
import fitz
import pdfplumber

from PIL import Image
from models.document_schema import (
    DocumentSchema,
    Page,
    TextAsset,
    TableAsset,
    ImageAsset
)

from storage.asset_manager import AssetManager
from utils.metadata_utils import extract_basic_metadata
from utils.ocr_utils import perform_ocr
from utils.text_cleaner import TextCleaner
from utils.structure_detector import StructureDetector

class PDFExtractor:

    def __init__(self):
        pass

    def extract(self, pdf_path):
        document = DocumentSchema.create(
            file_name=os.path.basename(pdf_path),
            file_type="pdf"
        )

        document.metadata.update(extract_basic_metadata(pdf_path))

        full_text = []

        with fitz.open(pdf_path) as pdf_doc:
            with pdfplumber.open(pdf_path) as plumber_doc:
                for page_index in range(len(pdf_doc)):
                    page_number = page_index + 1
                    pdf_page = pdf_doc[page_index]
                    plumber_page = plumber_doc.pages[page_index]
                    page_obj = Page( page_number=page_number)

                    # ------------------------
                    # TEXT EXTRACTION
                    # ------------------------

                    text_assets = self.extract_text(pdf_page, page_number)
                    page_obj.assets.extend(text_assets)
                    for asset in text_assets:
                        full_text.append(asset.text)

                    # ------------------------
                    # TABLE EXTRACTION
                    # ------------------------

                    tables = self.extract_tables(plumber_page,page_number)

                    page_obj.assets.extend(tables)

                    # ------------------------
                    # IMAGE EXTRACTION
                    # ------------------------

                    images = self.extract_images(pdf_doc,pdf_page,page_number)
                    page_obj.assets.extend(images)

                    # ------------------------
                    # PAGE OCR FALLBACK
                    # ------------------------
                    page_has_text =  len(text_assets) > 0
                    if not page_has_text:
                        ocr_asset = (self.perform_page_ocr(pdf_page,page_number))
                        if ocr_asset:
                            page_obj.assets.append(ocr_asset)
                            full_text.append(ocr_asset.text)
                    document.pages.append(page_obj)

        raw_text = "\n".join(full_text)
        document.extracted_text = TextCleaner.clean(raw_text)
        document.metadata["headings"] = (StructureDetector.detect_headings(document.extracted_text))
        
        return document

    # ------------------------------------
    # TEXT EXTRACTION
    # ------------------------------------

    def extract_text(self, page, page_number):
        blocks = page.get_text("dict")
        assets = []
        block_index = 0
        for block in blocks["blocks"]:
            if "lines" not in block:
                continue

            for line in block["lines"]:
                line_text = ""
                font_size = 0
                for span in line["spans"]:
                    line_text += span["text"]
                    font_size = max(font_size,span["size"])

                line_text = line_text.strip()
                if not line_text:
                    continue
                heading_level = 0
                if (font_size >= 18):
                    heading_level = 1
                elif (font_size >= 16):
                    heading_level = 2
                elif (font_size >= 14):
                    heading_level = 3
                assets.append(
                    TextAsset(
                        asset_id=f"text_{page_number}_{block_index}",
                        asset_type="text",
                        text=line_text,
                        page_number=page_number,
                        heading_level=heading_level,
                        font_size=font_size,
                        metadata={"source": "pdf_text"}
                    ))

                block_index += 1
        return assets

    # ------------------------------------
    # TABLE EXTRACTION
    # ------------------------------------

    def extract_tables(self,plumber_page,page_number):
        assets = []
        try:
            tables = (plumber_page.extract_tables())
            for idx, table in enumerate(tables):
                assets.append(TableAsset(asset_id=(f"table_"f"{page_number}_"f"{idx}"),
                        asset_type="table",
                        rows=table,
                        page_number=page_number,
                        metadata={
                            "source":
                            "pdf_table"
                        }))
        except Exception as ex:
            print(f"Table Extraction Error:"f" {ex}")
        return assets

    # ------------------------------------
    # IMAGE EXTRACTION
    # ------------------------------------

    def extract_images(self,pdf_doc,page,page_number):
        image_assets = []
        images = page.get_images(full=True)
        for idx, img in enumerate(images):
            try:
                xref = img[0]
                base_image = (pdf_doc.extract_image(xref))
                image_bytes = (base_image["image"])
                extension = ("."+ base_image.get("ext","png"))
                image_path = (AssetManager.save_binary(image_bytes,extension))

                ocr_text = TextCleaner.clean(perform_ocr(image_path))
                if len(ocr_text.split()) < 5:
                    continue
                image_asset = ( ImageAsset(  asset_id=( f"image_"  f"{page_number}_" f"{idx}" ),
                        asset_type="image",
                        image_path=image_path,
                        page_number=page_number,
                        ocr_text=ocr_text,
                        metadata={
                            "xref":
                            xref
                        }
                    )
                )

                image_assets.append(image_asset)  

            except Exception as ex:

                print(f"Image Error: {ex}")

        return image_assets

    # ------------------------------------
    # FULL PAGE OCR
    # ------------------------------------

    def perform_page_ocr(  self, page, page_number):
        try:

            pix = page.get_pixmap( matrix=fitz.Matrix(2,2))
            image_bytes = pix.tobytes("png")
            image_path = (AssetManager.save_binary(image_bytes,".png"))
            ocr_text = TextCleaner.clean(perform_ocr(image_path))

            if not ocr_text:
                return None

            return TextAsset(
                asset_id=(f"ocr_{page_number}"),
                asset_type="ocr_text",
                text=ocr_text,
                page_number=page_number,
                metadata={"source":"page_ocr"
                }
            )

        except Exception as ex:
            print(f"OCR Error: {ex}")
            return None