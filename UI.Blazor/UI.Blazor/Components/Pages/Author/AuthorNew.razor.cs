using Application.Contracts.Services;
using Application.Utilities;
using Application.ViewModels.Author;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace UI.Blazor.Components.Pages.Author;
public partial class AuthorNew
{
    #region Members / Constructors

    [Inject] public ILogger<AuthorNew> Logger { get; set; } = null!;
    [Inject] public IServiceManager ServiceManager { get; set; } = null!;
    [Inject] public NavigationManager NavManager { get; set; } = null!;
    public AuthorForCreateViewModel? AuthorForCreateVm { get; set; }

    #endregion

    protected override void OnInitialized() => AuthorForCreateVm ??= new() { Name = "", Description = "" };

    private async Task HandleValidSubmit(EditContext args)
    {
        Logger.LogInformation($"AuthorForCreateVm: {AuthorForCreateVm?.LogAsJson()}");

        var authorVm = await ServiceManager.AuthorService.AddAuthorAsync(AuthorForCreateVm!);
    }
    private void OnInputFileChange(InputFileChangeEventArgs args)
    {
        //Logger.LogInformation($"InputFile: {args.File.LogAsJson()}");
        AuthorForCreateVm!.Photo = args.File;
    }
}
