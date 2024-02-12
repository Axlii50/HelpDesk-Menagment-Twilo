namespace Pinger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tworzenie klienta HttpClient
            var httpClient = new HttpClient();

            // Pętla, która będzie wysyłała zapytanie co 10 minut
            while (true)
            {
                try
                {
                    // Wysyłanie zapytania GET do podanego adresu
                    HttpResponseMessage response = httpClient.GetAsync("http://helpdesk.twilo.pl/").Result;

                    // Sprawdzenie, czy odpowiedź jest poprawna (status code 200)
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Zapytanie wysłane pomyślnie. Status code: {response.StatusCode}");
                    }
                    else
                    {
                        Console.WriteLine($"Wystąpił problem podczas wysyłania zapytania. Status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Wystąpił wyjątek: {ex.Message}");
                }

                // Poczekaj 10 minut przed wysłaniem kolejnego zapytania
                Thread.Sleep(TimeSpan.FromMinutes(10));
            }
        }
    }
}