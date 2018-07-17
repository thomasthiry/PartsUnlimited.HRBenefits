DROP TABLE EMPLOYEE;

CREATE TABLE EMPLOYEE (
   ID 				SERIAL 	PRIMARY KEY     NOT NULL,
   REFERENCE        INT                     NOT NULL,
   LASTNAME        	VARCHAR    				NOT NULL,
   FIRSTNAME        VARCHAR    				NOT NULL,
   DATEOFBIRTH     	DATE,
   ADDRESS_NUMBER	VARCHAR,
   ADDRESS_STREET     	VARCHAR,
   ADDRESS_CITY     	VARCHAR,
   ADDRESS_POSTALCODE     	VARCHAR,
   ADDRESS_COUNTRY     	VARCHAR,
   JOINED_COMPANY_DATE date,
   GROSS_MONTHLY_SALARY         	real,
   IS_GRANTED_CAR boolean,
   NB_DAYS_YEARLY_HOLIDAYS int
);

INSERT INTO public.employee
(reference, lastname, firstname, dateofbirth, address_number, address_street, address_city, address_postalcode, address_country, joined_company_date, gross_monthly_salary, is_granted_car, nb_days_yearly_holidays)
VALUES(1, 'Cooper', 'Dale', '1959-02-22', '54', 'Trees street', 'Yakima, Washington', '98908', 'USA', '2015-03-18', 3000, false, 20);