namespace HangfireFirstApp.Services;

public class ServiceManagement : IServiceManagement
{
    public void SendEmail()
    {
        Console.WriteLine($"Sending Email...: long running task {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
    }

    public void UpdateDatabase()
    {
        Console.WriteLine($"Updating Database...: long running task {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
    }

    public void GenerateMerchandise()
    {
        Console.WriteLine($"Generating merchandise...: long running task {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
    }

    public void SyncData()
    {
        Console.WriteLine($"Sync Data...: long running task {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
    }
}