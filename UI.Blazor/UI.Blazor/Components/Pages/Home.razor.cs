using Application.Contracts.Services;
using Application.ViewModels.Qotd;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace UI.Blazor.Components.Pages;

public partial class Home
{
    [Inject] public ILogger<Home> Logger { get; set; } = null!;
    [Inject] public IQotdService QotdService { get; set; } = null!;

    public QuoteOfTheDayViewModel? QotdViewModel { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Logger.LogInformation("OnInitializedAsync aufgerufen...");

        QotdViewModel = await QotdService.GetQuoteOfTheDayAsync();
    }
}
