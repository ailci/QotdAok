using Application.ViewModels.Qotd;
using Microsoft.AspNetCore.Components;

namespace UI.Blazor.Components.Pages;
public partial class Home
{
    [Inject]
    public ILogger<Home> Logger { get; set; } = null!;

    public QuoteOfTheDayViewModel? QotdViewModel { get; set; }

    protected override void OnInitialized()
    {
        Logger.LogInformation("OnInitialized aufgerufen...");

        QotdViewModel = new QuoteOfTheDayViewModel
        {
            QuoteText = "Larum lierum Löffelstiel",
            AuthorName = "Ich",
            AuthorDescription = "Dozent",
            AuthorBirthDate = new DateOnly(1978, 07, 13)
        };
    }

    protected override Task OnInitializedAsync()
    {
        Logger.LogInformation("OnInitializedAsync aufgerufen...");

        return Task.CompletedTask;
    }
}
