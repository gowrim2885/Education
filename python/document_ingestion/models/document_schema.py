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

    bbox: list = field(default_factory=list)#Bounding box [left, top, right, bottom]

    font_name: str = ""
    font_size: float = 0

    is_bold: bool = False
    is_italic: bool = False

    heading_level: int = 0

    block_number: int = -1
    line_number: int = -1
    span_number: int = -1


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


@dataclass
class AnnotationAsset(Asset):
    annotation_type: str = ""
    content: str = ""
    page_number: int = None

@dataclass
class AttachmentAsset(Asset):
    filename: str = ""
    filepath: str = ""