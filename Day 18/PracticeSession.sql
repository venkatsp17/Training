select * from customers where CustomerID not in (select distinct customerid from Orders)

select * from orders

select ContactName,ShipName,ShipAddress
from customers c join orders o
on c.CustomerID = o.CustomerID

select ContactName,ShipName,ShipAddress
from customers c left outer join orders o
on c.CustomerID = o.CustomerID

--Products which are never Ordered
select * from Products
select distinct(productID) from [Order Details]
select p.ProductID, p.ProductName from Products p left join [Order Details] od on p.ProductID = od.ProductID left join Orders o on od.OrderID = o.OrderID where o.OrderID is null;