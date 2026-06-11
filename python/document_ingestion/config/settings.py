import os

BASE_DIR = os.path.dirname(
    os.path.dirname(os.path.abspath(__file__))
)

PROCESSED_DIR = os.path.join(
    BASE_DIR,
    "processed"
)

IMAGE_DIR = os.path.join(
    PROCESSED_DIR,
    "images"
)

TABLE_DIR = os.path.join(
    PROCESSED_DIR,
    "tables"
)

JSON_DIR = os.path.join(
    PROCESSED_DIR,
    "json"
     
)

OCR_LANGUAGE = "eng"

TESSERACT_PATH = (
    r"C:\Program Files\Tesseract-OCR\tesseract.exe"
)