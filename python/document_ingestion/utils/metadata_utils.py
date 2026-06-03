import os
from datetime import datetime


def extract_basic_metadata(file_path):

    stat = os.stat(file_path)

    return {
        "size_bytes": stat.st_size,
        "created_time": datetime.fromtimestamp(
            stat.st_ctime
        ).isoformat(),
        "modified_time": datetime.fromtimestamp(
            stat.st_mtime
        ).isoformat(),
    }