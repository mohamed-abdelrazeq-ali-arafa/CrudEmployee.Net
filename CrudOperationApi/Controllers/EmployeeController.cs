using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CrudOperationApi.Models;
using CrudOperationApi.services;

namespace CrudOperationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Employee>> GetALL() => EmployeeService.GetEmployees();

        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {

            var employee = EmployeeService.GetEmployeeById(id);
            if (employee == null)
                return NotFound();
            return employee;

        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            EmployeeService.addEmployee(employee);
            return CreatedAtAction(nameof(Create), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Employee employee)
        {
            if (id != employee.Id)
                return BadRequest();
           
            var existingEmployee = EmployeeService.GetEmployeeById(id);
            if (existingEmployee is null)
                return NotFound();
            EmployeeService.updateEmployee(employee);
            return NoContent();

        }




        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            var employee = EmployeeService.GetEmployeeById(id);
            if(employee is null)
                    return NotFound();
            EmployeeService.delete(id);
            return NoContent();

        }

       }
    }

