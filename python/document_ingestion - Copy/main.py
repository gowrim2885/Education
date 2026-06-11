import json
import os

# Import all extractors
from utils.file_utils import get_extension
from chunkers.chunk_service import ChunkService
from extractors.pdf_extractor import PDFExtractor
from extractors.docx_extractor import DOCXExtractor
from extractors.txt_extractor import TXTExtractor
from extractors.pptx_extractor import PPTXExtractor
from extractors.img_extractor import ImageExtractor


def get_extractor(file_path):
    # Clean input path
    file_path = file_path.strip().strip('"').strip("'")

    ext = get_extension(file_path)
    
    print(f"Detected extension: [{ext}]")  # Debug line

    if ext == ".pdf":
        return PDFExtractor()
    elif ext in [".doc", ".docx"]:
        return DOCXExtractor()
    elif ext == ".txt":
        return TXTExtractor()
    elif ext == ".pptx":
        return PPTXExtractor()
    elif ext in [".jpg", ".jpeg", ".png", ".bmp", ".tiff"]:
        from extractors.img_extractor import ImageExtractor
        return ImageExtractor()
    else:
        raise ValueError(f"Unsupported file type: {ext}")


def main(file_path):
    try:
        extractor = get_extractor(file_path)

        # Run extraction
        document = extractor.extract(file_path)

        #chunking
        chunk_service = ChunkService(mode="fixed")
        chunks = chunk_service.process(document)
        #create chunk output file and open
        chunk_output_file = (
            os.path.splitext(file_path)[0]
            + "_chunks.txt"
        )
        with open(
            chunk_output_file,
            "w",
            encoding="utf-8"
        ) as f:

            for chunk in chunks:

                f.write(
                    f"========== CHUNK "
                    f"{chunk.chunk_index} ==========\n"
                )
                f.write(chunk.text)
                f.write("\n\n")

        print(f"Generated {len(chunks)} chunks.")

        # for chunk in chunks[:3]:
        #     print(chunk.text)

        # Create output text extraction file name
        output_file = os.path.splitext(file_path)[0] + "_output.json"

        # Save JSON
        with open(output_file, "w", encoding="utf-8") as f:
            json.dump(
                document.to_dict(),
                f,
                indent=4,
                ensure_ascii=False
            )

        print(f"Extraction complete: {output_file}")



    except Exception as e:
        print(f"Error: {e}")


if __name__ == "__main__":
    input_file = input("Enter your file Path: ").strip()
    main(input_file)
