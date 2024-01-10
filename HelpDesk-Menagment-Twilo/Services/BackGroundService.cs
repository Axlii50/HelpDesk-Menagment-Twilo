using HelpDesk_Menagment_Twilo.Interfaces;

namespace HelpDesk_Menagment_Twilo.Services
{
    public sealed class BackGroundService : BackgroundService
    {
        private readonly IBackGroundService _myServices;

        public BackGroundService(IBackGroundService myServices)
        {
            _myServices = myServices;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Tutaj umieść kod, który ma być wykonany w określonym interwale
                Console.WriteLine("Wykonuję zadanie...");

                // Przykładowe zadanie (możesz go dostosować do swoich potrzeb)
                //foreach (var myService in _myServices)
                //{
                    await _myServices.StartServiceTask();
                //}

                // Ustaw interwał czasowy
                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }
        }
    }
}
