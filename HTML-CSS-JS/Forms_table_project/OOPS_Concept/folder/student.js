
class Student {
    constructor(id, name, department, year, age, gender, subject) {
        this.id = id;
        this.name = name;
        this.department = department;
        this.year = year;
        this.age = age;
        this.subject = subject;
        this.gender = gender;
    }
}



class StudentService {
    get_Student_Data() {
        return JSON.parse(localStorage.getItem("Students_Information")) || [];
    }

    set_Student_Data(students) {
        localStorage.setItem("Students_Information", JSON.stringify(students));
    }
}