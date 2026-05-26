class StudentServices {
    constructor() {
        this.tablebody = document.querySelector('#Table-body');
        this.Database = new DataContext();
    }

    getData() {
        let data = this.Database.getData();
        return data;
    }

    setData(data) {
        this.Database.setData(data);
    }

    AddStudent(student) {
        const row = this.tablebody.insertRow();
        row.insertCell(0).textContent = student.id;
        row.insertCell(1).textContent = student.name;
        row.insertCell(2).textContent = student.department;
        row.insertCell(3).textContent = student.year;
        row.insertCell(4).textContent = student.age;
        row.insertCell(5).textContent = student.gender;
        row.insertCell(6).textContent = student.subject;

        const actionCell1 = row.insertCell(7);
        const actionCell2 = row.insertCell(8);

        const delBtn = document.createElement("button");
        delBtn.textContent = "Delete";

        delBtn.addEventListener('click', () => this.DeleteStudent(row));
        actionCell1.appendChild(delBtn);

        const editBtn = document.createElement("button");
        editBtn.textContent = "Edit";

        editBtn.addEventListener('click', (e) => {
            e.preventDefault();
            localStorage.setItem("edit_id", student.id);
            window.location.href = "addForm.html";

        });
        actionCell2.appendChild(editBtn);
    }


        DeleteStudent(row) {
            let i = row.rowIndex - 1;
            row.remove();

            let student_records = this.getData();
            if (i > -1 && i < student_records.length) {
                student_records.splice(i, 1);
                this.setData(student_records);
            }
        }

        SortStudentAZ() {
            let student_records = this.getData();
            student_records.sort((a, b) => parseFloat(a.id) - parseFloat(b.id));
            this.setData(student_records);
            location.reload();
        }


        SortStudentZA() {
            let student_records = this.getData();
            student_records.sort((a, b) => parseFloat(b.id) - parseFloat(a.id));
            this.setData(student_records);
            location.reload();
        }

    }
