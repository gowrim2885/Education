from models.chunk import Chunk

class FixedChunker:

    def __init__(self, chunk_size=1000):
        self.chunk_size = chunk_size

    def chunk(self, document):
        words = document.text.split()
        chunks = []

        for index, start in enumerate(range(0, len(words), self.chunk_size)):
            chunk_words = words[start:start + self.chunk_size]
            chunk_text = ' '.join(chunk_words)

            chunk = Chunk(
                chunk_id=f"chunk_{index}",
                chunk_index=index,
                text=chunk_text,
                source_file=document.file_name
            )
            chunks.append(chunk)

        return chunks
    
