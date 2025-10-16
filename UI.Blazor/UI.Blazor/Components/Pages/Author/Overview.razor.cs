using Application.Contracts.Services;
using Application.ViewModels.Author;
using Microsoft.AspNetCore.Components;

namespace UI.Blazor.Components.Pages.Author;
public partial class Overview
{
    [Inject] public ILogger<Overview> Logger { get; set; } = null!;
    [Inject] public IServiceManager ServiceManager { get; set; } = null!;
    public IEnumerable<AuthorViewModel>? AuthorsVm { get; set; }
    public string? ErrorMessage { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await GetAuthors();
    }

    private async Task DeleteAuthor(Guid authorId)
    {
        Logger.LogInformation($"Autor löschen aufgerufen mit Id: {authorId}");

        ErrorMessage = string.Empty;

        var isDeleted = await ServiceManager.AuthorService.DeleteAuthorAsync(authorId);

        if (isDeleted)
        {
            await GetAuthors();
        }
        else
        {
            Logger.LogError($"Author konnte nicht gelöscht werden");
            ErrorMessage = "Author konnte nicht gelöscht werden";
        }
    }

    private async Task GetAuthors()
    {
        AuthorsVm = (await ServiceManager.AuthorService.GetAuthorsAsync()).OrderBy(c => c.Name);
    }
}
