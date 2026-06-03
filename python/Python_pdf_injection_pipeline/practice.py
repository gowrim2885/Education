import os
import fitz
import pdfplumber
from docx import Document
from pptx import Presentation
import pandas as pd
import pytesseract
from PIL import Image

def detect_file_type(filename):
    ext = os.path.splitext(filename)[1].lower()
    return ext


def extract_text(filename):
    ext = detect_file_type(filename)

    if ext == ".pdf":
        # Try text-based extraction first
        text = ""
        with fitz.open(filename) as doc:
            for page in doc:
                text += page.get_text("text") + "\n"
        return text

    elif ext == ".docx":
        doc = Document(filename)
        return "\n".join([p.text for p in doc.paragraphs])

    elif ext == ".pptx":
        prs = Presentation(filename)
        text = ""
        for slide in prs.slides:
            for shape in slide.shapes:
                if hasattr(shape, "text"):
                    text += shape.text + "\n"
        return text

    elif ext in [".xlsx", ".csv"]:
        df = pd.read_excel(filename) if ext == ".xlsx" else pd.read_csv(filename)
        return df.to_string()

    elif ext in [".png", ".jpg", ".jpeg"]:
        img = Image.open(filename)
        return pytesseract.image_to_string(img)

    elif ext == ".txt":
        with open(filename, "r", encoding="utf-8") as f:
            return f.read()

    else:
        return "Unsupported file type!"


file = "simple.pdf"
print(extract_text(file))