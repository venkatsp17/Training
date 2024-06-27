import re

def validate_name(name):
    return bool(re.match(r'^[a-zA-Z ]+$', name))

def validate_age(age):
    return age.isdigit() and int(age) > 0

def validate_dob(dob):
    return bool(re.match(r'^\d{4}-\d{2}-\d{2}$', dob))

def validate_phone(phone):
    return bool(re.match(r'^\d{3}-\d{3}-\d{4}$', phone))

while True:
    name = input("Enter your name: ")
    if validate_name(name):
        break
    else:
        print("Invalid name format. Please enter again.")

while True:
    age = input("Enter your age: ")
    if validate_age(age):
        break
    else:
        print("Invalid age. Please enter again.")

while True:
    dob = input("Enter your date of birth (YYYY-MM-DD): ")
    if validate_dob(dob):
        break
    else:
        print("Invalid date of birth format. Please enter again.")

while True:
    phone = input("Enter your phone number (xxx-xxx-xxxx): ")
    if validate_phone(phone):
        break
    else:
        print("Invalid phone number format. Please enter again.")


print("\nDetails:")
print("Name:", name)
print("Age:", age)
print("Date of Birth:", dob)
print("Phone:", phone)
