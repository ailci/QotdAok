using Application.ViewModels.Qotd;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace UI.Blazor.Components.Pages;
public partial class Home
{
    [Inject]
    public ILogger<Home> Logger { get; set; } = null!;

    public QuoteOfTheDayViewModel? QotdViewModel { get; set; }

    [Inject] public QotdContext QotdContext { get; set; } = null!;

    protected override void OnInitialized()
    {
        Logger.LogInformation("OnInitialized aufgerufen...");

        var qotd = QotdContext.Quotes.Include(c => c.Author).First();

        QotdViewModel = new QuoteOfTheDayViewModel
        {
            QuoteText = qotd.QuoteText,
            AuthorName = qotd.Author?.Name,
            AuthorDescription = qotd.Author?.Description,
            AuthorBirthDate = qotd.Author?.BirthDate,
            AuthorPhoto = qotd.Author?.Photo,
            AuthorPhotoMimeType = qotd.Author?.PhotoMimeType
        };
    }

    protected override Task OnInitializedAsync()
    {
        Logger.LogInformation("OnInitializedAsync aufgerufen...");

        return Task.CompletedTask;
    }
}
