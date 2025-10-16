using Microsoft.AspNetCore.Components;

namespace UI.Blazor.ComponentsLibrary.Components;
public partial class ConfirmDialog
{
    [Parameter] public string ConfirmTitle { get; set; } = string.Empty;
    [Parameter] public string ConfirmMessage { get; set; } = "Sind Sie sicher?";
    [Parameter] public EventCallback<bool> OnConfirmDelete { get; set; }
    private bool _showConfirm;

    public void Show()
    {
        _showConfirm = true;
    }

    public void Show(string message)
    {
        _showConfirm = true;
        ConfirmMessage = message;
    }

    private async Task OnConfirmChange(bool isDeleteConfirmed)
    {
        _showConfirm = false;

        if (isDeleteConfirmed)
            await OnConfirmDelete.InvokeAsync(isDeleteConfirmed);
    }
}
