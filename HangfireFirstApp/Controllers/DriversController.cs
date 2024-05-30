using Hangfire;
using HangfireFirstApp.Models;
using HangfireFirstApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace HangfireFirstApp.Controllers;

[ApiController]
[Route("[controller]")]
public class DriversController : ControllerBase
{
    private static List<Driver> drivers = new();

    [HttpPost]
    public IActionResult AddDriver(Driver driver)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        
        drivers.Add(driver);

        var jobId = BackgroundJob.Enqueue<IServiceManagement>(x => x.UpdateDatabase());

        Console.WriteLine($"JobId: {jobId}");

        return CreatedAtAction("GetDriver", new {driver.DriverId}, driver);
    }

    [HttpGet]
    public IActionResult GetDrivers()
    {
        return Ok(drivers.ToList());
    }

    [HttpGet("{driverId}")]
    public IActionResult GetDriver(Guid driverId)
    {
        var driver = drivers.FirstOrDefault(d => d.DriverId == driverId);

        if (driver == null)
            return NotFound();

        BackgroundJob.Enqueue<IServiceManagement>(x => x.GenerateMerchandise());

        return Ok(driver);
    }


    [HttpDelete]
    public IActionResult DeleteDriver(Guid driverId)
    {
        var driver = drivers.FirstOrDefault(d => d.DriverId == driverId);

        if (driver == null)
            return NotFound();

        RecurringJob.AddOrUpdate<IServiceManagement>(x => x.UpdateDatabase(), "0 * * ? * *");

        driver.Status = 0;

        return NoContent();
    }
}