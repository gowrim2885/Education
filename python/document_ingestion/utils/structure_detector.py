class StructureDetector:
    @staticmethod
    def detect_headings(text):
        headings = []
        lines = text.splitlines()
        for line in lines:
            line = line.strip()
            if (len(line) < 80  and len(line) > 3 and line.isupper() ):
                headings.append(line)
        return headings