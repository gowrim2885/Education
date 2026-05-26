STORAGE_KEY='student_detail';

document.addEventListener('DOMContentLoaded', () => {
  
    const studentForm = document.getElementById("AddUserForm");
    if (studentForm) {
        studentForm.addEventListener('submit', addStudent);
    } 

    displayTable();
});

const tablebody = document.querySelector("#myTable tbody");

function addStudent(e){
    e.preventDefault();
    const name = document.getElementById('name').value;

    const age = document.getElementById('age').value;

    let gender="";
    if(document.getElementById("female").checked){ gender = "Female"; }
    if( document.getElementById("male").checked){ gender = "Male"; }

    const Qualification = document.getElementById("Qualification").value;

    let subjects = [];
    let sub= document.querySelectorAll('input[name="subject"]:checked');
    sub.forEach(args => subjects.push(args.value));

    let student = { name, age , gender , Qualification, subjects};

    loaddata(student);
    window.location.href="index.html";
    
}


function updateTable(student) {
    const row = tablebody.insertRow();
    row.insertCell(0).textContent = student.name;
    row.insertCell(1).textContent = student.age;
    row.insertCell(2).textContent = student.gender;
    row.insertCell(3).textContent = student.Qualification;
    row.insertCell(4).textContent = student.subjects.join(", ");
    
    const actionCell = row.insertCell(5);
    const delBtn = document.createElement("button");
    delBtn.textContent = "Delete";

    delBtn.onclick = function () {
        let i = row.rowIndex - 1;  
        row.remove();
        
    let data = JSON.parse(localStorage.getItem(STORAGE_KEY)) || [];
    if (i > -1 && i < data.length) {
        data.splice(i, 1); 
        localStorage.setItem(STORAGE_KEY, JSON.stringify(data));
    }
    };
    actionCell.appendChild(delBtn);
    // tablebody.appendChild(row);
}


function displayTable() {
    if (!tablebody) return;
    tablebody.innerHTML = ""; 
    let data = JSON.parse(localStorage.getItem(STORAGE_KEY)) || [];
    data.forEach(student => {
        if (student && student.name) { 
            updateTable(student);
        }
    });
}

function loaddata(student) {
    const storedData = localStorage.getItem(STORAGE_KEY);
    let data = storedData ? JSON.parse(storedData) : [];
    data.push(student);
    localStorage.setItem(STORAGE_KEY, JSON.stringify(data));
}





// function sortTable() {
//     let data = JSON.parse(localStorage.getItem(STORAGE_KEY)) || [];
//     data.sort((a, b) => a.name.localeCompare(b.name));
//     localStorage.setItem(STORAGE_KEY, JSON.stringify(data));
//     displayTable(); 
// }


// function sortTablereverse(){
//    let data = JSON.parse(localStorage.getItem(STORAGE_KEY)) || [];
//    data.sort((a,b)=> b.name.localeCompare(a.name));
//     localStorage.setItem(STORAGE_KEY, JSON.stringify(data));
//     loadStudents();
// }
