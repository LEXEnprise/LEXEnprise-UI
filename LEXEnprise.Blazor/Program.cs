using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

using LEXEnprise.Blazor.Config;
using Microsoft.Extensions.Configuration;
using LEXEnprise.Blazor.Extensions;
using LEXEnprise.Blazor.Application.Services.Clients;
using LEXEnprise.Blazor.Application.Services.Account;

namespace LEXEnprise.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder
                .AddRootComponents()
                .AddClientServices(builder.Configuration);

            var host = builder.Build();
            var accountService = host.Services.GetRequiredService<IAccountService>();

            accountService.Initialize();
            await host.RunAsync();
        }
    }
}
