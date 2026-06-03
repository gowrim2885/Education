from PIL import Image
import pytesseract

from config.settings import (
    TESSERACT_PATH,
    OCR_LANGUAGE
)

pytesseract.pytesseract.tesseract_cmd = (
    TESSERACT_PATH
)


def perform_ocr(image_path):

    try:

        image = Image.open(image_path)

        text = pytesseract.image_to_string(
            image,
            lang=OCR_LANGUAGE,
            config="--psm 6"
        )

        return text.strip()

    except Exception as ex:

        print(f"OCR Error: {ex}")

        return ""