create table Books
(
    Id serial primary key,
    Title varchar(150),
    Description text,
    Access bool
);

create table Categories
(
    Id serial primary key,
    CategoryName varchar(200)
);

create table Authors
(
    Id serial primary key,
    FullName varchar(150),
    Age int
);

create table Books_Categories  
(
    BookId int references Books(Id),
    CategoryId int references Categories(Id)
);

create table Books_Author  
(
    BookId int references Books(Id),
    AuthorId int references Authors(Id)
);

