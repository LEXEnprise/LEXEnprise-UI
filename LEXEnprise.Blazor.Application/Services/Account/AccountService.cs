using Blazored.LocalStorage;
using LEXEnprise.Blazor.Application.Authentication;
using LEXEnprise.Blazor.Application.Models;
using LEXEnprise.Blazor.Application.Models.Account;
using LEXEnprise.Blazor.Application.Routes;
using LEXEnprise.Blazor.Infrastructure.Extensions;
using LEXEnprise.Blazor.Shared.Wrapper;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Application.Services.Account
{
    public class AccountService : ServiceBase, IAccountService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authStateProvider;
        private const string UserIdentityKey = "IdentityKey";

        public UserIdentity User
        {
            get;
            private set;
        }
        public async Task Initialize()
        {
            User = await _localStorage.GetItemAsync<UserIdentity>(UserIdentityKey);
        }

        public AccountService(HttpClient httpClient,
            ILocalStorageService localStorage,
            AuthenticationStateProvider authStateProvider) : base(httpClient) 
        {
            _localStorage = localStorage;
            _authStateProvider = authStateProvider;
        }

        private async Task CreateStoreUser(LoginResponse loginResponse)
        {
            User = new UserIdentity
            {
                Id =            loginResponse.Id,
                UserName =      loginResponse.UserName,
                FirstName =     loginResponse.FirstName,
                LastName =      loginResponse.LastName,
                Token =         loginResponse.Token,
                RefreshToken =  loginResponse.RefreshToken,
                Roles =         loginResponse.Roles
            };

            //NOTE: Create new interface and implementing class for handling localstorage.
            await _localStorage.SetItemAsync(UserIdentityKey, User);
        }

        public async Task<IResult> Login(LoginRequest loginRequest)
        {
            var response = await _httpClient.PostAsJsonAsync(AccountsEndpoint.Login, loginRequest);
            var result = await response.ToResult<LoginResponse>();

            if (result.Succeeded)
            {
                await CreateStoreUser(result.Data);

                try
                {
                    //Notifies AuthenticationStateProvide that authentication state has changed.
                    ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(result.Data.Token);

                    //Place token to httprequest.
                    //NOTE: This should be later uncommented out.
                    //_httpClient.DefaultRequestHeaders.Authorization =
                    //    new AuthenticationHeaderValue("Bearer", result.Data.Token);

                }
                catch (Exception ex)
                {
                    throw;
                }
               
                return Result.Success();
            }
            else
            {
                return Result.Fail(result.Messages);
            }
        }
    }
}
