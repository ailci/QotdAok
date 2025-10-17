using Application.Contracts.Services;
using Application.ViewModels.Qotd;

namespace UI.Blazor.Client.Services;

public class QotdApiService : IQotdService
{
    public Task<QuoteOfTheDayViewModel> GetQuoteOfTheDayAsync()
    {
        throw new NotImplementedException();
    }
}