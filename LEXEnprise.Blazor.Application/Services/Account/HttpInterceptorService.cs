using LEXEnprise.Blazor.Application.Constants;
using LEXEnprise.Blazor.Application.Models.Account;
using LEXEnprise.Blazor.Infrastructure.Helpers;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Toolbelt.Blazor;

namespace LEXEnprise.Blazor.Application.Services.Account
{
    public class HttpInterceptorService
    {
        private readonly HttpClientInterceptor _interceptor;
        private readonly RefreshTokenService _refreshTokenService;
        private readonly ILocalStorageHelper _localStorage;

        public HttpInterceptorService(HttpClientInterceptor interceptor, 
            RefreshTokenService refreshTokenService,
            ILocalStorageHelper localStorage)
        {
            _interceptor = interceptor;
            _refreshTokenService = refreshTokenService;
            _localStorage = localStorage;
        }
        public void RegisterEvent() => _interceptor.BeforeSendAsync += InterceptBeforeHttpAsync;
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
        public void DisposeEvent() => _interceptor.BeforeSendAsync -= InterceptBeforeHttpAsync;
    }
}
