import os
import re

from models.document_schema import (
    DocumentSchema,
    Page,
    TextAsset
)

from utils.metadata_utils import extract_basic_metadata
from utils.text_cleaner import TextCleaner
from utils.structure_detector import StructureDetector

class TXTExtractor:

    def extract(self, file_path):

        document = DocumentSchema.create(
            file_name=os.path.basename(file_path),
            file_type="txt"
        )

        document.metadata.update(
            extract_basic_metadata(file_path)
        )

        page = Page(page_number=1)

        with open(file_path, "r", encoding="utf-8", errors="ignore") as f:
            raw_text = f.read()

        # -------------------------
        # CLEAN TEXT
        # -------------------------
        cleaned_text = self.clean_text(raw_text)

        # -------------------------
        # SPLIT INTO PARAGRAPHS
        # -------------------------
        paragraphs = self.split_paragraphs(cleaned_text)

        full_text = []

        for idx, para in enumerate(paragraphs):

            para = para.strip()

            if not para:
                continue

            heading_level = self.detect_heading(para)

            asset = TextAsset(
                asset_id=f"txt_{idx}",
                asset_type="text",
                text=para,
                page_number=1,
                heading_level=heading_level,
                metadata={
                    "source": "txt_file"
                }
            )

            page.assets.append(asset)
            full_text.append(para)

        document.pages.append(page)

        raw_text = "/n".join(full_text)
        document.extracted_text = TextCleaner.clean(raw_text)
        document.metadata["headings"] = (StructureDetector.detect_headings(document.extracted_text))
        
        return document

    # -------------------------
    # CLEAN TEXT
    # -------------------------
    def clean_text(self, text):

        text = text.replace("\r\n", "\n")
        text = text.replace("\r", "\n")

        text = re.sub(r"\n{3,}", "\n\n", text)

        text = re.sub(r"[ \t]+", " ", text)

        text = re.sub(r"\u200b", "", text)  # zero-width space

        return text.strip()

    # -------------------------
    # PARAGRAPH SPLIT
    # -------------------------
    def split_paragraphs(self, text):

        return text.split("\n\n")

    # -------------------------
    # HEADING DETECTION (HEURISTIC)
    # -------------------------
    def detect_heading(self, text):

        text_stripped = text.strip()

        # ALL CAPS SHORT LINE
        if (
            len(text_stripped) < 80 and
            text_stripped.isupper()
        ):
            return 1

        # NUMBERED HEADING (1. / 1.1 / 2.3.1)
        if re.match(r"^\d+(\.\d+)*\s", text_stripped):
            return 2

        # SHORT LINE heuristic
        if len(text_stripped) < 50:
            return 3

        return 0