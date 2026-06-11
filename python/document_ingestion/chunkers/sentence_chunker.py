from models.chunk import Chunk
import re

class SentenceChunker:

    def __init__(self, sentence_per_chunk =5):
        self.sentence_per_chunk = sentence_per_chunk

    def chunk_document(self, document):

        text = document.extracted_text
        sentences = re.split(r'(?<=[.!?]) +', text)
        chunks = []
        for index, start in enumerate(range(0, len(sentences), self.sentence_per_chunk)):
            chunk_sentences = sentences[start:start + self.sentence_per_chunk]
            chunk_text = ' '.join(chunk_sentences)

            chunk = Chunk(
                chunk_id=f"chunk_{index}",
                chunk_index=index,
                text=chunk_text,
                source_file=document.file_name
            )
            chunks.append(chunk)

        return chunks
