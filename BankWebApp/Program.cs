using BankWebApp;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

HttpClient http = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
builder.Services.AddScoped(sp => http);

using (HttpResponseMessage response = await http.GetAsync("appsettings.json"))
using (Stream stream = await response.Content.ReadAsStreamAsync())
{
    builder.Configuration.AddJsonStream(stream);
}

await builder.Build().RunAsync();
