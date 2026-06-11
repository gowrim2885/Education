import os
import uuid

from config.settings import IMAGE_DIR
from utils.file_utils import ensure_directory

ensure_directory(IMAGE_DIR)


class AssetManager:
    #store the image in the asset directory and return the path
    @staticmethod
    def generate_image_name(extension=".png"):

        return f"{uuid.uuid4()}{extension}"

    @staticmethod
    def save_binary(data, extension=".png"):

        filename = AssetManager.generate_image_name(
            extension
        )

        filepath = os.path.join(
            IMAGE_DIR,
            filename
        )

        with open(filepath, "wb") as file:
            file.write(data)

        return filepath