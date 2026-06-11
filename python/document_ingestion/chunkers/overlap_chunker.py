from models.chunk import Chunk


class OverlapChunker:

    def __init__(
        self,
        chunk_size=200,
        overlap=50
    ):
        self.chunk_size = chunk_size
        self.overlap = overlap

    def chunk_document(self, document):

        words = document.extracted_text.split()

        chunks = []

        start = 0
        index = 0

        while start < len(words):

            end = start + self.chunk_size

            chunk_words = words[start:end]

            chunks.append(
                Chunk(
                    chunk_id=f"chunk_{index}",
                    chunk_index=index,
                    text=" ".join(chunk_words),
                    source_file=document.file_name
                )
            )

            start += (
                self.chunk_size -
                self.overlap
            )

            index += 1

        return chunks