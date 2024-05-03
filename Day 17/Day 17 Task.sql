use pubs;


--1) Print the storeid and number of orders for the store
select stor_id "Store ID", count(*) "Number of Orders" from sales where stor_id in (select stor_id from stores) group by stor_id

--2) print the numebr of orders for every title
select title "Title", count(*) "Number of Orders" from sales join titles on sales.title_id= titles.title_id group by title

--3) print the publisher name and book name
select title "Book Name", pub_name from titles join publishers on titles.pub_id = publishers.pub_id

--4) Print the author full name for al the authors
select au_fname + ' ' + au_lname as "Author Name" from authors;

--5) Print the price or every book with tax (price+price*12.36/100)
select title "Book Name", price "Price", (price+((price*12.36)/100)) as "Price with Tax" from titles

--6) Print the author name, title name
select au_fname + ' ' + au_lname as "Author Name", title as "Title Name" from titleauthor ta join authors a on ta.au_id = a.au_id join titles t on t.title_id = ta.title_id

--7) print the author name, title name and the publisher name
select au_fname + ' ' + au_lname as "Author Name", title as "Title Name", pub_name as "Publisher Name" from titleauthor ta join authors a on ta.au_id = a.au_id join titles t on t.title_id = ta.title_id join publishers p on t.pub_id = p.pub_id


--8) Print the average price of books pulished by every publicher
select pub_name as "Publisher Name", avg(price) as "Average Price"  from titles t join publishers p on p.pub_id = t.pub_id group by pub_name


--9) print the books published by 'Marjorie'
select t.* from titles t join titleauthor ta on t.title_id = ta.title_id join authors a on ta.au_id = a.au_id where a.au_fname = 'Marjorie'

--10) Print the order numbers of books published by 'New Moon Books'
select ord_num from sales s join titles t on s.title_id = t.title_id join publishers p on t.pub_id = p.pub_id where p.pub_name = 'New Moon Books'

--11) Print the number of orders for every publisher
select pub_name Publisher_Name, count(s.ord_num) as "Number of Orders" from sales s join titles t on s.title_id = t.title_id join publishers p on t.pub_id = p.pub_id group by pub_name

--12) print the order number , book name, quantity, price and the total price for all orders
select s.ord_num as "Order Number", t.title as Title, s.qty as Quantity, t.price as Price, (t.price*s.qty) as "Total Price" from sales s join titles t on s.title_id = t.title_id

--13) print he total order quantity fro every book
select t.title Title, sum(s.qty) "Total Order Quantity" from sales s join titles t on t.title_id = s.title_id group by t.title

--14) print the total ordervalue for every book
select t.title Title, sum(s.qty*t.price) "Order Value For Every Book" from sales s join titles t on t.title_id = s.title_id group by t.title

--15) print the orders that are for the books published by the publisher for which 'Paolo' works for
select s.*,t.title as Title from sales s join titles t on s.title_id = t.title_id join employee e on t.pub_id = e.pub_id where e.fname = 'Paolo'