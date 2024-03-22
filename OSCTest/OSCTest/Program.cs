using MudBlazor.Services;
using Newtonsoft.Json;
using OSCTest.Client.Pages;
using OSCTest.Components;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OSCTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddMudServices();
            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveWebAssemblyComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddControllers().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.Converters.Add(new Classes.JSONObjectSerializer());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveWebAssemblyRenderMode()
                .AddInteractiveServerRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            app.MapControllers();

            app.Run();
        }
    }
}
