using ApiDataProcessor.Services;
using ApiDataProcessor.Models;

namespace ApiDataProcessor;

class Program
{
    static async Task Main(string[] args)
    {
        var weatherService = new WeatherService();

        string apiKey = "SUA_CHAVE_AQUI";
        string city = "Sao Paulo";

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
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}