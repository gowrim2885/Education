from models.chunk import Chunk
import re

class RecursiveChunker:
    def __init__(self,chunk_size=200,overlap=50):
        self.chunk_size = chunk_size
        self.overlap = overlap

    def chunk_document(self, document):
        final_chunks = []
        chunk_index = 0
        current_heading = ""
        for page in document.pages:
            for asset in page.assets:
                if asset.asset_type == "text":
                    if getattr(asset, "heading_level", 0) >0:
                        current_heading = asset.text
                        continue
                    content = asset.text
                    if current_heading:
                        content = (current_heading + "\n\n" + content)
                    asset_chunks = self._recursive_split(self._clean_text(asset.text), ["\n\n", ". ", " "])
                elif asset.asset_type == "table":
                    asset_chunks = self._recursive_split(self._clean_text(self._table_to_text(asset)),["\n\n", ". ", " "])
                elif asset.asset_type == "image":
                    if not self._is_valid_ocr(asset.ocr_text):
                        continue
                    asset_chunks = self._recursive_split(self._clean_text(asset.ocr_text), ["\n\n", ". ", " "])
                else:
                    continue
                for chunk_text in asset_chunks:
                    final_chunks.append(
                        Chunk(
                            chunk_id=f"chunk_{chunk_index}",
                            chunk_index=chunk_index,
                            text=chunk_text,
                            source_file=document.file_name,
                            asset_type=asset.asset_type,
                            page_number=page.page_number))
                    chunk_index += 1

        return final_chunks
    
    def _table_to_text(self, table_asset):

        if not table_asset.rows:
            return ""

        headers = table_asset.rows[0]
        output = []
        for row in table_asset.rows[1:]:
            values = []
            for i in range(len(headers)):
                if i < len(row):
                    values.append(f"{headers[i]}: {row[i]}")
            output.append(", ".join(values))
        return "\n".join(output)


    def _recursive_split(self,text,separators):

        words = text.split()

        # Base case
        if len(words) <= self.chunk_size:
            return [text]

        # No more separators available
        if not separators:
            return self._fixed_overlap_split(text)

        separator = separators[0]

        pieces = text.split(separator)

        current_chunk = ""
        chunks = []

        for piece in pieces:

            candidate = (
                piece
                if not current_chunk
                else current_chunk + separator + piece
            )

            if len(candidate.split()) <= self.chunk_size:
                current_chunk = candidate
            else:

                if current_chunk:
                    chunks.append(current_chunk)

                if len(piece.split()) > self.chunk_size:
                    chunks.extend(
                        self._recursive_split(
                            piece,
                            separators[1:]
                        )
                    )
                    current_chunk = ""
                else:
                    current_chunk = piece

        if current_chunk:
            chunks.append(current_chunk)

        return self._apply_overlap(chunks)

    def _apply_overlap(self, chunks):

        if self.overlap <= 0:
            return chunks

        overlapped_chunks = []

        for i, chunk in enumerate(chunks):

            if i == 0:
                overlapped_chunks.append(chunk)
                continue

            previous_words = chunks[i - 1].split()

            overlap_words = previous_words[-self.overlap:]

            current_words = chunk.split()

            merged = (
                overlap_words +
                current_words
            )

            overlapped_chunks.append(" ".join(merged))

        return overlapped_chunks

    def _fixed_overlap_split(self, text):
        words = text.split()
        chunks = []
        start = 0
        while start < len(words):
            end = start + self.chunk_size
            chunk_words = words[start:end]
            chunks.append(" ".join(chunk_words))
            start += ( self.chunk_size - self.overlap )

        return chunks
    

    def _clean_text(self, text):
        return re.sub(r'\s+', ' ', text).strip()
    
    def _is_valid_ocr(self, text):
        if not text:
            return False

        if len(text.split()) < 10:
            return False

        return True