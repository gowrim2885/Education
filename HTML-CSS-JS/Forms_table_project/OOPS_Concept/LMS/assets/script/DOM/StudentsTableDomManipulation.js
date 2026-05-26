
class StudentsTableDomManipulation {

    constructor(service, student, FormManipulation) {
        this.model = student;
        this.studentForm = FormManipulation;
        this.service = service;
        this.tablebody = document.querySelector('#Table-body');
        this.InitializeTableElements();
    }


    InitializeTableElements() {
        //TABLES DOM ELEMENTS
        document.getElementById("add_Student")?.addEventListener('click', (e) => {
            e.preventDefault();
            this.OpenAddStudentForm();
        })

        document.getElementById('sortaz')?.addEventListener('click', (e) => {
            e.preventDefault();
            this.SortStudentAZ();
        });

        document.getElementById('sortza')?.addEventListener('click', (e) => {
            e.preventDefault();
            this.SortStudentZA();
        });
        this.DisplayTable();

    }



    DisplayTable() {
        if (!this.tablebody) return;
        this.tablebody.innerHTML = "";

        const student_records = this.service.getData();
        student_records.forEach((student) => this.service.AddStudent(student));
    }

    OpenAddStudentForm() {

        window.location.href = "addForm.html"
    }


    DeleteStudent() {
        this.service.DeleteStudent();
    }

    SortStudentAZ() {
        this.service.SortStudentAZ();
    }

    SortStudentZA() {
        this.service.SortStudentZA();
    }

}

document.addEventListener('DOMContentLoaded', function () {

    const edit_id = localStorage.getItem("edit_id");
    const databaseData = new DataContext();
    const student = new Students();
    const service = new StudentServices(databaseData, edit_id);
    const FormManipulation = new StudentFormDomManipulation(service, edit_id, student);
    
    const tableManipulation = new StudentsTableDomManipulation(service, student, FormManipulation);

});

