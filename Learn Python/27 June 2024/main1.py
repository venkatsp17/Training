#If conditions
x = 10
if x > 5:
    print("x is greater than 5")
elif x == 5:
    print("x is 5")
else:
    print("x is less than 5")
print('-----------------------------------------------------------------')
print('-----------------------------------------------------------------')
print('-----------------------------------------------------------------')

#For Loop
for i in range(5):
    print(i)
print('-----------------------------------------------------------------')
print('-----------------------------------------------------------------')
print('-----------------------------------------------------------------')

#While Loop
count = 0
while count < 5:
    print(count)
    count += 1
print('-----------------------------------------------------------------')
print('-----------------------------------------------------------------')
print('-----------------------------------------------------------------')


#Method
def greet(name):
    return "Hello, " + name + "!"


message = greet("Alice")
print(message)
