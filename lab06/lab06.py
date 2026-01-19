#Lab 6
# Python Data Types

#1. Numeric Types

# Int
x = 5
y = -3
z = 0

print(type(x))

# Float
a = 3.14
b = -0.001
c = 2.5e3

print(type(a))

# Complex
c1 = 3 + 4j
c2 = 2 -5j

print(type(c1))

#2. Sequence Types
# String
greeting = "Hello, World!"
name = "Alice"

print(type(greeting))

# list
fruits = ["apple", "pear", "orange", "banana"]
numbers = [1, 2, 3, 4, 5]
mixed = [1, "apple", 3.14, True]

fruits[1] = "blueberry"

print(fruits)
print(type(fruits))

# tuple
coordinates = (4, 5)
colors = ("red", "green", "blue")

print(type(coordinates))

#3. Mapping Type

# Dictionary
person = {
    "name": "Alice",
    "age": 25,
    "city": "New York"
}

print(person["name"])
print(type(person))

#4. Set Types

# Set

unique_numbers = {1, 2, 3, 4, 5, 5, 4}
print(unique_numbers)
print(type(unique_numbers))

# Frozenset
frozen_set = frozenset([1, 2, 3])
print(frozen_set)
print(type(frozen_set))

#5. Boolean Type

# Bool
is_active = True
is_admin = False

print(type(is_active))

#6. Binary Types

# Bytes
byte_data = b"hello"

print(byte_data)
print(type(byte_data))

# Bytearray
mutable_bytes = bytearray([65, 66, 67])
mutable_bytes[0] = 68

print(mutable_bytes)
print(type(mutable_bytes))

#Type Conversion Examples

# Int
x = "10"
y = int(x)
print(type(y))

# Float
x = "3.14"
y = float(x)
print(type(y))

# String
x = 100
y = str(x)
print(type(y))

# List
x = "hello"
y = list(x)
print(y)

#Lab Exercise

# 1
int_input = input(int("Write int number: "))
float_input = input(float("Write float number: "))
string_input = input(str("Write text: "))

print(type(int_input))
print(type(float_input))
print(type(string_input))

# 2
string_num = "3.0"
float_num = float(string_num)
int_num = int(float_num)

data = {
    "name": "Alyce",
    "age": 22
}
print(type(data["age"]))

# 3

num_set = {1, 2, 3}
num_set.add(4)
num_set.remove(2)
print(1 in num_set)

#Operations in Python

#1. Arithmetic Operations

# Addition (+)
print(5 + 3)
print("Hello" + ",World!")

# Subtraction (-)
print(5 - 3)
print(7.5 + 2.5)

# Multiplication (*)
print(5 * 3)
print("Hello" * 3)

# Division (/)
print(5 / 3)
print(7 / 2)

# Floor Division (/)
print(5 // 3)
print(7 // 2)

# Modulus (%)
print(5 % 3)
print(7 % 2)

# Exponentiation (**)
print(5 ** 3)
print(2 ** 4)

#2. Comparison Operations

# Equal to (==)
print(3 == 3)
print(5 == 2)

# Not equal to (!=)
print(4 != 3)
print(2 != 2)

# Greater than (>)
print(4 > 3)
print(2 > 2)

# Less than (<)
print(4 < 3)
print(2 < 3)

# Greater or Equal than (>)
print(4 >= 3)
print(2 >= 2)

# Less or Equal than (<)
print(3 <= 3)
print(2 <= 3)

#3. Logical Operations

# AND (and)
print(True and True)
print(True and False)

# OR (or)
print(True or True)
print(True or False)

# NOT (not)
print(not True)
print(not False)

#4. Bitwise Operations

# AND (&)
print(5 & 3)

# OR (|)
print(5 | 3)

# XOR (^)
print(5 ^ 3)

# NOT (~)
print(~5)

#5. Assignment Operations

# Simple Assignment (=)
x = 5

# Add and Assign (+=)
x = 5
x += 3
print(x)

# Subtract and Assign (-=)
x = 5
x -= 3
print(x)

# Multiply and Assign (*=)
x = 5
x *= 3
print(x)

# Divide and Assign (/=)
x = 5
x /= 2
print(x)

# Modulus and Assign (%=)
x = 5
x %= 3
print(x)

#6. Identity and Membership Operations

# Identity (is)
x = [1, 2, 3]
y = x
z = [1, 2, 3]

print(x is y)
print(x is z)

# Not Identity (is not)
x = [1, 2, 3]
z = [1, 2, 3]
print(x is not z)

# Membership (in)

fruits = ["apple", "pear", "orange", "banana"]
print("apple" in fruits)
print("lemon" in fruits)

# Not Membership (not in)
fruits = ["apple", "pear", "orange", "banana"]
print("lemon" not in fruits)
