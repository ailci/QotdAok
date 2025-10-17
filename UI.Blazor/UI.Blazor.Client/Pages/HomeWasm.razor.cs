using System.Net.Http.Json;
using System.Text.Json;
using Application.ViewModels.Qotd;
using Microsoft.AspNetCore.Components;

namespace UI.Blazor.Client.Pages;
public partial class HomeWasm
{
    [Inject] public ILogger<HomeWasm> Logger { get; set; } = null!;
    [Inject] public IHttpClientFactory HttpClientFactory { get; set; } = null!;
    public QuoteOfTheDayViewModel? QotdViewModel { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Logger.LogInformation($"Home Wasm aufgerufen...");

        //1. Version
        //var client = HttpClientFactory.CreateClient("qotdapiservice");
        //var response = await client.GetAsync("authors/quotes/qotd");
        //response.EnsureSuccessStatusCode();
        //var content = await response.Content.ReadAsStringAsync();
        //Logger.LogInformation($"RÜCKGABE: {content}");
        //QotdViewModel = JsonSerializer.Deserialize<QuoteOfTheDayViewModel>(content, new JsonSerializerOptions {PropertyNameCaseInsensitive = true});

        //2.Version Abkürzung
        var client = HttpClientFactory.CreateClient("qotdapiservice");
        QotdViewModel = await client.GetFromJsonAsync<QuoteOfTheDayViewModel>("authors/quotes/qotd");
    }
}
