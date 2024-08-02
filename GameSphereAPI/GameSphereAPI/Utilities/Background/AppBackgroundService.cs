
namespace GameSphereAPI.Utilities.Background
{
    public class AppBackgroundService : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var time = DateTime.Now;
                Console.WriteLine(time);
                await Task.Delay(1000000);
            }
            // Whenever I want to have an action that repeats every period of time I can use this for example sending emails, fetching data regularly, SMS, ...
        }
    }
}
