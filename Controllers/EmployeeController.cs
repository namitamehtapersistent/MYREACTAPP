using Microsoft.AspNetCore.Mvc;
using MyReactApp.Data;
using MyReactApp.Models;

namespace MyReactApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    // Details
    [HttpGet]
    [Route("GetEmployees")]
    public IActionResult GetEmployees()
    {
        return StatusCode(StatusCodes.Status200OK, EmployeeData.employeesList);
    }


    //Create
    [HttpPost]
    [Route("CreateEmployee")]
    public async Task<ActionResult> CreateEmployee(Employee emp)
    {
        try
        {
            EmployeeData.employeesList.Add(emp);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
        return Ok("Employee created successfully!!");
    }

    //Update
    [HttpPut]
    [Route("UpdateEmployee/{EmployeeId}")]
    public async Task<ActionResult> UpdateEmployee(string EmployeeId, Employee emp)
    {
        if (string.IsNullOrEmpty(EmployeeId))
        {
            return BadRequest("Please enter Employee Id");
        }

        var existingEmpIndex = EmployeeData.employeesList.FindIndex(x => x.IdEmployee == EmployeeId);

        if (existingEmpIndex == -1)
        {
            return NotFound();
        }
        try
        {
            EmployeeData.employeesList[existingEmpIndex] = emp;
            return Ok("User updated successfully!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    //Delete
    [HttpDelete]
    [Route("DeleteEmployee/{EmployeeId}")]
    public async Task<ActionResult> DeleteEmployee(string EmployeeId)
    {
        try
        {
            var employee = EmployeeData.employeesList.FirstOrDefault(x => x.IdEmployee == EmployeeId);
            if (employee == null)
            {
                return NotFound();
            }

            EmployeeData.employeesList.Remove(employee);

            return Ok("Employee deleted successfully!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

}

