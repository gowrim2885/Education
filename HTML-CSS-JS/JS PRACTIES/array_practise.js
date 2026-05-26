let arr = [1, 4, 5, 2, 3];
const fruit = new Array("apple", "banana", "orange");

console.log(arr);
console.log(typeof arr);
console.log(typeof fruit);
console.log(Array.isArray(arr));
console.log(arr.length);

arr.push(6);console.log(arr);
arr.unshift(0);
arr.pop();
console.log(arr);
arr.shift();

console.log(arr);

console.log(arr.slice(1, 4));
arr.splice(1, 1, 99, 98); //strt, cont, add
console.log(arr);

console.log(arr.includes(5));
console.log(arr.indexOf(99));

console.log(arr.sort());
console.log(arr.reverse());

console.log(arr.join("-"));
console.log(fruit.toString());

arr.forEach(x => console.log(x));

let mapped = arr.map(x => x * 2);
console.log(mapped);

let filtered = arr.filter(x => x > 3);
console.log(filtered);

let sum = arr.reduce((total, x) => total + x, 0);
console.log(sum);
