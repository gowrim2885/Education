from dataclasses import dataclass, field, asdict
from typing import List, Dict, Any
import uuid


# --------------------------------------------------
# BASE ASSET
# --------------------------------------------------

@dataclass
class Asset:
    asset_id: str
    asset_type: str
    metadata: Dict[str, Any] = field(default_factory=dict)


# --------------------------------------------------
# TEXT ASSET
# --------------------------------------------------

@dataclass
class TextAsset(Asset):
    text: str = ""
    page_number: int = None


# --------------------------------------------------
# TABLE ASSET
# --------------------------------------------------

@dataclass
class TableAsset(Asset):
    rows: List[List[str]] = field(default_factory=list)
    page_number: int = None


# --------------------------------------------------
# IMAGE ASSET
# --------------------------------------------------

@dataclass
class ImageAsset(Asset):
    image_path: str = ""
    page_number: int = None
    ocr_text: str = ""


# --------------------------------------------------
# PAGE
# --------------------------------------------------

@dataclass
class Page:
    page_number: int
    assets: List[Asset] = field(default_factory=list)


# --------------------------------------------------
# DOCUMENT
# --------------------------------------------------

@dataclass
class DocumentSchema:

    document_id: str
    file_name: str
    file_type: str

    metadata: Dict[str, Any] = field(default_factory=dict)

    pages: List[Page] = field(default_factory=list)

    extracted_text: str = ""

    def to_dict(self):
        return asdict(self)

    @staticmethod
    def create(file_name, file_type):

        return DocumentSchema(
            document_id=str(uuid.uuid4()),
            file_name=file_name,
            file_type=file_type
        )
    
@dataclass
class LinkAsset(Asset):
    uri: str = ""
    text: str = ""
    page_number: int = None
    bbox: list = field(default_factory=list)