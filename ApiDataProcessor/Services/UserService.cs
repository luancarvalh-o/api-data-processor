using System.ComponentModel.Design.Serialization;
using System.Text.Json;
using ApiDataProcessor.Models;

namespace ApiDataProcessor.Services;

public class UserService
{
    private readonly HttpClient _httpClient;

    public UserService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<List<UserData>> GetUsersAsync()
    {
        string url = "https://jsonplaceholder.typicode.com/users";

        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Erro ao buscar usuários Status: {response.StatusCode}");
        }

        string json = await response.Content.ReadAsStringAsync();

        using JsonDocument doc = JsonDocument.Parse(json);
        JsonElement root = doc.RootElement;

        var users = new List<UserData>();
        foreach (var user in root.EnumerateArray())
        {
            users.Add(new UserData
            {
                Name = user.GetProperty("name").GetString() ?? "",
                Email = user.GetProperty("email").GetString() ?? "",
                Phone = user.GetProperty("phone").GetString() ?? "",
                City = user.GetProperty("address").GetProperty("city").GetString() ?? ""

            });
        }
        return users;
    }
}