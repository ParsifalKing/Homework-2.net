create table Products
(
    Id serial primary key,
  Name varchar(60),
  Price numeric,
  DateOfCreation date
);

insert into Products(Name,Price,DateOfCreation)
values('Banana',5,'2024-02-01'),
      ('Cake',120,'2024-01-15'),
    ('Bounty',6,'2024-02-10'),
    ('Pepsi',6,'2024-02-05'),
    ('Lay''s',30,'2023-12-30'),
    ('Alpen-Gold',5,'2024-01-20'),
    ('Juice',8,'2024-02-08'),
    ('Shampoo',42,'2024-01-15'),
    ('Sausage',35,'2024-02-16'),
    ('Coca-cola',6,'2024-02-05'),
    ('Meat',75,'2024-02-22');

create table Countries
(
    Id serial primary key,
  Name varchar(50)
);

insert into Countries(Name)
values('Tajikistan'),
      ('Russia'),
    ('Uzbekiston'),
    ('Turkey'),
    ('France'),
    ('England');
    

create table Customers
(
    Id serial primary key,
  FullName varchar(100),
  Age int,
  Email varchar(200),
  CountryId int references Countries(Id)
);

insert into Customers(FullName,Age,Email,CountryId)
values('Davron Ziyoev',20,'davron@gmail.com',1),
      ('Yusufjon Mirzoev',17,'yusufjon@gmail.com',2),
    ('Mustafo Barotov',25,'mustafo@gmail.com',4),
    ('Maruf Niyazov',16,'maruf@gmail.com',3),
    ('Akmal Nazriev',30,'akmal@gmail.com',5),
    ('Mumtoz Sharipov',24,'mumtoz@gmail.com',6);

create table Orders
(
    Id serial primary key,
  Description text,
  OrderTime date,
  ProductId int references Products(Id),
  CustomerId int references Customers(Id),
  CountryId int references Countries(Id)
);

insert into Orders(Description,OrderTime,ProductId,CustomerId,CountryId)
values('Alpen-Gold','2024-01-29',1,6,6),
      ('Lays made by potatoes','2024-02-19',5,5,5),
      ('Alpen-Gold','2023-01-30',6,1,1),
      ('Coca-cola zero','2024-02-24',10,5,5),
      ('Banana is good for healthy','2024-01-28',1,3,4),
      ('The color of pepsi is black','2024-02-05',4,3,4),
      ('Banana is good for healthy','2024-02-12',1,4,3),
    ('Bounty have a coconut','2024-02-20',3,5,5),
    ('The color of pepsi is black','2024-02-05',4,1,1),
    ('Bounty have a coconut','2024-02-15',3,3,4),
    ('Lays made by potatoes','2023-10-26',5,5,5),
    ('Bounty have a coconut','2024-02-20',3,1,1),
    ('Alpen-Gold','2023-12-13',6,1,1),
    ('Limon juice','2024-02-11',7,2,2),
    ('Natural shampoo','2024-02-05',8,3,4),
    ('Apricot juice','2024-02-12',7,4,3),
    ('Sausage halal','2024-02-20',9,5,5),
    ('Natural shampoo','2024-02-05',8,1,1),
    ('Halal sausage','2024-02-15',9,3,4),
    ('Coca-cola zero','2024-02-24',10,5,5),
    ('Cows meat','2024-02-20',11,1,1),
    ('Alpen-Gold','2024-01-29',6,1,1);
    


select * from Products
select * from Customers
select * from Orders
select * from Countries



