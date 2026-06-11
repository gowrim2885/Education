class TableSerializer:
    @staticmethod
    def to_text(table_asset):
        rows = table_asset.rows
        headers = rows[0]
        output = []
        for row in rows[1:]:
            row_text = []
            for i in range(len(headers)):
                row_text.append(f"{headers[i]}: {row[i]}")
            output.append(", ".join(row_text))
        return "\n".join(output)