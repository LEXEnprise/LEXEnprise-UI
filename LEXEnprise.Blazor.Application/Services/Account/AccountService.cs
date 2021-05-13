﻿using LEXEnprise.Blazor.Application.Authentication;
using LEXEnprise.Blazor.Application.Models;
using LEXEnprise.Blazor.Application.Models.Account;
using LEXEnprise.Blazor.Application.Routes;
using LEXEnprise.Blazor.Infrastructure.Extensions;
using LEXEnprise.Blazor.Infrastructure.Helpers;
using LEXEnprise.Blazor.Shared.Wrapper;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Application.Services.Account
{
    public class AccountService : ServiceBase, IAccountService
    {
        private readonly ILocalStorageHelper _localStorage;
        private readonly AuthenticationStateProvider _authStateProvider;
        private const string UserIdentityKey = "IdentityKey";
        private const string SecTokensKey = "SecTokensKey";

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
            ILocalStorageHelper localStorage,
            AuthenticationStateProvider authStateProvider) : base(httpClient) 
        {
            _localStorage = localStorage;
            _authStateProvider = authStateProvider;
        }

        private void CreateStoreUserPlusTokens(LoginResponse loginResponse)
        {
            User = new UserIdentity
            {
                Id =            loginResponse.Id,
                UserName =      loginResponse.UserName,
                FirstName =     loginResponse.FirstName,
                LastName =      loginResponse.LastName,
                Roles =         loginResponse.Roles
            };

            var secTokens = new SecTokens
            {
                Token = loginResponse.Token,
                RefreshToken = loginResponse.RefreshToken
            };

            //NOTE: Create new interface and implementing class for handling localstorage.
            _localStorage.SetItemAsync(UserIdentityKey, User);
            _localStorage.SetItemAsync(SecTokensKey, secTokens);
        }

        public async Task<IResult> Login(LoginRequest loginRequest)
        {
            var response = await _httpClient.PostAsJsonAsync(AccountsEndpoint.Login, loginRequest);
            var result = await response.ToResult<LoginResponse>();

            if (result.Succeeded)
            {
                CreateStoreUserPlusTokens(result.Data);

                try
                {
                    //Notifies AuthenticationStateProvide that authentication state has changed.
                    ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(result.Data.Token);

                    //Place token to httprequest.
                    //NOTE: This should be later uncommented out.
                    SetHttpHeaderBearer(result.Data.Token);
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

        private void SetHttpHeaderBearer(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        public async Task<string> RefreshToken()
        {
            var secTokens = await _localStorage.GetItemAsync<SecTokens>(SecTokensKey);
            var response = await _httpClient.PostAsJsonAsync("/auth-service/refreshtoken", 
                            new RefreshTokenRequest
                            {
                                Token = secTokens.Token,
                                RefreshToken = secTokens.RefreshToken
                            });

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException("Something went wrong during the refresh token action.");
            }

            var result = await response.ToResult<RefreshTokenResponse>();
            var newToken = result.Data.NewToken;

            await _localStorage.SetItemAsync<SecTokens>(SecTokensKey, new SecTokens
            {
                Token = newToken,
                RefreshToken = result.Data.NewRefreshToken
            });

            SetHttpHeaderBearer(newToken);

            return newToken;
        }
    }
}
