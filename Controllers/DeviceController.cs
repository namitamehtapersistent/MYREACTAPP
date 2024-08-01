using Microsoft.AspNetCore.Mvc;
using MyReactApp.Data;
using MyReactApp.Models;

namespace MyReactApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeviceController : ControllerBase
{
    private readonly DeviceManagementContext _context;

    public DeviceController(DeviceManagementContext context)
    {
        this._context = context;
    }

    // Details
    [HttpGet]
    [Route("GetDevices")]
    public IActionResult GetDevices()
    {
        return StatusCode(StatusCodes.Status200OK, this._context.Devices.ToList());
    }


    //Create
    [HttpPost]
    [Route("CreateDevice")]
    public IActionResult CreateDevice(Device emp)
    {
        try
        {
            this._context.Devices.Add(emp);
            this._context.SaveChanges();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
        return Ok("Device created successfully!!");
    }

    //Update
    [HttpPut]
    [Route("UpdateDevice/{DeviceId}")]
    public IActionResult UpdateDevice(int DeviceId, Device emp)
    {
        if (DeviceId == null)
        {
            return BadRequest("Please enter Device Id");
        }

        var deviceToUpdate = this._context.Devices.FirstOrDefault(o => o.DeviceId == DeviceId);

        if (deviceToUpdate == null)
        {
            return NotFound();
        }
        try
        {
            this._context.Entry(deviceToUpdate).CurrentValues.SetValues(emp);
            this._context.SaveChanges();
            return Ok("Device updated successfully!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    //Delete
    [HttpDelete]
    [Route("DeleteDevice/{DeviceId}")]
    public IActionResult DeleteDevice(int DeviceId)
    {
        try
        {
            var employee = this._context.Devices.FirstOrDefault(x => x.DeviceId == DeviceId);
            if (employee == null)
            {
                return NotFound();
            }
            this._context.Devices.Remove(employee);
            this._context.SaveChanges();

            return Ok("Device deleted successfully!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

}

