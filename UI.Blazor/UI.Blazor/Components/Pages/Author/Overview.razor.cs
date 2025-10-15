using Application.Contracts.Services;
using Application.ViewModels.Author;
using Microsoft.AspNetCore.Components;

namespace UI.Blazor.Components.Pages.Author;
public partial class Overview
{
    [Inject] public ILogger<Overview> Logger { get; set; } = null!;
    [Inject] public IServiceManager ServiceManager { get; set; } = null!;
    public IEnumerable<AuthorViewModel>? AuthorsVm { get; set; }

    protected override async Task OnInitializedAsync()
    {
        AuthorsVm = (await ServiceManager.AuthorService.GetAuthorsAsync()).OrderBy(c => c.Name);
    }
}
