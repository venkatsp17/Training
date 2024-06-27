name = input("Enter your name: ")
gender = input("Enter your gender: ")


if gender == 'Male':
    print(f"Hello, Mr {name}!")
elif gender == 'Female':
    print(f"Hello, Ms {name}!")
elif gender == 'Trans':
    print(f"Hello, Mx {name}!")