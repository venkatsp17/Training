//Encapsulation
class Person {
    constructor(name, age) {
        this._name = name;
        this._age = age;
    }
    //Abstraction
    get name() {
        return this._name;
    }

    get age() {
        return this._age;
    }

    introduce() {
        return `Hello, my name is ${this._name} and I am ${this._age} years old.`;
    }
}
//Inheritance
class Student extends Person {
    constructor(name, age, grade) {
        super(name, age); 
        this._grade = grade;
    }


    get grade() {
        return this._grade;
    }

    //Polymorphism
    introduce() {
        return `${super.introduce()} I am in grade ${this._grade}.`;
    }
}


let student1 = new Student("John Doe", 15, 10);


console.log(student1.introduce()); 
