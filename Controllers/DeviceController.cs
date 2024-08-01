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
       // var lst = (from ep in this._context.Devices
        //           //where ep.DeviceId == id
      //             select ep).ToList();

        return StatusCode(StatusCodes.Status200OK, this._context.Devices.ToList()); //DeviceData.deviceList
    }


    //Create
    [HttpPost]
    [Route("CreateDevice")]
    public async Task<ActionResult> CreateDevice(Device emp)
    {
        try
        {
            this._context.Devices.Add(emp);
            this._context.SaveChanges();
            //DeviceData.deviceList.Add(emp);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
        return Ok("Device created successfully!!");
    }

    //Update not working
    [HttpPut]
    [Route("UpdateDevice/{DeviceId}")]
    public async Task<ActionResult> UpdateDevice(int DeviceId, Device emp)
    {
        if (DeviceId == null)
        {
            return BadRequest("Please enter Device Id");
        }

        var deviceToUpdate = this._context.Devices.Where(x => x.DeviceId == DeviceId).SingleOrDefault();
        //  where ep.DeviceId == DeviceId
        //  select ep).ToList();
        //var existingEmpIndex = DeviceData.deviceList.FindIndex(x => x.DeviceId == DeviceId);


        if (deviceToUpdate == null)
        {
            return NotFound();
        }
        try
        {
            deviceToUpdate = emp;
            this._context.SaveChanges();
            //DeviceData.deviceList[existingEmpIndex] = emp;
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
    public async Task<ActionResult> DeleteDevice(int DeviceId)
    {
        try
        {
            var employee = this._context.Devices.FirstOrDefault(x => x.DeviceId == DeviceId);
            if (employee == null)
            {
                return NotFound();
            }
            this._context.Devices.Remove(employee);
            //DeviceData.deviceList.Remove(employee);
            this._context.SaveChanges();

            return Ok("Device deleted successfully!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

}

