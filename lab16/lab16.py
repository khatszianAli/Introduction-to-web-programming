#Lab 16
#JSON Module in Python

#1. Converting Python Objects to JSON (Serialization)
import json

data = {
    "name": "Alice",
    "age": 25,
    "city": "New-York"
}

json_string = json.dumps(data)
print(json_string)

#2. Writing JSON to a File
import json

data ={
    "name": "Alice",
    "age": 25,
    "city": "New-York"
}

with open('data.json', 'w') as f:
    json.dump(data, f)

#3. Reading JSON from a File
import json

with open('data.json', 'r') as f:
    data = json.load(f)

print(data)

#4. Converting JSON to a Python Object (Deserialization)
import json

json_string = {
    "name": "Alice",
    "age": 25,
    "city": "New-York"
}

data = json.loads(json_string)

print(data["name"])
print(type(data))

#5. Working with Lists in JSON
import json

users = [
    {"name": "Alice", "age": 25},
    {"name": "Bob", "age": 30},
    {"name": "Charlie", "age": 22}
]

json_string = json.dumps(users, indent=4)
print(json_string)

#6. Writing a List of Dictionaries to a File
import json

users = [
    {"name": "Alice", "age": 25},
    {"name": "Bob", "age": 30},
    {"name": "Charlie", "age": 22}
]

with open('users.json', 'w') as f:
    json.dump(users, f, indent=4)

#7. Handling JSON Errors
import json

invalid_json = '{"name": "Alice", "age": 25, "city": "New-York"'

try:
    data = json.loads(invalid_json)
except json.decoder.JSONDecodeError as e:
    print(f"Error loading JSON: {e}")

#Lab Exercise 1
import json

student_info = {
    "name": "Alice",
    "age": 25,
    "city": "New-York",
    "courses": ["database", "OOP", "DSA"]
}

json_string = json.dumps(student_info, indent=4)
print(json_string)

#Lab Exercise 2:
import json

student_info = '''{
    "name": "Alice",
    "age": 25,
    "city": "New-York",
    "courses": ["database", "OOP", "DSA"]
}'''

json_string = json.loads(student_info)
print(json_string)

#Lab Exercise 3
import json

student_info = {
    "name": "Alice",
    "age": 25,
    "city": "New-York",
    "courses": ["database", "OOP", "DSA"]
}

filename = 'student.json'

with open(filename, 'w') as f:
    json.dump(student_info, f, indent=4)
print(f"Data in {filename}")

with open(filename, 'r') as f:
    data_loaded = json. load (f)

print (data_loaded)