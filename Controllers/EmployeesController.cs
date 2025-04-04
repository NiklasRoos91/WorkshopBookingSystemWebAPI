﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkshopBookingSystemWebAPI.Database;
using WorkshopBookingSystemWebAPI.DTOs;
using WorkshopBookingSystemWebAPI.Interfaces;

namespace WorkshopBookingSystemWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly WorkshopBookingSystemContext _context;
        private readonly IEmployeeService _employeeService;

        public EmployeesController(WorkshopBookingSystemContext context, IEmployeeService employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }

        // GET: api/Employees
        [HttpGet("Get all employees")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAllEmployees()
        {
            var employees = _employeeService.GetAllEmployees();

            if (employees == null)
            {
                return NotFound(new { Message = "No employees where found." });

            }

            return await employees;
        }

        // GET: api/Employees/5
        [HttpGet("Get Employee by {employeeId}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(int employeeId)
        {
            var employeeDto = await _employeeService.GetEmployeeById(employeeId);

            if (employeeDto == null)
            {
                return NotFound(new { Message = "No employee found with the provided ID." });
            }

            return Ok(employeeDto);
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Create new Empoyee")]
        public async Task<ActionResult> CreateEmployee(CreateEmployeeDto employee)
        {
            try
            {
                var newEmployee = await _employeeService.CreateEmployee(employee);
                return Ok(newEmployee);
            }
            catch(ValidationException ex)
            {
                var errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
                return BadRequest(errors);
            }
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update Employee with {employeeId}")]
        public async Task<IActionResult> PutEmployee(int employeeId, CreateEmployeeDto employee)
        {
            try
            {
                var updatedEmployee = await _employeeService.UpdateEmployee(employeeId, employee);

                if (updatedEmployee == null)
                {
                    return NotFound($"No employee found with ID {employeeId}");
                }

                return Ok(updatedEmployee);
            }
            catch (ValidationException ex)
            {
                var errors = ex.Errors.Select(e => new {e.PropertyName, e.ErrorMessage});
                return BadRequest(errors);
            }
        }

        // DELETE: api/Employees/5
        [HttpDelete("Delete employee by {employeeId}")]
        public async Task<IActionResult> DeleteEmployee(int employeeId)
        {
            var deletedEmployee = await _employeeService.DeleteEmployee(employeeId);

            if (!deletedEmployee)
            {
                return NotFound($"No employee found with ID {employeeId}.");
            }

            return NoContent();
        }

        private bool EmployeeExists(int employeeId)
        {
            throw new NotImplementedException("Denna metod är inte klar ännu.");
        }
    }
}
