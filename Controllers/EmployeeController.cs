using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Demo.Model;
using Demo.Repository;
namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeManagement employeeManagement;
        public EmployeeController(IEmployeeManagement _employeeManagement)
        {
            employeeManagement = _employeeManagement;
        }
        [HttpGet]
        [Route("GetEmployees")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employees = await employeeManagement.GetEmployee();
                if (employees == null)
                {
                    return NotFound();
                }

                return Ok(employees);
            }
            catch (Exception )
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("GetEmployee")]
        public async Task<IActionResult> GetEmployee(int empId)
        {
            try
            {
                var employee = await employeeManagement.GetEmployee(empId);

                if (employee == null)
                {
                    return NotFound();
                }

                return Ok(employee);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody]Employee model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var empId = await employeeManagement.AddEmployee(model);
                    if (empId > 0)
                    {
                        return Ok(empId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpPost]
        [Route("DeletePost")]
        public async Task<IActionResult> DeletePost(int? empId)
        {
            int result = 0;

            if (empId == null)
            {
                return BadRequest();
            }

            try
            {
                result = await employeeManagement.DeleteEmployee(empId);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPost]
        [Route("UpdatePost")]
        public async Task<IActionResult> UpdateEmployee([FromBody]Employee model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await employeeManagement.UpdateEmployee(model);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }
    }
}