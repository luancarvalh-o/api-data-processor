using System.Text.Json;
using ApiDataProcessor.Models;

namespace ApiDataProcessor.Services;

public class WeatherService
{
    private readonly HttpClient _httpClient;

    public WeatherService()
    {
        _httpClient = new HttpClient();

    }

    public async Task<WeatherData> GetWeatherAsync(string city, string apiKey)
    {
        string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric&lang=pt_br";

        HttpResponseMessage response = await _httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode) 
        {
            throw new Exception($"Erro ao buscar o clima. Status {response.StatusCode}");
        }

        string json = await response.Content.ReadAsStringAsync();

        using JsonDocument doc = JsonDocument.Parse(json);
        JsonElement root = doc.RootElement;
        return new WeatherData
        {
            City = root.GetProperty("name").GetString() ?? "Desconhecida",
            Temperature = root.GetProperty("main").GetProperty("temp").GetDouble(),
            Description = root.GetProperty("weather")[0].GetProperty("description").GetString() ?? "Sem descrição",
            Humidity = root.GetProperty("main").GetProperty("humidity").GetInt32()
        };
    }
}