namespace ApiDataProcessor.Models;

public class CurrencyData
{
    public string BaseCurrency { get; set; } = string.Empty;
    public string TargetCurrency { get; set; } = string.Empty;
    public double ExchangeRate { get; set; }
 }