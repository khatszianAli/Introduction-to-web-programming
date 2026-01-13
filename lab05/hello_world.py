print("Hello World!")

#Key Points About Variables in Python

#1 Declaration and Assignment: Use = to assign a value to a variable.
x = 10
name = "Alica"
price = 19.99
is_active = True

#2 Dynamic Typing: Variables can change type during runtime.
x = "Hello"

#3 . Naming Rules:
#Must start with a letter or underscore (_).
#Cannot start with a number.
#Can only contain alphanumeric characters and underscores.
#Case-sensitive (name and Name are different).
#Reserved keywords (e.g., if, for, class) cannot be used as variable names.

#4. Printing Variables: Use the print() function to display variable values.
age = 25
print("Age:", age)

#5 Multiple Assignments:
a, b, c = 5, 10, 15
print(a, b, c)

#6 Constants: While Python doesn’t have built-in support for constants,
# naming variables in all uppercase is a common convention.
PI = 3.14159
GRAVITY = 9.8

#Examples for Practice

#1 Simple Variable Assignment:
greeting = "Hello, World!"
print(greeting)

#2 Arithmetic with Variables:
num1 = 10
num2 = 5

result = num1 + num2
print("Sum:", result)

#3 Type Checking:
value = 42
print(type(value))
value = "python"
print(type(value))

#4 Swapping Variables:
x, y = 5, 10
x, y = y, x
print("x:", x, "y:", y)

#5 Updating Variables:
counter = 0
counter += 1
print("counter:", counter)

#Lab work

#1

name = "Ali"
print("Name:", name)

#2
n1 = 4
n2 = 6
addition = n1 + n2
subtraction = n1 - n2
multiplication = n1 * n2
division = n1 / n2
print("Addition:", addition)
print("Subtraction:", subtraction)
print("Multiplication:", multiplication)
print("Division:", division)

#3
x = 3
y = 7
print("Before swapping:", "x=", x, "y=", y)
x, y = y, x
print("After swapping:", "x=", x, "y=", y)
#4
PI = 3.14159
area = PI * 5**2
print("Area:", area)

#Basic Syntax in Python. Input/Output

#1 Basic Input:
name = input("Enter your name: ")
print("Hello", name)

#2 Type Conversion with Input:
age = int(input("Enter your age: "))
print("Next year,you will be: ", age + 1)

#3 Multiple Inputs:

a, b = input("Enter two numbers separated by space: ").split()
a, b = int(a), int(b)
print("Sum: ", a + b)

# Print() function

#1 Basic Output:
print("Welcome to Python!")

#2 Formatted Output:
name = "Alice"
age = 25
print(f"My name is {name} and my age is {age}.")

#3 Specifying sep and end:

print("Python", "is", "fun", sep= "-")
print("This is first line", end= " ")
print("and this is the second line.")

#Lab Work

#1
name = input("Enter your name: ")
age = input("Enter your age: ")
print(f"Welcome {name}! I thin your age is {age}")

#2
num1 = int(input("Enter a number: "))
num2 = int(input("Enter a second number: "))
num3 = int(input("Enter a third number: "))

sum = num1 + num2 + num3
avg = sum / 3
product = num1 * num2 * num3

print(f"Sum is {sum}, average is {avg}, product is {product}")

#  Comments

#1 Single-Line Comments

#This is single line comment
print("Hello, World!") #This prints greeting

#2 Multi-line comments

"""
This is a multi-line comments
It explains the purpose of the program.
"""
print("Python is awesome!")

#3 inline comments
x = 10 # This is initial of variable x