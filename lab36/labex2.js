let message = "Hello from global";

function helloGlobal(){
    let localMessage = "Hello from function scope";
    console.log(localMessage);
}

helloGlobal();
console.log(message);
console.log(localMessage);
