import os

#Checks whether a directory exists. If not, it creates the directory.
def ensure_directory(path):
    if not os.path.exists(path):
        os.makedirs(path)

#Extract file extension.
def get_extension(file_path):
    return os.path.splitext(file_path)[1].lower()

#Extract file name only
def get_file_name(file_path):
    return os.path.basename(file_path)