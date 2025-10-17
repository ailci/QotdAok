using Application.Contracts.Services;
using Application.ViewModels.Qotd;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Extensions.Options;

namespace UI.Blazor.Client.Services;

public class QotdApiService(IHttpClientFactory httpClientFactory, IOptions<QotdAppSettings> appSettings) : IQotdService
{
    private readonly QotdAppSettings _appSettings = appSettings.Value;
    public async Task<QuoteOfTheDayViewModel> GetQuoteOfTheDayAsync()
    {
        var client = httpClientFactory.CreateClient("qotdapiservice");
        return await client.GetFromJsonAsync<QuoteOfTheDayViewModel>("authors/quotes/qotd");
    }
}