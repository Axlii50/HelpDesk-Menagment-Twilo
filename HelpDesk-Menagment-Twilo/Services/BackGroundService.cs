using HelpDesk_Menagment_Twilo.Interfaces;

namespace HelpDesk_Menagment_Twilo.Services
{
    public sealed class BackGroundService : BackgroundService
    {
        private readonly IEnumerable<IBackGroundService> _myServices;

        public BackGroundService(IEnumerable<IBackGroundService> myServices)
        {
            _myServices = myServices;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);

            while (!stoppingToken.IsCancellationRequested)
            {
                // Tutaj umieść kod, który ma być wykonany w określonym interwale
                Console.WriteLine("Wykonuję zadanie...");

                // Przykładowe zadanie (możesz go dostosować do swoich potrzeb)
                foreach (var myService in _myServices)
                {
                    await myService.StartServiceTask();
               }

                // Ustaw interwał czasowy
                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);

               // await Task.Delay(TimeSpan.FromHours(2), stoppingToken);
            }
        }
    }
}
