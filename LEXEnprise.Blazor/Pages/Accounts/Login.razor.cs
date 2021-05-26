using LEXEnprise.Blazor.Application.Models.Account;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Pages.Accounts
{
    public partial class Login
    {
        private LoginRequest _loginModel = new LoginRequest()
        {
            UserName = "Albren",
            Password = "!!Albren6966!!"
        };

        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        private IJSObjectReference _jsModule;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "/js/login.js");
            }
        }

        private async Task DisplaySpinner()
        {
            if (_jsModule != null)
                await _jsModule.InvokeVoidAsync("displaySpinner", "spinner");
        }

        private async Task HideSpinner()
        {
            if (_jsModule != null)
                await _jsModule.InvokeVoidAsync("hideSpinner", "spinner");
        }
        private async void OnValidSubmit()
        {
            await DisplaySpinner();
            try
            {
                var result = await AccountService.Login(_loginModel);

                if (result.Succeeded)
                {
                    await HideSpinner();
                    NavigationManager.NavigateTo("/");
                }

            }
            catch (Exception ex)
            {
                await HideSpinner();
                StateHasChanged();
            }
            finally
            {
                await HideSpinner();
            }

        }
    }
}
