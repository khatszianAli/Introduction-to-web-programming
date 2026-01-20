#Control Flow: Conditions in Python

#1. if Statement
age = 18
if age >= 18:
    print("You can come in")

#2. else Statement
age = 16
if age >= 18:
    print("You can come in")
else:
    print("You can not come in")

#3. elif (else if) Statement
age = 16
if age > 18:
    print("You can come in")
elif age == 18:
    print("We should check you passport")
else:
    print("You can not come in")

#4. Nested if Statements
age = 20
has_ticket = True

if age >= 18:
    if has_ticket:
        print("You can come in")
    else:
        print("You can not come in without the ticket")
else:
    print("You can not come in because of age")

#5. Conditional Expressions (Ternary Operator)
age = 16
result = "You can drive" if age >= 18 else "You can not drive"
print(result)

#6. Combining Conditions
age = 20
has_ticket = True

if age >= 18 and has_ticket:
    print("You can come in")
else:
    print("You can not come")

#Control Flow: Loops in Python

#1. for Loop
fruits = ["apple", "banana", "cherry"]
for fruit in fruits:
    print(fruit)

# Using range() with for Loop:
for i in range(5):
    print(i)

# Custom Ranges:

for i in range(1, 10, 2):
    print(i)

#2. while Loop
i = 1
while i <= 5:
    print(i)
    i+=1

#3. break Statement
for i in range(10):
    if i == 5:
        break
    print(i)

#4. continue Statement
for i in range(5):
    if i == 2:
        continue
    print(i)

#5. else Clause with Loops
for i in range(5):
    print(i)
else:
    print("Loop is completed")

#6. Nested Loops
for i in range(3):
    for j in range(2):
        print(f"i={i}, j={j}")

#7. Infinite Loops
while True:
    print("This will run forever")
    break

#Practice Exercise

#1
i = 1
for i in range(10):
    print(i)

i = 1
while i <= 10:
    print(i)
    i += 1

#2
for i in "Python":
    print(i)

#3
i = 2
while i <= 10:
    print(i)
    i += 2