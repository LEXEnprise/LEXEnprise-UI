using Blazored.LocalStorage;
using Blazored.Modal;
using Blazored.SessionStorage;
using LEXEnprise.Blazor.Application.Authentication;
using LEXEnprise.Blazor.Application.Services;
using LEXEnprise.Blazor.Application.Services.Account;
using LEXEnprise.Blazor.Infrastructure.Helpers;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
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

        public static WebAssemblyHostBuilder AddServiceHelpers(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddTransient<ILocalStorageHelper, LocalStorageHelper>();
            builder.Services.AddTransient<ISessionStorageHelper, SessionStorageHelper>();
            builder.Services.AddScoped<RefreshTokenService>();
            builder.Services.AddScoped<HttpInterceptorService>();

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
                });

            builder.Services
                .AddAuthorizationCore()
                .AddBlazoredLocalStorage()
                .AddBlazoredSessionStorage()
                .AddScoped<AuthenticationStateProvider, AuthStateProvider>()
                .AddAppServices()
                .AddHttpClientInterceptor();

            builder.Services.AddBlazoredModal();

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
