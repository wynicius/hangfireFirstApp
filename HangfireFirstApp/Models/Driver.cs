namespace HangfireFirstApp.Models;

public class Driver
{
    public Guid DriverId { get; set; }
    public string Name { get; set; } = "";
    public int Number { get; set; }
    public int Status { get; set; }
}