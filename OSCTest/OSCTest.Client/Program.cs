using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using Newtonsoft.Json;


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

            builder.Services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;
                config.SnackbarConfiguration.PreventDuplicates = true;
                config.SnackbarConfiguration.VisibleStateDuration = 5000;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
            });
            
            await builder.Build().RunAsync();
        }
    }
}
