import json

from extractors.pdf_extractor import PDFExtractor


extractor = PDFExtractor()

document = extractor.extract(
    "C:\\Gowri\\Education-repo\\python\\Sample.pdf"
)

with open(
    "pdf_output.json",
    "w",
    encoding="utf-8"
) as f:

    json.dump(
        document.to_dict(),
        f,
        indent=4,
        ensure_ascii=False
    )

print("PDF extraction complete")