import json
import uuid

with open("C:\Gowri\Education-repo\python\document_assets.json", "r", encoding="utf-8") as f:
    document = json.load(f)

assets = document["assets"]

#Heading Detection
def is_heading(text):
    text = text.strip()
    if len(text.split()) <= 5 and text.isupper():
        return True
    return False

#Section Builder
sections = []
current_section = {"section_id": str(uuid.uuid4()), 
                   "heading": "Introduction",
                    "content": [],
                    "tables": [],
                    "images": []
                }

for asset in assets:
    asset_type = asset["asset_type"]

    #text
    if asset_type == "text":
        text = asset["text"]
        if is_heading(text):
            sections.append(current_section)
            current_section = {
                "section_id": str(uuid.uuid4()),
                "heading": text,
                "content": [],
                "tables": [],
                "images": []
            }
        else:
            current_section["content"].append(text) 

    #table
    elif asset_type == "table":
        current_section["tables"].append(asset["table"])

    #image
    elif asset_type == "image":
        current_section["images"].append({
            "image_path": asset["image_path"],
            "ocr_text": asset["ocr_text"]
        })

sections.append(current_section)

#Final Document Structure
final_document_structure = {
    "document_id": document["document_id"],
    "file_name": document["file_name"],
    "section_count": len(sections),
    "sections": sections
}

with open("final_document_structure.json", "w", encoding="utf-8") as f:
    json.dump(final_document_structure, f, indent=4, ensure_ascii=False)

print("Final document structure saved to final_document_structure.json")