--Create a database
create database dbEmployeeTracker
--select the databse fro query
use dbEmployeeTracker --Create a database


--delete databse
use master
go
drop database dbEmployeeTracker

--Create table
create Table Areas
(Area varchar(20),
Zipcode char(5))

select * from Areas

sp_help Areas

alter table Areas
alter column Area varchar(20) not null
alter table Areas
add constraint pk_Area primary key(Area)

create table Skills(
Skill_id int constraint pk_skill primary key,
Skill varchar(20),
SkillDescription varchar(100))

alter table Skills
drop constraint pk_skill

alter table Skills
drop column Skill_id

alter table Skills add Skill_id int identity(1,1) constraint pk_skill primary key
 
sp_help Skills

create table Employees
(id int identity(101,1) constraint pk_EmployeeId primary key,
name varchar(100) ,
DateOfBirth datetime constraint chk_DOB Check(DateOfBirth<Getdate()),
EmployeeArea varchar(20) constraint fk_Area references Areas(Area),
Phone varchar(15),
email varchar(100) not null)

sp_help Employees

create table EmployeeSkill
(Employee_id int constraint fk_skill_eid foreign key references Employees(id),
Skill int constraint fk_Skill_EmplSkill foreign key references Skills(skill_id),
skillLevel float constraint chk_skilllevel check(skillLevel>=0),
constraint pk_employee_skill primary key(EMployee_id,Skill))


sp_help EmployeeSkill


--DML--
Insert into Areas(Area,Zipcode) values('DDDD','12345')
Insert into Areas(Zipcode,Area) values('12333','FFFF')
insert into Areas values('HHHH','12222')

select * from Areas

Insert into Skills(Skill,SkillDescription) values('C','PLT')
Insert into Skills(Skill,SkillDescription) values('C++','OOPS')
Insert into Skills(Skill,SkillDescription) values('SQL','DATABASE')

select * from Skills

--Foreign Key insert
insert into Employees(name,DateOfBirth,EmployeeArea,Phone,Email)
Values('Ramu','2000-12-12','DDDD','9876543210','ramu@gmail.com')
insert into Employees(name,DateOfBirth,EmployeeArea,Phone,Email)
Values('Somu','2001-05-01','FFFF','9988776655','somu@gmail.com')

select * from Employees

--Employee Skill- Composite key

Insert into EmployeeSkill values(101,3,8)

select * from EmployeeSkill