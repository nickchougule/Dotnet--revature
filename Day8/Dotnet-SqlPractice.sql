CREATE DATABASE CompanyDB;

Use CompanyDB;

CREATE TABLE Departments (
    DeptId INT PRIMARY KEY AUTO_INCREMENT,
    DeptName VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Employees (
    EmpId INT PRIMARY KEY AUTO_INCREMENT,
    EmpName VARCHAR(100) NOT NULL,
    Email VARCHAR(150) UNIQUE,
    Salary DECIMAL(10,2),
    DeptId INT,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (DeptId) REFERENCES Departments(DeptId)
);

CREATE TABLE Customers (
    CustomerId INT PRIMARY KEY AUTO_INCREMENT,
    CustomerName VARCHAR(100) NOT NULL,
    Email VARCHAR(150) UNIQUE,
    Phone VARCHAR(15),
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE Products (
    ProductId INT PRIMARY KEY AUTO_INCREMENT,
    ProductName VARCHAR(150) NOT NULL,
    Price DECIMAL(10,2),
    Stock INT
);

CREATE TABLE Orders (
    OrderId INT PRIMARY KEY AUTO_INCREMENT,
    CustomerId INT,
    OrderDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    Status VARCHAR(20),
    FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)
);

CREATE TABLE OrderItems (
    OrderItemId INT PRIMARY KEY AUTO_INCREMENT,
    OrderId INT,
    ProductId INT,
    Quantity INT,
    Price DECIMAL(10,2),
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);

CREATE TABLE Payments (
    PaymentId INT PRIMARY KEY AUTO_INCREMENT,
    OrderId INT,
    Amount DECIMAL(10,2),
    PaymentMode VARCHAR(30),
    PaymentDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId)
);

INSERT INTO Departments (DeptName) VALUES
('HR'),
('IT'),
('Finance'),
('Sales');

INSERT INTO Employees (EmpName, Email, Salary, DeptId)
VALUES
('Rahul Sharma', 'rahul@company.com', 60000, 2),
('Amit Verma', 'amit@company.com', 75000, 3),
('Neha Singh', 'neha@company.com', 50000, 1),
('Pooja Patil', 'pooja@company.com', 65000, 4);


INSERT INTO Customers (CustomerName, Email, Phone)
VALUES
('Nikhil Chougule', 'nikhil@gmail.com', '9876543210'),
('Rohit Patil', 'rohit@gmail.com', '9876500000'),
('Sneha Kulkarni', 'sneha@gmail.com', '9123456780');

INSERT INTO Products (ProductName, Price, Stock)
VALUES
('Laptop', 75000, 20),
('Mobile', 30000, 50),
('Headphones', 2000, 200),
('Keyboard', 1500, 100);


INSERT INTO Orders (CustomerId, Status)
VALUES
(1, 'Placed'),
(2, 'Placed'),
(1, 'Shipped');

INSERT INTO OrderItems (OrderId, ProductId, Quantity, Price)
VALUES
(1, 1, 1, 75000),
(1, 3, 2, 4000),
(2, 2, 1, 30000),
(3, 4, 1, 1500);


select * from departments;
select * from Employees;

select * from customers;
select * from products;

select * from orders;
select * from OrderItems;

select * from Payments;

select EmpName , Salary from Employees;

select * from Employees Where salary>65000;

select * from Employees order by Salary desc;

select e.EmpName ,d.DeptName  
from Employees e
inner join Departments d
on e.DeptId= d.DeptId;


select c.CustomerName, o.OrderId, o.Status, O.OrderDate
From Customers c Join Orders o
on c.CustomerId= o.CustomerId;


INSERT INTO Employees (EmpName, Email, Salary, DeptId)
VALUES
(' ', 'yogesh@company.com', 60000, 2);


select * from Employees;



























