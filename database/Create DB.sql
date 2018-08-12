-- Execute one statement at a time

DROP TABLE EMPLOYEE;

CREATE TABLE EMPLOYEE (
   ID 				SERIAL 	PRIMARY KEY     NOT NULL,
   REFERENCE        INT                     NOT NULL,
   LASTNAME        	VARCHAR    				NOT NULL,
   FIRSTNAME        VARCHAR    				NOT NULL,
   DATEOFBIRTH     	DATE,
   ADDRESSNUMBER	VARCHAR,
   ADDRESSSTREET     	VARCHAR,
   ADDRESSCITY     	VARCHAR,
   ADDRESSPOSTALCODE     	VARCHAR,
   ADDRESSCOUNTRY     	VARCHAR,
   JOINEDCOMPANYDATE date,
   GROSSMONTHLYSALARY         	money,
   ISGRANTEDCAR boolean,
   NBDAYSYEARLYHOLIDAYS int
);

INSERT INTO public.employee
(reference, lastname, firstname, dateofbirth, addressnumber, addressstreet, addresscity, addresspostalcode, addresscountry, joinedcompanydate, grossmonthlysalary, isgrantedcar, nbdaysyearlyholidays)
VALUES(1, 'Cooper', 'Dale', '1959-02-22', '54', 'Trees street', 'Yakima, Washington', '98908', 'USA', '2015-03-18', 3000, false, 20);