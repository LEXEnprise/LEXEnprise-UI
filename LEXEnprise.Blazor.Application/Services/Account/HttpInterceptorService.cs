using LEXEnprise.Blazor.Application.Constants;
using LEXEnprise.Blazor.Application.Models.Account;
using LEXEnprise.Blazor.Application.Services.Account;
using LEXEnprise.Blazor.Infrastructure.Helpers;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Toolbelt.Blazor;
using Microsoft.AspNetCore.Components;

namespace LEXEnprise.Blazor.Application.Services.Account
{
    public class HttpInterceptorService
    {
        private readonly HttpClientInterceptor _interceptor;
        private readonly RefreshTokenService _refreshTokenService;
        private readonly ILocalStorageHelper _localStorage;
        private readonly NavigationManager _navigator;

        public HttpInterceptorService(HttpClientInterceptor interceptor,
            RefreshTokenService refreshTokenService,
            ILocalStorageHelper localStorage,
            NavigationManager navigator)
        {
            _interceptor = interceptor;
            _refreshTokenService = refreshTokenService;
            _localStorage = localStorage;
            _navigator = navigator;
        }
        //public void RegisterEvent() => _interceptor.BeforeSendAsync += InterceptBeforeHttpAsync;

        public void RegisterEvent()
        {
            _interceptor.BeforeSendAsync += InterceptBeforeHttpAsync;
            _interceptor.AfterSend += InterceptAfterHttpAsync;
        }

        private async Task TryRefreshToken(HttpClientInterceptorEventArgs e)
        {
            var absPath = e.Request.RequestUri.AbsolutePath;

            if (!absPath.Contains("token") && !absPath.Contains("accounts"))
            {
                var token = await _refreshTokenService.TryRefreshToken();

                if (string.IsNullOrEmpty(token))
                {
                    var secTokens = await _localStorage.GetItemAsync<SecTokens>(StorageKeys.SecTokensKey);
                    token = secTokens.Token;
                }

                e.Request.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);
            }
        }

        public async Task InterceptBeforeHttpAsync(object sender, HttpClientInterceptorEventArgs e)
        {
            var absPath = e.Request.RequestUri.AbsolutePath;

            if (!absPath.Contains("token") && !absPath.Contains("accounts"))
            {
                var token = await _refreshTokenService.TryRefreshToken();

                if (string.IsNullOrEmpty(token))
                {
                    var secTokens = await _localStorage.GetItemAsync<SecTokens>(StorageKeys.SecTokensKey);
                    token = secTokens.Token;
                }

                e.Request.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);
            }
        }

        public void InterceptAfterHttpAsync(object sender, HttpClientInterceptorEventArgs e)
        {
            if (e.Response != null && !e.Response.IsSuccessStatusCode)
            {
                var statusCode = e.Response.StatusCode;

                switch (statusCode)
                {
                    case HttpStatusCode.NotFound:
                        _navigator.NavigateTo("/404");
                        break;
                    case HttpStatusCode.InternalServerError:
                        _navigator.NavigateTo("/500");
                        break;
                };
            }
        }

        public void DisposeEvent()
        {
            _interceptor.BeforeSendAsync -= InterceptBeforeHttpAsync;
            _interceptor.AfterSend -= InterceptAfterHttpAsync;
        }
    }
}
