function fetchData() {
    return new Promise((resolve) => {
        setTimeout(() => resolve("Data received"), 2000);
    });
}

fetchData()
    .then((data) => console.log(data))
    .finally(() => console.log("Request completed"));
