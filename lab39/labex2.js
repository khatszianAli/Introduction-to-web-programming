function delayedMessage(message, delay) {
    setTimeout(() => console.log(message), delay);
}

delayedMessage("Hello, after 3 seconds!", 3000);
