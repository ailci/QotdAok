using Application.Contracts.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using UI.Blazor.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthenticationStateDeserialization();

//DI
builder.Services.AddScoped<IQotdService, QotdApiService>();

//Named Client
builder.Services.AddHttpClient("qotdapiservice", client =>
{
    client.BaseAddress = new Uri("https://qotdminimalapi.azurewebsites.net");
    client.DefaultRequestHeaders.Add("Accept","application/json");
});

await builder.Build().RunAsync();
