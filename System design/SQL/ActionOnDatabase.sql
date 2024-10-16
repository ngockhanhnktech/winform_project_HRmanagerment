GO
CREATE DATABASE HRD_DB
CREATE DATABASE QuanLyNhanSu

DROP DATABASE HRD_DB
DROP DATABASE QuanLyNhanSu

use QuanLyNhanSu
use HRD_DB

GO

CREATE TABLE  admins(

	    id int primary key,
		username varchar(255),
		password varchar(255)
);

CREATE TABLE  users(

	id int primary key,
	username varchar(255),
	password varchar(255)
);

CREATE TABLE roles (

    id INT PRIMARY KEY,
    name VARCHAR(50)
);

CREATE TABLE role_users (
    id INT PRIMARY KEY,
    admin_id INT null,
	user_id INT null,
    role_id INT
   
);

ALTER TABLE personal_informations
ADD CONSTRAINT users_fk_personal_information
FOREIGN KEY (user_id) REFERENCES users(id);


CREATE TABLE  personal_informations(

	    id int primary key,
		identification_num varchar(55),
		fullname varchar(255),
		gender int,
		Birthplace varchar(255),
		Birthday datetime,
		image text,
		Address varchar(255),
		phone_num varchar(50),
		ethnicity varchar(255),
		religion varchar(255),
		nationality varchar(255),
		education varchar(255),
		note text,
		user_id int
);

CREATE TABLE  departments(

	    id int primary key,
		department_name varchar(255),
		date_of_establishment datetime ,
		note	 text
		
);

CREATE TABLE  staff_informations(

	    id int primary key,
		marriage_status tinyint,
		position varchar(255),
		contracttype varchar(255),
		dayofwork datetime ,
		signing_date datetime,
		expiry_date datetime,
		department_id int null,
		personal_information_id int null,
		employee_payroll_id int null
);

CREATE TABLE  employee_payrolls(

	    id int primary key,
		basic_salary   decimal,
		new_basic_salary decimal,
		salary_position_allowance  decimal,
		salary decimal,
		salary_other_allowance  decimal,
		new_position_allowance varchar(255),
		Penalty varchar(255),
		num_day_of_work int,
		num_day_off int,
		num_over_time int,
		correction_salary_date datetime
);

CREATE TABLE  probationary_records(

	    id int primary key,
		probationary_position varchar(255),
		probationary_date  datetime,
		expiry_date datetime,
		note text,
		department_id int null,
		probationary_payroll_id int null,
		personal_information_id int null
);

CREATE TABLE  probationary_payrolls(

	    id int primary key,
		num_day_of_work  int,
		num_day_off  int,
		salary decimal,
		note text
);


CREATE TABLE  insurances(

	    id int primary key,
		date_of_issue   datetime,
		place_of_issue datetime,
		note  text,
		correction_salary_date datetime,
		personal_information_id int null
);

CREATE TABLE  maternities(

	    id int primary key,
		day_maternity_leave    datetime,
		salary_company_allowance decimal,
		personal_information_id int null
);

CREATE TABLE  employee_quits(

	    id int primary key,
		day_off_work    datetime,
		reason text,
		personal_information_id int null
);


ALTER TABLE staff_informations
ADD CONSTRAINT fk_staff_information_department
FOREIGN KEY (department_id) REFERENCES departments(id);

ALTER TABLE staff_informations
ADD CONSTRAINT fk_staff_information_personal_information
FOREIGN KEY (personal_information_id) REFERENCES personal_informations(id);

ALTER TABLE staff_informations
ADD CONSTRAINT staff_information_employee_payroll
FOREIGN KEY (employee_payroll_id) REFERENCES employee_payrolls(id);


ALTER TABLE probationary_records
ADD CONSTRAINT fk_probationary_record_department
FOREIGN KEY (department_id) REFERENCES departments(id);

ALTER TABLE probationary_records
ADD CONSTRAINT fk_probationary_records_personal_information
FOREIGN KEY (personal_information_id) REFERENCES personal_informations(id);

ALTER TABLE probationary_records
ADD CONSTRAINT fk_probationary_record_probationary_payroll
FOREIGN KEY (probationary_payroll_id) REFERENCES probationary_payrolls(id);

ALTER TABLE insurances
ADD CONSTRAINT fk_insurance_personal_informations
FOREIGN KEY (personal_information_id) REFERENCES personal_informations(id);

ALTER TABLE maternities
ADD CONSTRAINT fk_maternity_personal_informations
FOREIGN KEY (personal_information_id) REFERENCES personal_informations(id);

ALTER TABLE employee_quits
ADD CONSTRAINT fk_employee_quit_personal_informations
FOREIGN KEY (personal_information_id) REFERENCES personal_informations(id);



DROP DATABASE HRD_DB;
