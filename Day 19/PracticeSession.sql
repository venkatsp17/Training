use NorthWinds;
select * from Categories

select * from Suppliers

select CategoryID,  categoryname from Categories
union
select SupplierId,CompanyName from Suppliers

select * from [Order Details]

select * from Orders where ShipCountry='Spain'
intersect
select * from Orders where Freight>50

select top 5 * from orders order by Freight desc

--get the order id, productname and quantitysold of products that have price
--greater than 15

select OrderID, ProductName, Quantity "Quantity Sold"
from [Order Details] od join Products p
on od.ProductId = p.ProductID
where p.UnitPrice>15

--get the order id, productname and quantitysold of products that are from category 'dairy'
--and within the price range of 10 to 20
SELECT OrderID, p.productname, Quantity "Quantity Sold" FROM [Order Details]
JOIN Products p ON p.ProductID = [Order Details].ProductID
JOIN Categories c ON c.CategoryID = p.CategoryID
WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%';

select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
from [Order Details] od join Products p
on od.ProductId = p.ProductID
where p.UnitPrice>15
union
SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
JOIN Products p ON p.ProductID = [Order Details].ProductID
JOIN Categories c ON c.CategoryID = p.CategoryID
WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%'
order by p.unitprice desc

--CTE

with OrderDetails_CTE(OrderID,ProductName,Quantity,Price)
as
(select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
from [Order Details] od join Products p
on od.ProductId = p.ProductID
where p.UnitPrice>15
union
SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
JOIN Products p ON p.ProductID = [Order Details].ProductID
JOIN Categories c ON c.CategoryID = p.CategoryID
WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%')

select top 10 * from  OrderDetails_CTE order by price desc


CREATE VIEW vwOrderDetails
AS
(
    SELECT OrderID, ProductName, Quantity AS QuantitySold, p.UnitPrice AS Price
    FROM [Order Details] od
    JOIN Products p ON od.ProductId = p.ProductID
    WHERE p.UnitPrice > 15

    UNION

    SELECT OrderID, p.productname, Quantity AS QuantitySold, p.UnitPrice AS Price
    FROM [Order Details]
    JOIN Products p ON p.ProductID = [Order Details].ProductID
    JOIN Categories c ON c.CategoryID = p.CategoryID
    WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%'
);

-- Ensure that the view has been created successfully before executing the SELECT statement
GO

SELECT * FROM vwOrderDetails ORDER BY Price;



with OrderDetails_CTE(OrderID, CustomerName, ProductName)
as
(select o.OrderID, c.CompanyName, p.ProductName FROM 
Orders o join [Order Details] od on o.OrderID = od.OrderID 
join Customers c on c.CustomerID =o.CustomerID 
join Products p on p.ProductID = od.ProductID
where o.ShipCountry = 'USA'
UNION
select o.OrderID, c.CompanyName, p.ProductName FROM 
Orders o join [Order Details] od on o.OrderID = od.OrderID 
join Customers c on c.CustomerID =o.CustomerID 
join Products p on p.ProductID = od.ProductID
where o.ShipCountry = 'FRANCE' and o.Freight < 20)

select top(10) * from OrderDetails_CTE order by ProductName;


use master
sp_help Employees

create index idxEmpEmail on Employees(phone)

select * from employees where email like 'r%'

drop index idxEmpEmail on Employees

create procedure proc_FirstProcedure
as
begin
    print 'Hello'
end

execute proc_FirstProcedure

create proc proc_GreetWithName(@cname varchar(20))
as
begin
   print 'Hello '+@cname
end

exec proc_GreetWithName 'Meenu'


create proc proc_GreetWithNameandTime(@cname varchar(20), @time varchar(30))
as
begin
   print @time + ' ' + @cname
end

exec proc_GreetWithNameandTime 'Meenu', 'Morning'

create proc proc_AddEmployee(@ename varchar(10),@edob datetime,
@earea varchar(10), @ephone varchar(15), @eemail varchar(15))
as
begin
   insert into Employees(name,DateOfBirth,EmployeeArea,Phone,Email)
   values(@ename,@edob,@earea,@ephone,@eemail)
end

exec proc_AddEmployee 'Bimu','2000-09-07','HHHH','1122334455','bimu@gmail.com'

alter proc proc_GreetWithName(@cname varchar(20))
as
begin
   print 'Welcome '+@cname
end

Create proc proc_PrintDetails(@cname varchar(20),@cage int,@cphone varchar(15))
as
begin
   print 'Welcome '+@cname + ' and you are '+@cage +'years old, Your phone is '+@cphone
end
alter  proc proc_PrintDetails(@cname varchar(20),@cage int,@cphone varchar(15))
as
begin
   print 'Welcome '+@cname + ' and you are '+cast(@cage as varchar(3))+'years old, Your phone is '+@cphone
end

proc_PrintDetails 'Ramu',23,'8877665544'


