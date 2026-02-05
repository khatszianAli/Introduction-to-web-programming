#Lab 14
#Working with Dates and Times in Python (datetime Module)

#1. Getting the Current Date and Time
from datetime import datetime

current = datetime.now()
print("Current date and time:", current)

#2. Extracting Specific Parts of a Date
print("Year: ", current.year)
print("Month: ", current.month)
print("Day: ", current.day)
print("Hour: ", current.hour)
print("Minute: ", current.minute)
print("Second: ", current.second)

#3. Creating a Specific Date and Time
specific_time = datetime(2005, 11, 11, 7, 00, 0)
print("Specific time: ",specific_time)

#4. Formatting Dates and Times (strftime)
formatted_time = datetime.strftime(specific_time, "%Y-%m-%d %H:%M:%S")
print("Formatted time: ",formatted_time)

#5. Parsing Strings into Date Objects (strptime)
date_str = "01-02-2025 14:30:45"
date_obj = datetime.strptime(date_str, "%Y-%m-%d %H:%M:%S")
print("Date: ", date_obj)

#6. Performing Date Calculations (timedelta)
from dateme import timedalta

future_date = current + timedelta(days=7)
print("Future date: ", future_date)

past_date = current - timedelta(days=3)
print("Past date: ", past_date)

#7. Finding the Difference Between Two Dates
event_date =datetime(2025, 12, 31)
days_remaining = past_date - event_date

print("Days remaining: ", days_remaining)

#Lab Exercise 1: Displaying the Current Date and Time
current_time = datetime.now()
formatted_time = datetime.strftime(current_time, "%Y-%m-%d %H:%M:%S")
print("Formatted time: ", formatted_time)

#Lab Exercise 2: Calculating the Difference Between Two Dates
current_date = datetime.now()
future_event = datetime(20206, 11, 11)
days_remaining = future_event - current_date
print("Days remaining: ", days_remaining)

#Lab Exercise 3: Implementing a Countdown Timer
import time
from datetime import datetime, timedelta
def countdown_timer(seconds) :
    end_time = datetime.now() + timedelta(seconds=seconds)
    while True:
        remaining = end_time - datetime.now()
        total_seconds = int (remaining.total_seconds ())
        if total_seconds <= 0:
            print("Time remaining: 0 seconds")
            break
        print(f"Time remaining: {total_seconds} seconds", end="\r")
        time.sleep (1)
        print("\nTimer finished!")

countdown_timer (10)

#Lab Exercise 4: Creating a Simple Month Calendar
from datetime import datetime, timedelta
7
8
9
10
11
12
13
14
15
16
17
18
19
20
21
22
23
24
25
26
27
28
29
30
31
32
33
34
35
36
37
38
def simple_month_calendar (year, month) :

    current_date = datetime (year, month, 1)
    start_weekday = current_date.weekday()

    if month == 12:
        next_month = datetime(year + 1, 1, 1)
    else:
        next_month = datetime (year, month + 1, 1)
    last_date = next_month - timedelta(days=1)

    print("Mon Tue Wed Thu Fri Sat Sun")

    print("      " * start_weekday, end="")

    while current_date <= last_date:

        print(f"{current_date.day:3}", end=" ")

        if current_date.weekday () == 6:
            print()

        current_date += timedelta(days=1)
    print()

simple_month_calendar (2025, 5)
