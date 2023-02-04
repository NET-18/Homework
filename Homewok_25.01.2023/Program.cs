namespace Homewok_25._01._2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new DatabaseContext();

            var forecastsAll = context.WeatherForecasts
                .ToList();

            Console.WriteLine("All");
            Console.WriteLine("{0,5} {1,25} {2,5} {3,5} {4,15}", "Id", "Date", "TempC", "TempF", "Summary");
            foreach (var forecast in forecastsAll)
            {
                Console.WriteLine("{0,5},{1,25},{2,5},{3,5},{4,15}",
                forecast.Id, forecast.Date, forecast.TemperatureC, forecast.TemperatureF, forecast.Summary);
            }
            Console.WriteLine();

            var forecastsSmall = context.WeatherForecasts
                .Where(f=>f.TemperatureC <=(5))
                .ToList();

            Console.WriteLine("<=(5)");
            Console.WriteLine("{0,5} {1,25} {2,5} {3,5} {4,15}", "Id", "Date", "TempC", "TempF", "Summary");
            foreach (var forecast in forecastsSmall)
            {
                Console.WriteLine("{0,5},{1,25},{2,5},{3,5},{4,15}",
                forecast.Id, forecast.Date, forecast.TemperatureC, forecast.TemperatureF, forecast.Summary);
            }
            Console.WriteLine();

            var forecastsBig = context.WeatherForecasts
                .Where(f => f.TemperatureC >= (8))
                .ToList();

            Console.WriteLine(">=(8)");
            Console.WriteLine("{0,5} {1,25} {2,5} {3,5} {4,15}", "Id", "Date", "TempC", "TempF", "Summary");
            foreach (var forecast in forecastsBig)
            {
                Console.WriteLine("{0,5},{1,25},{2,5},{3,5},{4,15}",
                forecast.Id, forecast.Date, forecast.TemperatureC, forecast.TemperatureF, forecast.Summary);
            }
            Console.WriteLine();

            context.Add(new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = 15,
                Summary = "Some summ"
            });

            var nowforecast = context.WeatherForecasts
                .Where(f => f.TemperatureC.Equals(15))
                .ToList();
            context.SaveChanges();

            Console.WriteLine("new");
            Console.WriteLine("{0,5} {1,25} {2,5} {3,5} {4,15}", "Id", "Date", "TempC", "TempF", "Summary");
            foreach (var forecast in nowforecast)
            {
                Console.WriteLine("{0,5},{1,25},{2,5},{3,5},{4,15}",
                forecast.Id, forecast.Date, forecast.TemperatureC, forecast.TemperatureF, forecast.Summary);
            }
            Console.WriteLine();

            var forecastsChanged = context.WeatherForecasts
                .FirstOrDefault(f => f.Id.Equals(8));

            forecastsChanged.TemperatureC = -16;
            context.SaveChanges();

            Console.WriteLine("Changes");
            Console.WriteLine("{0,5} {1,25} {2,5} {3,5} {4,15}", "Id", "Date", "TempC", "TempF", "Summary");
            foreach (var forecast in nowforecast)
            {
                Console.WriteLine("{0,5},{1,25},{2,5},{3,5},{4,15}",
                forecast.Id, forecast.Date, forecast.TemperatureC, forecast.TemperatureF, forecast.Summary);
            }
            Console.WriteLine();
        }
    }
}