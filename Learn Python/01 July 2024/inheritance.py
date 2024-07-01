class Parent:
    def __init__(self):
        self.value = "Inside Parent"

    def show(self):
        print(self.value)

class Child(Parent):
    def __init__(self):
        super().__init__()
        self.value = "Inside Child"

    def display(self):
        print(self.value)


parent_obj = Parent()
parent_obj.show()  

child_obj = Child()
child_obj.show()    
child_obj.display() 
