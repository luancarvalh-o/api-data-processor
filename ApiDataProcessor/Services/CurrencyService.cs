using System.Text.Json;
using ApiDataProcessor.Models;


namespace ApiDataProcessor.Services;

public class CurrencyService
{
    private readonly HttpClient _httpClient;

    public CurrencyService()
    {
        _httpClient = new HttpClient();

    }

    public async Task<CurrencyData> GetExchangeRateAsync(string targetCurrency, string baseCurrency)
    {
        string url = $"https://api.frankfurter.app/latest?from={baseCurrency}&to={targetCurrency}";

        var response = await _httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Erro ao nuscar cotação. Stats {response.StatusCode}");
        }

        string json = await response.Content.ReadAsStringAsync();
        using JsonDocument doc = JsonDocument.Parse(json);
        JsonElement root = doc.RootElement;

        double rate = root.GetProperty("rates").GetProperty(targetCurrency).GetDouble();

        return new CurrencyData
        {
            BaseCurrency = baseCurrency,
            TargetCurrency = targetCurrency,
            ExchangeRate = rate
        };

    }
}