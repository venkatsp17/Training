#Input Operations
name = input("Enter your name: ")
age = int(input("Enter your age: "))
height = float(input("Enter your height: "))


#Output Operations
print("Welcome to Python")
print("Hello, " + name + "!")
print(f"Hello, {name}!")
print("You are {} years old.".format(age))
print("You are %d cm tall." % height)

# Primary Data Types

# Numeric Types: int, float, complex
a = 5
b = -10
c = 3.14
d = -2.5
e = 2 + 3j
f = -1 - 5j
print(a,b)
print(c,d)
print(e,f)
print('-----------------------------------------------------------------')
print('-----------------------------------------------------------------')
print('-----------------------------------------------------------------')
# Sequence Types: str, list, tuple
g = "Hello, World!"
h = 'Python'
print(g,h)
print('-----------------------------------------------------------------')
print('-----------------------------------------------------------------')
print('-----------------------------------------------------------------')
# list (mutable)
i = [1, 2, 3, 4, 5]
j = ["apple", "banana", "cherry"]
j.append(8)
i.extend(['apple', 'kiwi'])
j.insert(2, 'new')
j.remove("cherry")
i.pop()
print(i[0])
print(j[1])
print(i)
print(j)
i.clear()
print(i)
i = [1, 2, 3, 4, 5]
i.sort()
print(i)
j.reverse()
print(j)
print('-----------------------------------------------------------------')
print('-----------------------------------------------------------------')
print('-----------------------------------------------------------------')
# tuple (immutable)
k = (1, 2, 3, 4, 5)
l = ("apple", "banana", "cherry")
count_of_2 = k.count(2)
index_of_3 = l.index("apple")
length = len(k)
sorted_list = sorted(k)
total = sum(k)
smallest = min(k)
largest = max(k)
print(length)
print(index_of_3)
print(count_of_2)
print(sorted_list)
print(total)
print(smallest)
print(largest)
new_tuple = tuple([1, 2, 3])
concatenated_tuple = new_tuple + (5, 6)
print(concatenated_tuple)
print('-----------------------------------------------------------------')
print('-----------------------------------------------------------------')
print('-----------------------------------------------------------------')
# Set Types: set, frozenset
o = frozenset([1, 2, 3, 4, 5])
p = frozenset(["apple", "banana", "cherry"])
# Mapping Types: dict
q = {"name": "Alice", "age": 30}
r = {"fruit": "apple", "color": "red"}
# Boolean Type: bool
s = True
t = False
# Binary Types: bytes, bytearray, memoryview
u = b'hello'
v = bytearray(b'hello')
w = memoryview(b'hello')
print(u)
print(v)
print(w)