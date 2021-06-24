using Blazored.LocalStorage;
using LEXEnprise.Blazor.Application.Constants;
using LEXEnprise.Blazor.Application.Models.Account;
using LEXEnprise.Blazor.Infrastructure.Helpers;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Application.Authentication
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ISessionStorageHelper _sessionStorage;
        private readonly AuthenticationState _anonymous;

        public AuthStateProvider(HttpClient httpClient, ISessionStorageHelper sessionStorage)
        {
            _httpClient = httpClient;
            _sessionStorage = sessionStorage;
            //create an anonymous user since we are going to use it throughout this class
            _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //Get token from local storages.
            var secTokens = await _sessionStorage.GetItemAsync<SecTokens>(StorageKeys.SecTokensKey);

            if (secTokens == null)
                return _anonymous;

            var token = secTokens.Token;

            //if not in local storage, return anonymous.
            if (string.IsNullOrWhiteSpace(token))
                

            //set the default authorization header for the HttpClient using the token got from local storage, and return authenticated user – 
            //the ClaimsIdentity constructor is populated with the parsed claims and the authentication type parameters.
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var claims = JwtParser.ParseClaimsFromJwt(token); //Extract claims from the token.

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims, "jwtAuthType")));
        }

        //NotifyAuthenticationStateChanged method that rises the AuthenticationStateChanged event for the AuthenticationStateProvider. 
        //We are going to use this method as soon as the user logs in.
        public void NotifyUserAuthentication(string token)
        {
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwtAuthType"));
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
            
            NotifyAuthenticationStateChanged(authState);
        }

        //Notifies AuthenticationStateProvider as soon as the user logs out.
        public void NotifyUserLogout()
        {
            var authState = Task.FromResult(_anonymous);

            NotifyAuthenticationStateChanged(authState);
        }
    }
}
