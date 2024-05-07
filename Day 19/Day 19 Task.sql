use pubs;

--1) Create a stored procedure that will take the author firstname and print all the books polished by him with the publisher's name
Create Proc BooksPPublishedByAuthor(@authorName varchar(30))
as
Begin
	Select t.*, p.pub_name from titles t join publishers p on p.pub_id = t.pub_id join titleauthor ta on ta.title_id = t.title_id join authors a on a.au_id = ta.au_id where (a.au_fname + a.au_lname) like '%' + @authorname + '%'

End

Execute BooksPPublishedByAuthor 'White'

--2) Create a sp that will take the employee's firtname and print all the titles sold by him/her, price, quantity and the cost.
Create Proc EmployeeSoldBooks(@employeeName varchar(30))
as
Begin
	Select t.title, t.price, s.qty, (t.price*s.qty) as Cost from titles t join sales s on t.title_id = s.title_id join employee e on e.pub_id = t.pub_id where e.fname like '%' + @employeeName + '%'
End

Execute EmployeeSoldBooks 'Paolo'


--3) Create a query that will print all names from authors and employees
Select fname + ' ' + lname as Names from employee
union
Select au_fname + ' ' + au_lname from authors

--4) Create a  query that will float the data from sales,titles, publisher and authors table to print title name, Publisher's name, author's full name with quantity ordered and price for the order for all orders,
--print first 5 orders after sorting them based on the price of order
Select top(5) t.title as BookName, p.pub_name as PublisherName, a.au_fname + ' ' + a.au_lname as AuthorName, s.qty as Quantity, (t.price*s.qty) as Price from titles t join publishers p on t.pub_id = p.pub_id join titleauthor ta on ta.title_id = t.title_id join authors a on a.au_id = ta.au_id join sales s on s.title_id = t.title_id order by Price desc