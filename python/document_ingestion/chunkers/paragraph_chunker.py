from models.chunk import Chunk

class ParagraphChunker:

    def __init__(self, paragraph_per_chunk):
        self.paragraph_per_chunk = paragraph_per_chunk

    def chunk_document(self, document):

        text = document.extracted_text
        paragraphs = [ p.strip() for p in text.split('\n\n') if p.strip() ]
        chunks = []
        for index, start in enumerate(range(0, len(paragraphs), self.paragraph_per_chunk)):
            chunk_paragraphs = paragraphs[start:start + self.paragraph_per_chunk]
            chunk_text = '\n\n'.join(chunk_paragraphs)

            chunk = Chunk(
                chunk_id=f"chunk_{index}",
                chunk_index=index,
                text=chunk_text,
                source_file=document.file_name
            )
            chunks.append(chunk)

        return chunks