using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


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

            await builder.Build().RunAsync();
        }
    }
}
