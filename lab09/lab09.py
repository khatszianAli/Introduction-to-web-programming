# Lab 9
# Error Handling and Debugging

#1 Exceptions

x = 0
print(10/x)

#2 Common Built-in Exceptions

# ZeroDivisionError:
print(10/0)

# ValueError:
x = int("abc")

# IndexError:
lst = [1, 2, 3]
print(lst[5])

# KeyError:
my_dict = {'a': 1, 'b': 2, 'c': 3}
print(my_dict['k'])

# TypeError:
print("2" + 2)

# FileNotFoundError:
open("non_exist_file.txt")

#3. Exception Handling Using try and except
try:
    x = int(input("Enter a number: "))
    print(10/x)
except ZeroDivisionError:
    print("You can't divide by zero")
except ValueError:
    print("Please enter valid integer number")

#4. Handling Multiple Exceptions
try:
    x = int(input("Enter a number: "))
    print(10/x)
except (ZeroDivisionError, ValueError):
    print("Error: Invalid operation.")

#5. Using else in Exception Handling

try:
    x = int(input("Enter a number: "))
    result = 10/x
except ZeroDivisionError:
    print("You can't divide by zero")
except ValueError:
    print("Please enter valid integer number")
else:
    print(result)

#6. Using finally
try:
    file = open("example.txt")
    content = file.read()
except FileNotFoundError:
    print("File not found")
finally:
    print("Closing file")
    file.close()

#7. Raising Exceptions

# Raising a Built-in Exception
def withdrow(amount, balance):
    if amount > balance:
        raise ValueError("Amount can't be greater than balance")
    return balance - amount

try:
    new_balance = withdrow(200, 100)
except ValueError as e:
    print(f"Error: {e}")

# Raising NotImplementedError
class Shape:
    def area(self):
        raise NotImplementedError("You must implement this method")

#8. Custom Exceptions

class NegativeNumberException(Exception):
    def __init__(self, message = "Negative Number are not allowed"):
        self.message = message
        super().__init__(self.message)

def square_root(x):
    if x < 0:
        raise NegativeNumberException("Cannot compute the square root of negative number")
    else:
        return x ** 2


try:
    result = square_root(-5)
except NegativeNumberException as e:
    print(f"Error: {e}")

#9. Debugging in Python

#Using Print Statements:
def add(a, b):
    print(f"a: {a}, b: {b}")
    return a + b

print(add(1, 2))

#Using Assertions:
def divide(a, b):
    assert b != 0, "Cannot divide by zero"
    return a / b

print(divide(10, 0))