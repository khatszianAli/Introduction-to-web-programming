#Lab 8
#Working with Functions

#1. Defining a Function
def greet():
    print("Hello World!")

greet()

#2. Function Parameters
def greet_user(user):
    print(f"Hello {user}! How are you")

greet_user("John")

#3. Default Parameters
def greet_user(user = "Guest"):
    print(f"Hello {user}!")

greet_user()
greet_user("John")

#4. Returning Values
def add(a, b):
    return a + b
result = add(5, 10)
print(f"The sum is {result}")

#5. Multiple Return Values
def rectangle_properties(length, width):
    area = length * width
    perimeter = 2 * (length + width)
    return area, perimeter

area, perimeter = rectangle_properties(5, 3)
print(f"Area is {area}, Perimeter is {perimeter}")

#6. Variable-Length Arguments

# *args (Positional Arguments):
def sum_all(*numbers):
    return sum(numbers)

print(sum_all(1, 2, 3, 4, 5))

# **kwargs (Keyword Arguments):
def display_info(**details):
    for key, value in details.items():
        print(f"{key}: {value}")

display_info(name = "Alice", age = 25, location = "USA")

#7. Lambda Functions
square = lambda x: x**2
print(square(4))

# Example in Sorting:
students = [("Alice", 85), ("Bob", 87), ("Charlie", 95)]
students.sort(key = lambda x: x[1])
print(students)

#8. Scope of Variables

# Local Scope:
def local_scope():
    x = 10
    print(x)

local_scope()

# Global Scope:
x = 5
def modify_global():
    global x
    x += 10

modify_global()
print(x)

#9. Recursion
def factorial(n):
    if n == 1 or n == 0:
        return 1
    return n * factorial(n - 1)

print(factorial(5))

#10. Docstrings
def multiple(a, b):
    """This function multiplies two numbers together."""
    return a * b

print(multiple.__doc__)

#Practice Exercises

#1
def square(n):
    return n**2
print(square(5))

#2
def sum_list(numbers):
    return sum(numbers)

print(sum_list([1, 2, 3, 4]))

#3
def fibonacci(n):
    if n <= 1:
        return n
    return fibonacci(n - 1) + fibonacci(n - 2)

print(fibonacci(4))

#4
def is_prime(n):
    if n == 1:
        return False
    for i in range(2, (n ** 0.5) +1):
        if n % i == 0:
            return False
    return True

print(is_prime(10))
print(is_prime(7))
