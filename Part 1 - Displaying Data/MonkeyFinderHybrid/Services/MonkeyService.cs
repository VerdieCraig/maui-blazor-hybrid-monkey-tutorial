using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace MonkeyFinderHybrid.Services;

public class MonkeyService
{
    private List<Monkey> monkeysList = new();

    private readonly HttpClient _httpClient;

    public MonkeyService()
    {
        _httpClient = new HttpClient();
            }
    public async Task<List<Monkey>> GetMonkeys()
    {
        if (monkeysList.Count > 0)
        {
            return monkeysList;
        }
        var response = await _httpClient.GetAsync("https://montemagno.com/monkeys.json");
        if (response.IsSuccessStatusCode)
        {
            var monkeysResult = await response.Content.ReadFromJsonAsync(MonkeyContext.Default.ListMonkey);
            if (monkeysResult != null)
            {
                monkeysList = monkeysResult;
                { monkeysList = monkeysResult; }    
            }
        }
        return monkeysList;
    }
    
}