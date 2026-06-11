from dataclasses import dataclass

@dataclass
class Chunk:
    chunk_id: str
    chunk_index: int
    text: str
    source_file: str


