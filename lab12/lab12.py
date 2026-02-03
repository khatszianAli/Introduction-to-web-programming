#Lab 12
#Object-Oriented Programming (OOP) in Python

#Creating a Class and Object in Python
class Car:
    def __init__(self, brand, model, year):
        self.brand = brand
        self.model = model
        self.year = year

    def display_info(self):
        return f"{self.brand} {self.model} ({self.year})"

car1 = Car("BMW", "X5", "2024")
car2 = Car("Toyota", "Camry", "2021")

print(car1.display_info())
print(car2.display_info())

#Methods in Classes
class Dog:
    def __init__(self, name, breed):
        self.name = name
        self.breed = breed

    def bark(self):
        return f"{self.name} says Woof!"

dog = Dog("Bob", "Golden Retriever")
print(dog.bark())

#Modifying Object Attributes
class Phone:
    def __init__(self, brand, price):
        self.brand = brand
        self.price = price

phone1 = Phone("iPhone 13", 35000)
print(phone1.price)

phone1.price = 32000
print(phone1.price)

#Using the self Keyword
class Calculator:
    def __init__(self, value):
        self.value = value

    def add(self, num):
        self.value += num

    def get_value(self):
        return self.value

calc = Calculator(100)
calc.add(10)
print(calc.get_value())

#Deleting Object Attributes or Objects
class User:
    def __init__(self, username, email):
        self.username = username
        self.email = email

user1 = User("admin", "admin@gmail.com")
print(user1.email)

del user1.email

del user1

#Advanced OOP Concepts

#Encapsulation
class BankAccount:
    def __init__(self, owner, balance):
        self.owner = owner
        self.__balance = balance

    def deposit(self, amount):
        if amount > 0:
            self.__balance += amount
            return f"Deposit {amount} Amount"

    def withdraw(self, amount):
        if 0 < amount <= self.__balance:
            self.__balance -= amount
            return f"Withdraw {amount} Amount"
        else:
            return f"Incorrect Amount"

    def get_balance(self):
        return self.__balance


account = BankAccount("alice", 1000)
account.deposit(100)
account.withdraw(50)
print(account.get_balance())

#Inheritance
class Animal:
    def __init__(self, name):
        self.name = name

    def make_sound(self):
        return "Some sound"

class Dog(Animal):
    def make_sound(self):
        return "Woof"

class Cat(Animal):
    def make_sound(self):
        return "Meow"

dog = Dog("Buddy")
cat = Cat("Whiskers")

print(f"{dog.name} says {dog.make_sound()}")
print(f"{cat.name} says {cat.make_sound()}")

#Polymorphism
class Bird:
    def fly(self):
        return "Flying high!"

class Airplane:
    def fly(self):
        return "Taking off into the sky!"

class Fish:
    def fly(self):
        return "I cann't fly!"


for obj in [Bird, Airplane, Fish]:
    print(obj.fly())

#Abstraction
from abc import ABC, abstractmethod

class Vehicle(ABC):
    @abstractmethod
    def start_engine(self):
        pass

class Car:
    def start_engine(self):
        print("Car engine started!")

class Bike:
    def start_engine(self):
        print("Bike engine started!")

car = Car()
bike = Bike()
car.start_engine()
bike.start_engine()

