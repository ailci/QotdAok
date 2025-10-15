using Application.Contracts.Services;
using Application.ViewModels.Qotd;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace UI.Blazor.Components.Pages;

public partial class Home : IDisposable
{
    [Inject] public ILogger<Home> Logger { get; set; } = null!;
    [Inject] public IServiceManager ServiceManager { get; set; } = null!;
    [Inject] public PersistentComponentState ApplicationState { get; set; } = null!;
    private PersistingComponentStateSubscription _persistingComponentStateSubscription;

    public QuoteOfTheDayViewModel? QotdViewModel { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Logger.LogInformation("OnInitializedAsync aufgerufen...");

        //3.Lösung
        _persistingComponentStateSubscription = ApplicationState.RegisterOnPersisting(PersistData);
        if (!ApplicationState.TryTakeFromJson<QuoteOfTheDayViewModel>(nameof(QotdViewModel), out var restoredData))
        {
            QotdViewModel = await ServiceManager.QotdService.GetQuoteOfTheDayAsync();
        }
        else //gefunden
        {
            QotdViewModel = restoredData;
        }
    }

    private Task PersistData()
    {
        ApplicationState.PersistAsJson(nameof(QotdViewModel), QotdViewModel);
        return Task.CompletedTask;
    }

    public void Dispose() => _persistingComponentStateSubscription.Dispose();

    // 2.Variante
    //protected override async Task OnAfterRenderAsync(bool firstRender)
    //{
    //    if (firstRender)
    //    {
    //        QotdViewModel = await ServiceManager.QotdService.GetQuoteOfTheDayAsync();
    //        StateHasChanged();
    //    }
    //}
}
