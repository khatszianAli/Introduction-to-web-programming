#lab 13
#Working with Regular Expressions in Python

#Search and Replace Example:
import re

text = "My phone number is 123456789 and my office number is 0987654321"
pattern = r"\d+"
replacement = "Number"

result = re.sub(pattern, replacement, text)
print(result)

#1. re.search()
import re

text = "The rain in Spain falls mainly on the plain."
pattern = r"Spain"

match = re.search(pattern, text)
if match:
    print("Found:", match.group())
else:
    print("Not found")

#2. re.match()
import re

text = "Hello, world!"
pattern = r"Hello"

match = re.match(pattern, text)
if match:
    print("Match found:", match.group())
else:
    print("Not match")

pattern = r"World"
match = re.search(pattern, text)

if match:
    print("Match found:", match.group())
else:
    print("Not match")

#3. re.findall()
import re

text = "John's number is 555-1234 , and Mary's number is 555-5678"
pattern = r"\d{3}-\d{4}"

matches = re.findall(pattern, text)
print("Phone number is found: ", matches)

#Lab Exercise 1: Finding Phone Numbers
import re

text = "Call me at number is 555-1234 , or at 555-5678"
pattern = r"\d{3}-\d{4}"

matches = re.findall(pattern, text)
print("Phone number is found: ", matches)

#Lab Exercise 2: Matching at the Start of a String
import re

text1 = "Hello, world! Welcome to regex."
text2 = "Greetings! Hello, how are you?"
pattern = r"Hello"

matches = re.match(pattern, texti)
print("Using re.match() on text1:")
if match1:
    print ("Match found:", match1.group())
else:
    print ("No match found.")

match2 = re.match(pattern, text2)
print("\nUsing re.match() on text2:")
if match2:
    print ("Match found:", match2.group())
else:
    print("No match found.")

search_result = re. search (pattern, text2)
print("\nUsing re.search() on text2:")
if search_result:
    print ("Found:", search_result.group())
else:
    print("No match found.")

#Lab Exercise 3: Replacing Numbers with a Word
import re
text = "There are 3 apples, 15 oranges, and 256 bananas in the basket."

pattern = r"\d+"

result = re.sub(pattern, "NUMBER", text)
print("Modified Text:", result)

#Lab Exercise 4: Extracting Email Addresses
import re
text = "For more info, contact us at support@example.com or sales-info@example.org."

pattern = "r\b\w+@\w+\.\w+\b'"

emails = re.findall(pattern, text)
print("Email Addresses Found:", emails)