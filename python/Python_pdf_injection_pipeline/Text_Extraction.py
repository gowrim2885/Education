import os
import io
import fitz
from PIL import Image
import pytesseract
from pytesseract import Output
import pdfplumber

# Configure Tesseract path here if needed
pytesseract.pytesseract.tesseract_cmd = r'C:\Program Files\Tesseract-OCR\tesseract.exe'

#Gets the file extension
def detect_file_type(filename):
    return os.path.splitext(filename)[1].lower()

#Checks if OCR (Tesseract) is installed 
def is_tesseract_available():
    try:
        pytesseract.get_tesseract_version()
        return True
    except Exception as e:
        print(f"Warning: Tesseract is not available: {e}")
        return False

#Converts extracted tables into Markdown format
def format_table_markdown(table):
    if not table:
        return ""

    header = table[0]
    rows = table[1:] if len(table) > 1 else []

    if not any(header):
        header = [f"Col {i + 1}" for i in range(len(table[0]))]

    header_line = "| " + " | ".join(cell if cell is not None else "" for cell in header) + " |"
    separator_line = "| " + " | ".join("---" for _ in header) + " |"
    body_lines = ["| " + " | ".join(cell if cell is not None else "" for cell in row) + " |" for row in rows]

    return "\n".join([header_line, separator_line] + body_lines)

#Extracts an image from a PDF page
def ocr_image_from_page(page, xref):
    pix = fitz.Pixmap(page.parent, xref)
    if pix.n > 4:
        pix = fitz.Pixmap(fitz.csRGB, pix)
    image_bytes = pix.tobytes("png")
    return Image.open(io.BytesIO(image_bytes))

#Detect tables via OCR
def ocr_table_from_image(img, y_threshold=15):
    data = pytesseract.image_to_data(img, output_type=Output.DICT)
    words = []
    for i in range(len(data["text"])):
        text = data["text"][i].strip()
        try:
            conf = int(data["conf"][i])
        except ValueError:
            conf = -1
        if text and conf >= 30:
            words.append({
                "text": text,
                "left": data["left"][i],
                "top": data["top"][i],
            })

    if not words:
        return ""

    words.sort(key=lambda item: (item["top"], item["left"]))
    rows = []
    current_row = [words[0]]
    for word in words[1:]:
        if abs(word["top"] - current_row[0]["top"]) <= y_threshold:
            current_row.append(word)
        else:
            rows.append(current_row)
            current_row = [word]
    rows.append(current_row)

    table_lines = []
    for row in rows:
        row.sort(key=lambda item: item["left"])
        table_lines.append(" | ".join(item["text"] for item in row))

    if len(table_lines) < 2:
        return ""

    header_line = f"| {table_lines[0]} |"
    separator_line = "| " + " | ".join("---" for _ in table_lines[0].split(" | ")) + " |"
    body_lines = [f"| {line} |" for line in table_lines[1:]]
    return "\n".join([header_line, separator_line] + body_lines)


def extract_text(filename):
    ext = detect_file_type(filename)
    if ext != ".pdf":
        raise ValueError("Only PDF files are supported by this script.")

    text = []
    tesseract_available = is_tesseract_available()

    with fitz.open(filename) as doc, pdfplumber.open(filename) as pdf:
        for page_num, page in enumerate(doc, start=1):
            text.append(f"--- Page {page_num} ---")

            page_text = page.get_text("text").strip()
            if page_text:
                text.append(page_text)

            pdf_page = pdf.pages[page_num - 1]
            pdf_tables = pdf_page.extract_tables()
            for table_index, table in enumerate(pdf_tables, start=1):
                markdown = format_table_markdown(table)
                if markdown:
                    text.append(f"--- Table {table_index} (PDF text table) ---")
                    text.append(markdown)

            image_list = page.get_images(full=True)
            if image_list and tesseract_available:
                for image_index, img in enumerate(image_list, start=1):
                    xref = img[0]
                    image = ocr_image_from_page(page, xref)
                    table_markdown = ocr_table_from_image(image)
                    if table_markdown:
                        text.append(f"--- Image {image_index} Table OCR ---")
                        text.append(table_markdown)
                    else:
                        image_text = pytesseract.image_to_string(image).strip()
                        if image_text:
                            text.append(f"--- Image {image_index} OCR ---")
                            text.append(image_text)

            if not page_text and not pdf_tables and (not image_list or not tesseract_available):
                if tesseract_available:
                    try:
                        pix = page.get_pixmap()
                        image = Image.open(io.BytesIO(pix.tobytes("png")))
                        fallback_text = pytesseract.image_to_string(image).strip()
                        if fallback_text:
                            text.append("[Full page OCR]")
                            text.append(fallback_text)
                        else:
                            text.append("[No extractable text found on this page]")
                    except Exception as e:
                        text.append(f"[Could not extract text from page {page_num}: {e}]")
                else:
                    text.append("[No extractable text found and Tesseract is unavailable]")

            text.append("")

    return "\n".join(text)


if __name__ == "__main__":
    file = "Sample.pdf"
    result = extract_text(file)
    print(result)

    with open("extracted_text.txt", "w", encoding="utf-8") as f:
        f.write(result)
    print("Text extraction complete. Output saved to extracted_text.txt")