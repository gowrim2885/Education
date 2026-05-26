const student = {
    name:"gowri",
    id: "14",
    dept:"CSE",
    year:"IV"
}

console.log(student);

console.log(student.id);

console.log("year", student["year"]);
student["name"] = "Abi";
console.log(student);

delete student["id"];
console.log(student);

student["subject"] = ['maths','physics', 'chemistry'];
console.log(student);
console.log(student.subject[2]);

for(let key in student){
    console.log(key, ":", student[key]);
}
console.log(" =======display all keys");
console.log(Object.keys(student));

console.log(" =======display all values");
console.log(Object.values(student));

console.log(Object.entries(student));

console.log("========Object destructuring========");
const {id , name, dept} = student;
console.log(name + " " + dept);

const color = {
    red: "apple",
    yello:"banana"
}

const { red:redFruite , yello: yelloFruite} = color;
console.log(redFruite + " "+yelloFruite);

function display({red, yello}){
    console.log(red,yellow);
}


