
class Form {
    constructor(table, service) {
        this.tableData = table;
        this.service = service;

    }

    getFormData() {
        const student_id = document.getElementById("stud_id").value;
        const stud_name = document.getElementById('name').value;
        const stud_department = document.getElementById("dept").value;
        const stud_year = document.getElementById("year").value;
        const stud_age = document.getElementById('age').value;

        let stud_gender = "";
        if (document.getElementById("female").checked) { stud_gender = "Female"; }
        if (document.getElementById("male").checked) { stud_gender = "Male"; }

        let subjects = [];
        let sub = document.querySelectorAll('input[name="subject"]:checked');
        sub.forEach((item) => {
            subjects.push(item.value);
        });


        let data = this.service.get_Student_Data();
        const edit_id = localStorage.getItem("edit-id");

        if (edit_id) {
            let index = data.findIndex(s => s.id == edit_id);
            if (index != -1) {
                data[index] = new Student(student_id, stud_name, stud_department, stud_year, stud_age, stud_gender, subjects);
            }
            localStorage.removeItem("edit-id");
        }
        else {
            data.push(new Student(student_id, stud_name, stud_department, stud_year, stud_age, stud_gender, subjects));
        }

        this.service.set_Student_Data(data);
        this.tableData.DisplayTable();

        window.location.href = "formTableData.html";

    }
}


