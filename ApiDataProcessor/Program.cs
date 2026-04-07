using ApiDataProcessor.Services;
using ApiDataProcessor.Models;

namespace ApiDataProcessor;

class Program
{
    static async Task Main(string[] args)
    {
        var weatherService = new WeatherService();
        var CurrencyService = new CurrencyService();
        var UserService = new UserService();


        string apiKey = "ce31191732df8be7536aa3650e7abca5";
        Console.Write($"Informe a cidade: ");
        string city = Console.ReadLine();

        Console.Write($"Informe a moeda base para câmbio (somente código internacional. Ex: BRL): ");
        string userBase = Console.ReadLine();

        Console.Write($"Informe a moeda destino para câmbio (somente código internacional. Ex: BRL): ");
        string userDestination = Console.ReadLine();



        try
        {
            WeatherData weather = await weatherService.GetWeatherAsync(city, apiKey);

            Console.WriteLine("=== DADOS DO CLIMA ===");
            Console.WriteLine($"Cidade: {weather.City}");
            Console.WriteLine($"Temperatura: {weather.Temperature}°C");
            Console.WriteLine($"Descrição: {weather.Description}");
            Console.WriteLine($"Umidade: {weather.Humidity}%");


        }
        catch (Exception ex)
        {
            Console.WriteLine("=== DADOS DO CLIMA ===");
            Console.WriteLine($"{ex.Message}");
        }

        try
        {
            CurrencyData currency = await CurrencyService.GetExchangeRateAsync(userDestination, userBase);
            Console.WriteLine("=== COTAÇÃO ===");
            Console.WriteLine($"Moeda base: {currency.BaseCurrency}");
            Console.WriteLine($"Moeda destino: {currency.TargetCurrency}");
            Console.WriteLine($"Taxa: {currency.ExchangeRate:F2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("\n=== COTAÇÃO ===");
            Console.WriteLine($"{ex.Message}\n");
        }

        try
        {
            List<UserData> users = await UserService.GetUsersAsync();

            Console.WriteLine("=== USUÁRIOS ===");

            foreach (var user in users)
            {
                Console.WriteLine($"Nome : {user.Name}");
                Console.WriteLine($"Email : {user.Email}");
                Console.WriteLine($"Phone : {user.Phone}");
                Console.WriteLine($"City : {user.City}\n");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("\n=== USUÁRIOS ===");
            Console.WriteLine($"{ex.Message}\n");
        }
    }
}