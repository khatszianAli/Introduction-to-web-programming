let numbers = [10, 15, 20, 25, 30];
let sum = 0;

for (let num of numbers) {
    console.log("Current number:", num);
    if (num % 2 === 0) {
        sum += num;
    }
}
console.log("Final sum of even numbers:", sum);
