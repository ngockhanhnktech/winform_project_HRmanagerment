

USE HRD_DB;

SELECT personal_informations.fullname, employee_payrolls.salary as luong_nhan_vien_chinh_thuc, 
employee_payrolls.basic_salary as he_so_luong,departments.department_name as ten_phong_ban,
staff_informations.marriage_status as trang_thai_ket_hon, staff_informations.position as chuc_vi,
departments.id as department_id, staff_informations.id as staff_id , employee_payrolls.id as payroll_id,
personal_informations.id as person_id
FROM personal_informations, staff_informations, employee_payrolls, departments
WHERE personal_informations.id = staff_informations.personal_information_id and 
staff_informations.employee_payroll_id = employee_payrolls.id and 
departments.id = staff_informations.department_id;

 SELECT * FROM personal_informations;
