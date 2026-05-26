class StudentFormDomManipulation {


    constructor(service, edit_id, student) {
        this.InitializeFormElements();
        this.model = student;
        this.service = service;
        this.edit_id = edit_id;

        if (edit_id) {
            let data = service.getData();
            let index = data.findIndex(s => s.id == edit_id);

            if (index != -1) {
                const student = data[index];

                const studIdElement = document.getElementById("stud_id");
                if (studIdElement) studIdElement.value = student.id;

                const nameElement = document.getElementById("name");
                if (nameElement) nameElement.value = student.name;

                const deptElement = document.getElementById("dept");
                if (deptElement) deptElement.value = student.department;

                const yearElement = document.getElementById("year");
                if (yearElement) yearElement.value = student.year;

                const ageElement = document.getElementById("age");
                if (ageElement) ageElement.value = student.age;

                if (student.gender === "female") {
                    const femaleRadio = document.getElementById("female");
                    if (femaleRadio) femaleRadio.checked = true;
                } else if (student.gender === "male") {
                    const maleRadio = document.getElementById("male");
                    if (maleRadio) maleRadio.checked = true;
                }

                student.subject.forEach(sub => {
                    let checkbox = document.querySelector(`input[name="subject"][value="${sub}"]`);
                    if (checkbox) checkbox.checked = true;
                });

                this.model.SetId(student.id);
                this.model.SetName(student.name);
                this.model.SetDepartment(student.department);
                this.model.SetYear(student.year);
                this.model.SetAge(student.age);
                this.model.SetGender(student.gender);
                this.model.SetSubject(student.subject);

            }
        }
    }


    InitializeFormElements() {

        document.getElementById("submitStudentForm")?.addEventListener('click', (e) => {
            e.preventDefault();
            this.getFormData();
        });

        document.getElementById('stud_id')?.addEventListener('input', (event) => {
            this.model.SetId(event.target.value)
        });

        document.getElementById('name')?.addEventListener('input', (event) => {
            this.model.SetName(event.target.value)
        });

        document.getElementById("dept")?.addEventListener('input', (event) => {
            this.model.SetDepartment(event.target.value);
        });

        document.getElementById("year")?.addEventListener('input', (event) => {
            this.model.SetYear(event.target.value)
        });

        document.getElementById('age')?.addEventListener('input', (event) => {
            this.model.SetAge(event.target.value)
        });


        document.querySelectorAll('input[name="Gender"]').forEach(gen => {
            gen.addEventListener('input', (event) => {
                if (event.target.checked) {
                    this.model.SetGender(event.target.value);
                }
            })
        });


        document.querySelectorAll('input[name="subject"]').forEach(sub => {
            sub.addEventListener('input', (event) => {
                const subjects = Array.from(
                    document.querySelectorAll('input[name="subject"]:checked')
                ).map(el => el.value);
                console.log(subjects);
                this.model.SetSubject(subjects);

            });

        });

    }


    getFormData() {

        let student = {
            id: this.model.id,
            name: this.model.name,
            department: this.model.department,
            year: this.model.year,
            age: this.model.age,
            subject: this.model.subject,
            gender: this.model.gender
        };

        let data = this.service.getData();


        if (this.edit_id) {
            let index = data.findIndex(s => s.id == this.edit_id);
            if (index != -1) {
                data[index] = this.model;
            }
            localStorage.removeItem("edit_id");
        }
        else {
            data.push(student);
        }

        this.service.setData(data);

        window.location.href = "formTableData.html";

    }



}
