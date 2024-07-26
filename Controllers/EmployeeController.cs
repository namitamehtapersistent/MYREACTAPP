using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MyReactApp.Models;

namespace MyReactApp.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        [Route("GetEmployees")]
        public IActionResult GetEmployees()
        {
            List<Employee> employeesLst = new List<Employee>();
            Employee obj1 = new Employee();
            obj1.IdEmployee = "1";
            obj1.Address = "Pune Hinjwadi";
            obj1.Email = "react.Net7@sample.com";
            obj1.Name = "React with .Net7";
            obj1.Phone = "9999999999";
            employeesLst.Add(obj1);
            return StatusCode(StatusCodes.Status200OK,employeesLst);
        }
    }

  