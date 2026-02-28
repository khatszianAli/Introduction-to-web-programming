function fetchData() {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            if (Math.random() > 0.5) {
                resolve("Data received");
            } else {
                reject("Error: Failed to fetch data");
            }
        }, 2000);
    });
}

fetchData()
    .then((data) => console.log(data))
    .catch((error) => console.error(error))
    .finally(() => console.log("Request completed"));
