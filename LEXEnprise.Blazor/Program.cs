using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

using LEXEnprise.Blazor.Config;
using Microsoft.Extensions.Configuration;
using LEXEnprise.Blazor.Extensions;
using LEXEnprise.Blazor.Application.Services.Clients;

namespace LEXEnprise.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            //var localConfig = builder.Configuration.Get<LocalConfig>();

            //builder.Services.AddSingleton(localConfig.AppConfig);

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(localConfig.AppConfig.APIUrl) });

            builder.Services.AddScoped(sp => new HttpClient 
            { 
                BaseAddress = new Uri("http://localhost:50258/api/v1/") 
            });
            // .EnableIntercept(sp)); //Handles or Intercepts Http Request to check if we need to refresh token or not in every call to API.
            //builder.AddClientServices();
            builder.Services.AddScoped<IClientsService, ClientsService>();

            await builder.Build().RunAsync();
        }
    }
}
