using Application.ViewModels.Author;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace UI.Blazor.ComponentsLibrary.Components.Author;
public partial class AuthorTable
{
    [Inject] public ILogger<AuthorTable> Logger { get; set; } = null!;
    [Inject] public IJSRuntime JsRuntime { get; set; } = null!;
    [Inject] public DialogService DialogService { get; set; } = null!;
    [Parameter] public EventCallback<Guid> OnAuthorDelete { get; set; }
    [Parameter] public IEnumerable<AuthorViewModel>? AuthorViewModels { get; set; }
    private Guid _authorIdToDelete;

    private async Task ShowConfirmationDialog(AuthorViewModel authorVm)
    {
        Logger.LogInformation($"Author {authorVm?.Name} zum Löschen ausgewählt");

        _authorIdToDelete = authorVm.Id;

        //1. Version
        //if (await JsRuntime.InvokeAsync<bool>("myConfirm", $"Wollen Sie wirklich den Author {authorVm?.Name} löschen?"))
        //{
        //    await OnAuthorDelete.InvokeAsync(_authorIdToDelete);
        //}

        //2. Version als Service
        if (await DialogService.ConfirmAsync($"Wollen Sie wirklich den Author {authorVm?.Name} löschen?"))
        {
            await OnAuthorDelete.InvokeAsync(_authorIdToDelete);
        }
    }
}
