def add(a,b):
    return a + b

def sub(a,b):
    return a-b

def multiply(a,b):
    return a*b

def all(a,b,ops):
    if ops == '+':
        return a + b
    elif ops == '-':
        return a-b
    elif ops == '*':
        return a*b
    elif ops == '/':
        return a/b
    else:
        print("Invalid operation!")
        return