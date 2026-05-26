// Primitive types (primarily on Stack/Scope)

function AssignValue(){
let myNumber = 42;
let myString = "Hello Memory";
let myBool = true;
let myNull = null;
console.log("Inside function", myNumber);
}


function add(a,b){
    let result  = a*b;
    display(result);
}

function display(result){
    console.log(result);
}

add(6,6);
AssignValue();

// console.log("Outside function", myNumber);

let myUndef = undefined;
let myBigInt = 9007199254740991n;
let mySymbol = Symbol('id');

let myObject = { name: "John", age: 30 };
let myArray = [1, 2, 3, 4, 5];
let myFunction = function() { return "I am on the heap"; };

// debugger;




// let order = new Promise(function(resolve, reject){
//     let orderplace = true;
//     if(orderplace){
//         resolve("succeed");
//     }
//     else{
//         reject("Failed");
//     }

// });

// order
//     .then((Messg)=>{
//         console.log("Successfully placed");
//     });
