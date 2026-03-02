create database Assignment
use Assignment


create table employee(
e_id int not null,
e_name varchar(50),
e_salary int,
e_age int,
e_gender varchar(20),
e_dept varchar(20),
primary key(e_id)
);


select * from employee;


insert into employee values(
1,'Soham',50000,23,'Male','IT'
);

INSERT INTO employees
('e_id', 'e_age')
VALUES
(1,'25'
);

INSERT INTO employee VALUES
(2,'Nikhil',50000,23,'Male','IT'),
(3,'',50000,25,'Male','IT'),
(4,'',50000,22,'Male','IT'),
(5,'Yogesh',50000,24,'Male','IT');



Select * 
From employee
Where e_name is Not Null;



UPDATE employee
SET e_name = 'vishal'
WHERE e_id=3;



UPDATE employee
SET e_name = 'Yogesh'
WHERE e_id=4;
--WHERE e_name IS NULL;
--OR LTRIM(RTRIM(e_name)) = '';


/*
Alter Table employee
Alter Column e_name Varchar(50) Not Null;
*/

/*
insert into employee values(
6,'',50000,23,'Male','IT'
)
*/

/*
INSERT INTO employee
VALUES (7, NULL, 50000, 23, 'Male', 'IT');
*/


Select * from employee;

CREATE TABLE department (
    dept_id INT PRIMARY KEY,
    dept_name VARCHAR(50) NOT NULL
);
INSERT INTO department VALUES
(1,'IT'),
(2,'HR'),
(3,'Finance'),
(4,'Sales');

ALTER TABLE employee
ADD dept_id INT;

select * from department;

UPDATE employee
SET dept_id = 1
WHERE e_dept = 'IT';

ALTER TABLE employee
ADD CONSTRAINT FK_employee_dept
FOREIGN KEY (dept_id)
REFERENCES department(dept_id);

SELECT 
    e.e_name,
    e.e_salary,
    d.dept_name
FROM employee e
INNER JOIN department d
ON e.dept_id = d.dept_id;
