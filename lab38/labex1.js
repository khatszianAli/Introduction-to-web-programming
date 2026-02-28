function parseJSON(jsonStr) {
    try {
        let parsedData = JSON.parse(jsonStr);
        console.log(parsedData);
    } catch (error) {
        console.error("Invalid JSON format");
    }
}

let validJSON = '{"name": "Alice", "age": 25}';
let invalidJSON = '{name: "Alice", age: 25}';

parseJSON(validJSON);
parseJSON(invalidJSON);
