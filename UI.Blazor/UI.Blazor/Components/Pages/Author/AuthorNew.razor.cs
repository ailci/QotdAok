using Application.Utilities;
using Application.ViewModels.Author;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace UI.Blazor.Components.Pages.Author;
public partial class AuthorNew
{
    #region Members / Constructors

    [Inject] public ILogger<AuthorNew> Logger { get; set; } = null!;
    public AuthorForCreateViewModel? AuthorForCreateVm { get; set; }

    #endregion

    protected override void OnInitialized() => AuthorForCreateVm ??= new() { Name = "", Description = "" };

    private Task HandleValidSubmit(EditContext args)
    {
        Logger.LogInformation($"AuthorForCreateVm: {AuthorForCreateVm?.LogAsJson()}");

        return Task.CompletedTask;
    }
    private void OnInputFileChange(InputFileChangeEventArgs args)
    {
        Logger.LogInformation($"InputFile: {args.File.LogAsJson()}");
    }
}
