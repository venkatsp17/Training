class Person:
    species = "Human"

    def __init__(self, name, age):
        self.name = name
        self.age = age

    def greet(self):
        print(f"Hello, my name is {self.name} and I am {self.age} years old.")

    @classmethod
    def get_species(cls):
        return cls.species

    @staticmethod
    def is_adult(age):
        return age >= 18


person1 = Person("Alice", 25)
print(f"{person1.name} is {person1.age} years old.")
person1.greet()
print(f"Species: {Person.get_species()}")
print(f"Is adult? {Person.is_adult(30)}")


class Date:
    def __init__(self, day=0, month=0, year=0):
        self.day = day
        self.month = month
        self.year = year

    @staticmethod
    def is_date_valid(date_as_string):
        day, month, year = map(int, date_as_string.split('-'))
        return day <= 31 and month <= 12 and year <= 3999
    
    @classmethod
    def from_string(cls, date_as_string):
        day, month, year = map(int, date_as_string.split('-'))
        return cls(day, month, year)

# Usage
date_obj = Date.from_string('11-09-2012')
is_valid = Date.is_date_valid('11-09-2012')
print(date_obj)
print(is_valid)

