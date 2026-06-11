from dataclasses import dataclass

@dataclass
class Chunk:
    chunk_id: str
    chunk_index: int
    text: str
    source_file: str
    asset_type: str = ""
    page_number: int = 0
    heading: str = ""


