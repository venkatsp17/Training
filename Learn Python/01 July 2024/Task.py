# 1) Create a application that will take the Employee details(Name, DOB, Phone and E-Mail) from console, validate it and calculate age(Age should not taken from user)
#    The application should show menu to store the same in file. Option for saving should be text/excel/pdf. 
#    Optional implementation - > Bulk read and store in list from Excel file


import datetime
import re
import pandas as pd
from reportlab.lib.pagesizes import letter
from reportlab.pdfgen import canvas


def validate_email(email):
    return re.match(r"[^@]+@[^@]+\.[^@]+", email)


def validate_phone(phone):
    return re.match(r"\d{10}", phone)


def calculate_age(dob):
    today = datetime.date.today()
    age = today.year - dob.year - ((today.month, today.day) < (dob.month, dob.day))
    return age


def save_to_text(details):
    with open('employee_details.txt', 'a') as file:
        file.write(f"{details}\n")


def save_to_excel(details):
    df = pd.DataFrame([details])
    df.to_excel('employee_details.xlsx', index=False, header=False)


def save_to_pdf(details):
    c = canvas.Canvas('employee_details.pdf', pagesize=letter)
    c.drawString(100, 750, details)
    c.save()


while True:

    name = input("Enter employee's name: ")
    dob_input = input("Enter employee's DOB (YYYY-MM-DD): ")
    phone = input("Enter employee's phone number: ")
    email = input("Enter employee's email: ")


    dob = datetime.datetime.strptime(dob_input, '%Y-%m-%d').date()
    if not (validate_email(email) and validate_phone(phone)):
        print("Invalid email or phone number. Please try again.")
        continue


    age = calculate_age(dob)


    details = f"Name: {name}, Age: {age}, Phone: {phone}, Email: {email}"


    print("Choose the file format to save the details:")
    print("1. Text\n2. Excel\n3. PDF")
    choice = input("Enter your choice (1/2/3): ")

    if choice == '1':
        save_to_text(details)
    elif choice == '2':
        save_to_excel(details)
    elif choice == '3':
        save_to_pdf(details)
    else:
        print("Invalid choice. Please try again.")


    continue_choice = input("Do you want to enter another employee's details? (yes/no): ")
    if continue_choice.lower() != 'yes':
        break

print("Application ended. Thank you!")
