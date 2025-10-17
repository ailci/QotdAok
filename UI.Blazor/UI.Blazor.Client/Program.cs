using Application.Contracts.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Options;
using UI.Blazor.Client;
using UI.Blazor.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthenticationStateDeserialization();

//Options-Pattern in DI
builder.Services.Configure<QotdAppSettings>(builder.Configuration.GetSection(nameof(QotdAppSettings)));

//DI
builder.Services.AddScoped<IQotdService, QotdApiService>();

var qotdapiserviceuri = builder.Configuration["QotdAppSettings:QotdServiceApiUri"] ?? throw new InvalidOperationException("Qotd Service Api Uri not found.");

//Named Client
builder.Services.AddHttpClient("qotdapiservice", (sp, client) =>
{
    //client.BaseAddress = new Uri(qotdapiserviceuri);
    var qotdappsettings = sp.GetRequiredService<IOptions<QotdAppSettings>>().Value;
    client.BaseAddress = new Uri(qotdappsettings.QotdServiceApiUri);
    client.DefaultRequestHeaders.Add("Accept","application/json");
});

await builder.Build().RunAsync();
