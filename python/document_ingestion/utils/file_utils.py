import os


def ensure_directory(path):

    if not os.path.exists(path):
        os.makedirs(path)


def get_extension(file_path):

    return os.path.splitext(file_path)[1].lower()


def get_file_name(file_path):

    return os.path.basename(file_path)