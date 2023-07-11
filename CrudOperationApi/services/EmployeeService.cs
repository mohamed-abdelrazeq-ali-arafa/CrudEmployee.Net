using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudOperationApi.Models;

namespace CrudOperationApi.services
{
    public class EmployeeService
    {

       

        static List<Employee> employeesList { get; }
        static int nextEmpId = 3;

        static EmployeeService()
        {

            employeesList = new List<Employee> {
                new Employee {Id=1,name="moahmed",salary=7000,title="fresh"},
                new Employee {Id=2,name="ahmed",salary=9000,title="senior"}

                };
        }
        public static List<Employee> GetEmployees() {
            return employeesList;
        }
        public static Employee GetEmployeeById(int id)
        {
            return employeesList.FirstOrDefault(p => p.Id == id);
        }

        public static  void  addEmployee(Employee employee)
        {
            employee.Id = nextEmpId++;
            employeesList.Add(employee);
        }

        public static void updateEmployee(Employee employee)
        {
            var index = employeesList.FindIndex(p => p.Id == employee.Id);
            if (index == -1) return;
            employeesList[index] = employee;
        }
        public static void delete (int id)
        {
            var employee = GetEmployeeById(id);
            if (employee is null) return;
            employeesList.Remove(employee);

        }
    }
}
