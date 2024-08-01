using Microsoft.AspNetCore.Mvc;
using MyReactApp.Data;
using MyReactApp.Models;

namespace MyReactApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeviceController : ControllerBase
{
    // Details
    [HttpGet]
    [Route("GetDevices")]
    public IActionResult GetDevices()
    {
        return StatusCode(StatusCodes.Status200OK, DeviceData.deviceList);
    }


    //Create
    [HttpPost]
    [Route("CreateDevice")]
    public async Task<ActionResult> CreateDevice(Device emp)
    {
        try
        {
            DeviceData.deviceList.Add(emp);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
        return Ok("Employee created successfully!!");
    }

    //Update
    [HttpPut]
    [Route("UpdateDevice/{DeviceId}")]
    public async Task<ActionResult> UpdateDevice(int DeviceId, Device emp)
    {
        if (DeviceId == null)
        {
            return BadRequest("Please enter Employee Id");
        }

        var existingEmpIndex = DeviceData.deviceList.FindIndex(x => x.DeviceId == DeviceId);

        if (existingEmpIndex == -1)
        {
            return NotFound();
        }
        try
        {
            DeviceData.deviceList[existingEmpIndex] = emp;
            return Ok("User updated successfully!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    //Delete
    [HttpDelete]
    [Route("DeleteDevice/{DeviceId}")]
    public async Task<ActionResult> DeleteDevice(int DeviceId)
    {
        try
        {
            var employee = DeviceData.deviceList.FirstOrDefault(x => x.DeviceId == DeviceId);
            if (employee == null)
            {
                return NotFound();
            }

            DeviceData.deviceList.Remove(employee);

            return Ok("Employee deleted successfully!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

}

