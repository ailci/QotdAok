using Application.ViewModels.Qotd;
using Microsoft.AspNetCore.Components;

namespace UI.Blazor.Client.Pages;
public partial class HomeWasm
{
    [Inject] public ILogger<HomeWasm> Logger { get; set; } = null!;
    public QuoteOfTheDayViewModel? QotdViewModel { get; set; }
}
