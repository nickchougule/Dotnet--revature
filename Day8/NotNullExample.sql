create database CollegeData;

use CollegeData;

CREATE TABLE Students (
    studentId INT PRIMARY KEY,
    firstName VARCHAR(50),
    lastName VARCHAR(50)
);


INSERT INTO Students (studentId, firstName, lastName) VALUES
(1, 'Nikhil', 'Chougule'),
(2, NULL, 'Patil'),
(3, 'Rahul', NULL),
(4, '', 'Mishra'),
(5, NULL, NULL);

select * from Students;


SET SQL_SAFE_UPDATES = 0;

UPDATE Students
SET firstName = 'Unknown'
WHERE firstName IS NULL OR firstName = '';

UPDATE Students
SET lastName = 'Unknown'
WHERE lastName IS NULL OR lastName = '';

SET SQL_SAFE_UPDATES=1;

select * from Students;

INSERT INTO Students VALUES (6, NULL, 'Test');




delete from Students where studentId=6;

ALTER TABLE Students
MODIFY firstName VARCHAR(50) NOT NULL;












