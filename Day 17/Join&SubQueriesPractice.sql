use NorthWinds;

select * from Categories

select CategoryId from Categories where CategoryName = 'Confections'

--All the products from 'Confections'
select * from products where CategoryID = 
(select CategoryId from Categories where CategoryName = 'Confections')

select * from Suppliers
--select product names from the supplier Tokyo Traders

Select ProductName from products where SupplierID = (Select SupplierID from Suppliers where CompanyName = 'Tokyo Traders')

--get all the products that are supplied by suppliers from USA
select ProductName from products where SupplierID in 
(select SupplierID from Suppliers where Country = 'USA')

--get all the products from the category that has 'ea' in the description
select * from products where CategoryID in 
(select CategoryID from Categories where Description like '%ea%')

select * from products where CategoryID in
(select CategoryID from Categories where Description like '%ea%')
and SupplierID = 
(select SupplierID from Suppliers where CompanyName = 'Tokyo Traders')

select * from customers
--select the product id and the quantity ordered by customrs from France
Select ProductID, Quantity From [Order Details] where OrderID in (select OrderID from Orders where ShipCountry = 'France')
Select ProductID, Quantity From [Order Details] where OrderID in (select OrderID from Orders where CustomerID in (select CustomerID From Customers where Country = 'France')) 

--Get the products that are priced above the average price of all the products
Select * from Products where UnitPrice > (select avg(UnitPrice) from Products);

--Select the lastet order by every employee
--select * from Orders where orderdate in 
--(select distinct Max(OrderDate) from orders group by Employeeid)
select * from orders o1
where orderdate = 
(select max(orderdate) from orders o2
where o2.EmployeeID = o1.employeeid)
order by o1.EmployeeID

--Select the maximum priced product in every category
select * from Products p1 where UnitPrice = (select max(UnitPrice) from Products p2 where p1.CategoryID = p2.CategoryID)

select * from orders

--select the order number for the maximum fright paid by every customer
Select OrderID, Freight from Orders o1 where Freight = (select max(Freight) from Orders o2 where o1.CustomerID = o2.CustomerID)

--cross join
Select * from Categories, Customers

--Inner join
select * from categories where CategoryID 
not in (select distinct categoryid from products)

select * from Suppliers where SupplierID 
not in (select distinct SupplierID from products)

--Get teh categoryId and teh productname
select CategoryId,ProductName from products

--Get teh categoryname and the productname
select categoryName,ProductName from Categories 
join Products on Categories.CategoryID = Products.CategoryID

--Get the Supplier company name, contact person name, Product name and the stock ordered
select CompanyName, ContactName, ProductName, UnitsOnOrder from Suppliers join Products on Suppliers.SupplierID = Products.SupplierID

 --Print the order id, customername and the fright cost for all teh orders
 Select OrderID, CompanyName, Freight from Orders o join Customers c on o.CustomerID = c.CustomerID

  --product name, quantity sold, Discount Price, Order Id, Fright for all orders
 select o.OrderID "Order ID",p.Productname, od.Quantity "Quantity Sold",
 (p.UnitPrice*od.Quantity) "Base Price", 
 ((p.UnitPrice*od.Quantity)-((p.UnitPrice*od.Quantity)* od.Discount/100)) "Discounted price",
 Freight "Freight Charge"
 from Orders o join [Order Details] od
 on o.OrderID = od.OrderID
 join Products p on p.ProductID = od.ProductID
 order by o.OrderID

  --select customer name, product name, quantity sold and the frieght, 
 --total price(unitpice*quantity+freight)


select c.ContactName, p.ProductName, od.Quantity, o.Freight, (p.UnitPrice * od.Quantity + o.Freight) "Total Price" from Customers c join orders o on c.CustomerID = o.CustomerID join [Order Details] od on od.OrderID = o.OrderID join Products p on p.ProductID = od.ProductID

 --Print the product name and the total quantity sold
 select productName,sum(quantity) "Total quantity sold"
 from products p join [Order Details] od
 on p.ProductID = od.ProductID
 group by ProductName
 order by 2 desc

 --customer name, number of products brought for every product
 select o.OrderID, c.ContactName, count(ProductID) "No of Products" from [Order Details] od join Orders o on od.OrderID = o.OrderID join Customers c on o.CustomerID = c.CustomerID group by o.OrderID, c.ContactName

 --Select Employee Name, Customer Name, and total price of product
select e.FirstName "Employee Name", c.CompanyName "Customer Name", (p.UnitPrice*od.Quantity) "Total Price" from Orders o join [Order Details] od on o.OrderID = od.OrderID join Customers c on c.CustomerID = o.CustomerID  join Employees e on o.EmployeeID = e.EmployeeID join Products p on p.ProductID = od.ProductID