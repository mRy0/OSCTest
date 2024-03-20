using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;


namespace OSCTest.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddHttpClient();
            builder.Services.AddScoped(sp =>
              new HttpClient
              {
                  BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
              });

            builder.Services.AddScoped<Services.IOSCSettingService, Services.OSCSettingService>();

            builder.Services.AddMudServices();
            
            await builder.Build().RunAsync();
        }
    }
}
