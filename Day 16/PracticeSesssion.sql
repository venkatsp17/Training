use NorthWind

select * from Products

select ProductName, QuantityPerUnit from Products

select ProductName Name_Of_Product, QuantityPerUnit as Quantity_Per_Unit from Products

select ProductName 'Name Of Product', QuantityPerUnit as Quantity_Per_Unit from Products

select * from products where UnitPrice>10

--Select all the products that are out of stock
select * from Products where UnitsInStock=0

--select the products that will no more be stocked
select * from products where Discontinued =1

--Select Products that will be in clearance
select * from products where Discontinued =1 and UnitsInStock>0


--select products that are in teh range of 10 to 30
select * from products where unitprice>10 and unitprice<30
select * from products where unitprice between 10 and 30
--(or)
select * from products where unitprice>=10 and unitprice>=30




select ProductName, UnitPrice Price, UnitsInStock, (UnitPrice*UnitsInStock) "Amount worth"
from products

select ProductName, UnitPrice Price, UnitsInStock, (UnitPrice*UnitsInStock) "Amount worth"
from products where CategoryID =3

select * from products where QuantityPerUnit like '%boxes%'
select * from products where QuantityPerUnit like '__ boxes'

select sum(UnitsInStock) "Stock of products in category 3"
from Products where CategoryID =3

--Average price of products supplied by supplier 2
Select AVG(UnitPrice) "Average price of products supplied by supplier 2" from Products where SupplierID = 2

--Worth of products in order

Select sum(UnitsInStock*ReorderLevel) "Worth of products in order" from Products

--Aggr by grouping
--Get the sum of products in stock for every category
select categoryId,sum(UnitsInStock) 'Stock Available' from products
group by CategoryId

---Avg Price of Products Supplied by Each Supplier
select supplierID,avg(UnitPrice) 'Stock Available' from products
group by supplierID

select SupplierId, CategoryId, Avg(UnitPrice) Average_Price
from Products
group by CategoryId,SupplierId
having avg(UnitPrice)>15

--Select category ID and Sum of products avaible if the total number of products is 
--greater than 10

select categoryid,sum(unitsinstock) "Units in Stock" from Products group by categoryid having count(unitsinstock) > 10;

select productName,UnitPrice from products
where UnitPrice>15
order by CategoryId

Select * from Products

--Get the products sorted by the price. Fetch only those products that will be discontiued

Select ProductID, ProductName, UnitPrice from Products where Discontinued = 1 order by UnitPrice


Select CategoryID, sum(UnitPrice) from Products where Discontinued = 0 group by CategoryID order by CategoryID


--Rank the Customer by country in ascen order

Select CustomerID, Country, Rank() over(order by Country) "Rank By Country" from Customers;