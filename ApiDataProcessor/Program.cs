using ApiDataProcessor.Services;
using ApiDataProcessor.Models;

namespace ApiDataProcessor;

class Program
{
    static async Task Main(string[] args)
    {
        var weatherService = new WeatherService();

        string apiKey = "ce31191732df8be7536aa3650e7abca5";
        Console.Write($"Informe a cidade: ");
        string city = Console.ReadLine();

        try
        {
            WeatherData weather = await weatherService.GetWeatherAsync(city, apiKey);

            Console.WriteLine("=== DADOS DO CLIMA ===");
            Console.WriteLine($"Cidade: {weather.City}");
            Console.WriteLine($"Temperatura: {weather.Temperature}°C");
            Console.WriteLine($"Descrição: {weather.Description}");
            Console.WriteLine($"Umidade: {weather.Humidity}%");
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }



    }
}