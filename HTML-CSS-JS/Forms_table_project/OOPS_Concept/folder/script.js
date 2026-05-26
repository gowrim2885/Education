
class Table {
    constructor(service, edit_id) {
        this.service = service;
        this.tablebody = document.querySelector('#Table-body');
        this.edit_id = edit_id;
    }

    DisplayTable() {
        if (!this.tablebody) return;
        this.tablebody.innerHTML = "";

        let data = this.service.get_Student_Data();
        data.forEach((student) => this.updateTableData(student));
    }

    updateTableData(student) {
        const row = this.tablebody.insertRow();
        row.insertCell(0).textContent = student.id;
        row.insertCell(1).textContent = student.name;
        row.insertCell(2).textContent = student.department;
        row.insertCell(3).textContent = student.year;
        row.insertCell(4).textContent = student.age;
        row.insertCell(5).textContent = student.gender;
        row.insertCell(6).textContent = student.subject.join(',');

        const actionCell = row.insertCell(7);
        const delBtn = document.createElement("button");
        delBtn.textContent = "Delete";

        delBtn.addEventListener('click', () => this.deleteRow(row));
        actionCell.appendChild(delBtn);

        const editBtn = document.createElement("button");
        editBtn.textContent = "Edit";

        editBtn.addEventListener('click', (e) => {
            e.preventDefault();
            localStorage.setItem("edit-id", student.id);
            window.location.href = "addForm.html";

        });

        actionCell.appendChild(editBtn);


    }

    deleteRow(row) {
        console.log(row);
        let i = row.rowIndex - 1;
        row.remove();

        let data = this.service.get_Student_Data();
        if (i > -1 && i < data.length) {
            data.splice(i, 1);
            this.service.set_Student_Data(data);
        }
    };

    editRow() {
        let data = this.service.get_Student_Data();
        let student = data.find(s => s.id == this.edit_id);

        if (student) {
            document.getElementById("stud_id").value = student.id;
            document.getElementById('name').value = student.name;
            document.getElementById("dept").value = student.department;
            document.getElementById("year").value = student.year;
            document.getElementById('age').value = student.age;

            if (student.gender === "Female") {
                document.getElementById("female").checked = true;
            }
            else if (student.gender === "Male") {
                document.getElementById("male").checked = true;
            }

            student.subject.forEach(sub => {
                let checkbox = document.querySelector(`input[name="subject"][value="${sub}"]`);
                if (checkbox) {
                    checkbox.checked = true;
                }
            });
        }
        
    }


    SortAZ() {
        let data = this.service.get_Student_Data();
        data.sort((a, b) =>(a.id).localeCompare(b.id));
        this.service.set_Student_Data(data);
        this.DisplayTable();
    }

    SortZA() {
        let data = this.service.get_Student_Data();
        data.sort((a, b) => (b.id).localeCompare(a.id));
        this.service.set_Student_Data(data);
        this.DisplayTable();
    }

    GetFilterData(){
        let data = this.service.get_Student_Data();
        let search_data = localStorage.getItem('tablefilter');

        // const table = document.getElementById("myTable");
        const row = document.getElementsByTagName('tr');
        // const filtered_Data = localStorage.getItem('tablefilter');

        data.forEach((student, index)=>{
            if(student.name == search_data){
                row[index].style.display = "";
            }
            else{
                row[index].style.display = "none";
            }

        })

    }
}
