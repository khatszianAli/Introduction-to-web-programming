#Lab 11
#Data Structures in Python

#1. Lists
fruits = ['apple', 'banana', 'cherry']
print(fruits[0])

fruits.append('orange')

fruits.remove('cherry')

for fruit in fruits:
    print(fruit)

#2. Dictionaries
student = {"name" : "John", "age" : 25, "grade" : "A"}

print(student["name"])

student["age"] = 23

for key, value in student.items():
    print(f"key: {key}, value: {value}")

#3. Sets
numbers = {1, 2, 3, 4, 5}

numbers.add(6)

numbers.remove(3)

evens = {2, 4, 6, 8}

print(numbers.intersection(evens))

#4. Tuples
point = (10, 20)

print(point[0])

for coord in point:
    print(coord)

#Data Structures in Python: Methods and Operations

#1. List Examples
numbers = [7, 6, 3, 2, 5]

numbers.append(1)
numbers.sort()

unique_numbers = list(set(numbers))

#2. Dictionaries Examples
student = {"name" : "John", "age" : 25, "grade" : "A"}
print(student.get("name"))

student.update({"grade": "A+", "age" : 20})
print(student)

#3. Set Examples
data = [1, 2, 3, 1, 2]
unique_numbers = set(data)

print(unique_numbers)

set1 = {1, 2, 3}
set2 = {3, 4, 5}


print(set1.intersection(set2))

#4. Tuple Examples
coordinates = (10, 20, 30)
print(coordinates[1])

numbers = (1, 2, 3, 1)
print(numbers.count(1))

#Task 1: Basic List Operations
l = [10, 20, 30, 40, 50]
l.append(60)
print(l)
l.insert(1, 15)
print(l)
l.remove(30)
print(l)
print(l.reverse())
print(l.sort())

#Task 2: List Slicing and Indexing
print(l[:3])
print(l[-2:])
print(l[::-1])

#Exercise 2: Working with Dictionaries
student = {"name" : "Alice", "age" : 22, "grade" : "A"}
student["subject"] = "Math"
student["grade"] = "A+"
student.pop("grade")

print(student.keys())
print(student.values())
print(student.items())

#Exercise 3: Working with Sets
set1 = {1, 2, 3, 4, 5}
set2 = {4, 5, 6, 7, 8}

print(set1.union(set2))
print(set1.intersection(set2))
print(set1 - set2)

#Exercise 4: Working with Tuples
t = ("red", "blue", "green", "red", "yellow")
print(t.find("green"))
print(t.count("red"))

#Challenge Task: Nested Data Structures
company = {
    "Employees": [
        {"name" : "John", "position" : "Back-end", "salary" : 100000},
        {"name" : "Alice", "position" : "Front-end", "salary" : 900000}
    ]
}
company["Employees"] = {"name" : "Klein", "position" : "QA", "salary" : 950000}
for emp in company["Employees"]:
    print(emp["name"])