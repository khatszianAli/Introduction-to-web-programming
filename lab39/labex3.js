function startCounter() {
    let counter = 1;
    let interval = setInterval(() => {
        console.log("Counter:", counter);
        if (counter === 5) {
            clearInterval(interval);
        }
        counter++;
    }, 1000);
}

startCounter();
