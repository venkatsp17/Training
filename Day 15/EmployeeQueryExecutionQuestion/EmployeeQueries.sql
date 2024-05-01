---DDL QUERIES
---EMPLOYEE TABLE
CREATE TABLE DEPARTMENT (
    Department_Name VARCHAR(255) CONSTRAINT pk_DepartmentName PRIMARY KEY,
    Floor INT,
    Phone VARCHAR(20),
   
);

 ---Employee_No INT NOT NULL CONSTRAINT fk_EmployeeNo REFERENCES EMPLOYEE(Employee_No),
CREATE TABLE EMPLOYEE (
    Employee_No int constraint pk_EmployeeNo PRIMARY KEY,
    Employee_Name VARCHAR(255),
    Salary DECIMAL(10, 2),
    Department_Name VARCHAR(255) constraint fk_DepatmentName REFERENCES DEPARTMENT(Department_Name),
    Boss_No INT REFERENCES EMPLOYEE(Employee_No)
);

ALTER TABLE DEPARTMENT ADD Employee_No INT NOT NULL CONSTRAINT fk_EmployeeNo REFERENCES EMPLOYEE(Employee_No)

CREATE TABLE ITEM (
    Item_Name VARCHAR(255) CONSTRAINT pk_ItemName PRIMARY KEY,
    Item_Type VARCHAR(100),
    Item_Color VARCHAR(100)
);

CREATE TABLE SALES (
    Sales_No INT CONSTRAINT pk_SalesNo PRIMARY KEY,
    Sales_Quantity INT,
    Item_Name VARCHAR(255) NOT NULL CONSTRAINT fk_ItemName REFERENCES ITEM(Item_Name),
    Department_Name VARCHAR(255) NOT NULL CONSTRAINT fk_DeptName REFERENCES DEPARTMENT(Department_Name),
);


sp_help DEPARTMENT

sp_help EMPLOYEE

sp_help ITEM

sp_help SALES


---DML QUERIES
ALTER TABLE EMPLOYEE NOCHECK CONSTRAINT fk_DepatmentName;

INSERT INTO EMPLOYEE (Employee_No, Employee_Name, Salary, Department_Name, Boss_No) VALUES
(1, 'Alice', 75000, 'Management', NULL),
(2, 'Ned', 45000, 'Marketing', 1),
(3, 'Andrew', 25000, 'Marketing', 2),
(4, 'Clare', 22000, 'Marketing', 2),
(5, 'Todd', 38000, 'Accounting', 1),
(6, 'Nancy', 22000, 'Accounting', 5),
(7, 'Brier', 43000, 'Purchasing', 1),
(8, 'Sarah', 56000, 'Purchasing', 7),
(9, 'Sophie', 35000, 'Personnel', 1),
(10, 'Sanjay', 15000, 'Navigation', 3),
(11, 'Rita', 15000, 'Books', 4),
(12, 'Gigi', 16000, 'Clothes', 4),
(13, 'Maggie', 11000, 'Clothes', 4),
(14, 'Paul', 15000, 'Equipment', 3),
(15, 'James', 15000, 'Equipment', 3),
(16, 'Pat', 15000, 'Furniture', 3),
(17, 'Mark', 15000, 'Recreation', 3);


SELECT * FROM EMPLOYEE


INSERT INTO DEPARTMENT (Department_Name, Floor, Phone, Employee_No) VALUES
('Management', 5, '34', 1),
('Books', 1, '81', 4),
('Clothes', 2, '24', 4),
('Equipment', 3, '57', 3),
('Furniture', 4, '14', 3),
('Navigation', 1, '41', 3),
('Recreation', 2, '29', 4),
('Accounting', 5, '35', 5),
('Purchasing', 5, '36', 7),
('Personnel', 5, '37', 9),
('Marketing', 5, '38', 2)

SELECT * FROM DEPARTMENT


ALTER TABLE EMPLOYEE WITH CHECK CHECK CONSTRAINT fk_DepatmentName;



INSERT INTO ITEM (Item_Name, Item_Type, Item_Color) VALUES
('Pocket Knife-Nile', 'E', 'Brown'),
('Pocket Knife-Avon', 'E', 'Brown'),
('Compass', 'N', NULL),
('Geo positioning system', 'N', NULL),
('Elephant Polo stick', 'R', 'Bamboo'),
('Camel Saddle', 'R', 'Brown'),
('Sextant', 'N', NULL),
('Map Measure', 'N', NULL),
('Boots-snake proof', 'C', 'Green'),
('Pith Helmet', 'C', 'Khaki'),
('Hat-polar Explorer', 'C', 'White'),
('Exploring in 10 Easy Lessons', 'B', NULL),
('Hammock', 'F', 'Khaki'),
('How to win Foreign Friends', 'B', NULL),
('Map case', 'E', 'Brown'),
('Safari Chair', 'F', 'Khaki'),
('Safari cooking kit', 'F', 'Khaki'),
('Stetson', 'C', 'Black'),
('Tent - 2 person', 'F', 'Khaki'),
('Tent -8 person', 'F', 'Khaki');



SELECT * FROM ITEM


INSERT INTO SALES (Sales_No, Sales_Quantity, Item_Name, Department_Name) VALUES
(101, 2, 'Boots-snake proof', 'Clothes'),
(102, 1, 'Pith Helmet', 'Clothes'),
(103, 1, 'Sextant', 'Navigation'),
(104, 3, 'Hat-polar Explorer', 'Clothes'),
(105, 5, 'Pith Helmet', 'Equipment'),
(106, 2, 'Pocket Knife-Nile', 'Clothes'),
(107, 3, 'Pocket Knife-Nile', 'Recreation'),
(108, 1, 'Compass', 'Navigation'),
(109, 2, 'Geo positioning system', 'Navigation'),
(110, 5, 'Map Measure', 'Navigation'),
(111, 1, 'Geo positioning system', 'Books'),
(112, 1, 'Sextant', 'Books'),
(113, 3, 'Pocket Knife-Nile', 'Books'),
(114, 1, 'Pocket Knife-Nile', 'Navigation'),
(115, 1, 'Pocket Knife-Nile', 'Equipment'),
(116, 1, 'Sextant', 'Clothes'),
(121, 1, 'Exploring in 10 easy lessons', 'Books'),
(125, 1, 'Elephant Polo stick', 'Recreation'),
(126, 1, 'Camel Saddle', 'Recreation')

SELECT * FROM SALES