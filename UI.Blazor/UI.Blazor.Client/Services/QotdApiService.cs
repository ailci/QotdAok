using Application.Contracts.Services;
using Application.ViewModels.Qotd;
using System.Net.Http;
using System.Net.Http.Json;

namespace UI.Blazor.Client.Services;

public class QotdApiService(IHttpClientFactory httpClientFactory) : IQotdService
{
    public async Task<QuoteOfTheDayViewModel> GetQuoteOfTheDayAsync()
    {
        var client = httpClientFactory.CreateClient("qotdapiservice");
        return await client.GetFromJsonAsync<QuoteOfTheDayViewModel>("authors/quotes/qotd");
    }
}