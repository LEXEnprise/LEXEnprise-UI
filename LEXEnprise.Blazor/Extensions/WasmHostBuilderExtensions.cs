using Blazored.LocalStorage;
using LEXEnprise.Blazor.Application.Authentication;
using LEXEnprise.Blazor.Application.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace LEXEnprise.Blazor.Extensions
{
    public static class WasmHostBuilderExtensions
    {
        private const string ClientName = "LEXEnprise";

        public static WebAssemblyHostBuilder AddRootComponents(this WebAssemblyHostBuilder builder)
        {
            builder.RootComponents.Add<App>("#app");

            return builder;
        }

        public static WebAssemblyHostBuilder AddClientServices(this WebAssemblyHostBuilder builder, IConfiguration config)
        {
            var apiUrl = config["AppSettings:ApiUrl"];

            builder.Services
                .AddScoped(sp => sp
                    .GetRequiredService<IHttpClientFactory>()
                    .CreateClient(ClientName)
                    .EnableIntercept(sp))
                .AddHttpClient(ClientName, client =>
                {
                    client.DefaultRequestHeaders.AcceptLanguage.Clear();
                    client.DefaultRequestHeaders.AcceptLanguage.ParseAdd(CultureInfo.DefaultThreadCurrentCulture?.TwoLetterISOLanguageName);
                    client.BaseAddress = new Uri(apiUrl);
                    //new Uri("http://localhost:50258/api/v1/")
                    //client.BaseAddress = new Uri("http://localhost:57232/");//new Uri(builder.HostEnvironment.BaseAddress);
                });

            builder.Services
                .AddAuthorizationCore()
                .AddBlazoredLocalStorage()
                .AddScoped<AuthenticationStateProvider, AuthStateProvider>()
                .AddAppServices();

            builder.Services.AddHttpClientInterceptor();
            //builder.Services.AddScoped<HttpInterceptorService>();

            return builder;
        }

        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            var appServices = typeof(IService);

            var types = appServices
                .Assembly
                .GetExportedTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Select(t => new
                {
                    Service = t.GetInterface($"I{t.Name}"),
                    Implementation = t
                })
                .Where(t => t.Service != null);

            foreach (var type in types)
            {
                if (appServices.IsAssignableFrom(type.Service))
                {
                    services.AddScoped(type.Service, type.Implementation);
                }
            }

            return services;
        }
    }
}
