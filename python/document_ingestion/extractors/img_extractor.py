import os
import uuid
from PIL import Image

from models.document_schema import (
    DocumentSchema,
    Page,
    ImageAsset,
    TextAsset
)

from storage.asset_manager import AssetManager
from utils.ocr_utils import perform_ocr
from utils.metadata_utils import extract_basic_metadata


class ImageExtractor:

    def extract(self, file_path):

        document = DocumentSchema.create(
            file_name=os.path.basename(file_path),
            file_type="image"
        )

        document.metadata.update(
            extract_basic_metadata(file_path)
        )

        page = Page(page_number=1)

        # -------------------------
        # LOAD IMAGE
        # -------------------------
        image = Image.open(file_path)

        width, height = image.size

        # -------------------------
        # SAVE NORMALIZED COPY
        # -------------------------
        saved_path = AssetManager.save_binary(
            open(file_path, "rb").read(),
            extension=".png"
        )

        # -------------------------
        # OCR EXTRACTION
        # -------------------------
        ocr_text = perform_ocr(saved_path)

        # -------------------------
        # IMAGE ASSET
        # -------------------------
        image_asset = ImageAsset(
            asset_id="img_1",
            asset_type="image",
            image_path=saved_path,
            metadata={
                "width": width,
                "height": height,
                "source": "direct_image",
                "ocr_confidence": "unknown"
            },
            ocr_text=ocr_text
        )

        page.assets.append(image_asset)

        # -------------------------
        # OCR AS TEXT ASSET (FOR RAG)
        # -------------------------
        if ocr_text.strip():

            text_asset = TextAsset(
                asset_id="img_ocr_1",
                asset_type="image_ocr_text",
                text=ocr_text,
                metadata={
                    "source": "image_ocr"
                }
            )

            page.assets.append(text_asset)

        # -------------------------
        # FINALIZE DOCUMENT
        # -------------------------
        document.pages.append(page)

        document.extracted_text = ocr_text

        return document