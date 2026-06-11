from chunkers.overlap_chunker import OverlapChunker
from chunkers.fixed_chunker import FixedChunker
from chunkers.paragraph_chunker import ParagraphChunker
from chunkers.sentence_chunker import SentenceChunker
from chunkers.recursive_chunker import RecursiveChunker

class ChunkService:
    def __init__(self, mode="overlap"):
        if mode == "fixed":
            self.chunker = FixedChunker(chunk_size=100)
        elif mode == "paragraph":
            self.chunker = ParagraphChunker(paragraph_per_chunk=5)
        elif mode == "sentence":
            self.chunker = SentenceChunker()
        elif mode == "overlap":
            self.chunker = OverlapChunker(chunk_size=100,overlap=50)
        elif mode == "recursive":
            self.chunker = RecursiveChunker(chunk_size=500,overlap=50)
        else:
            raise ValueError("Invalid chunking mode")

    def process(self, document):
        return self.chunker.chunk_document(document)
    
    