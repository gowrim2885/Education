import re


class TextCleaner:

    @staticmethod
    def clean(text):

        # Remove extra spaces
        text = re.sub(
            r'\s+',
            ' ',
            text
        )

        # Remove multiple blank lines
        text = re.sub(
            r'\n{3,}',
            '\n\n',
            text
        )

        # Remove page numbers
        text = re.sub(
            r'Page\s+\d+',
            '',
            text,
            flags=re.IGNORECASE
        )

        return text.strip()