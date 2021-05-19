using LEXEnprise.Blazor.Application.Models.Account;
using System;

namespace LEXEnprise.Blazor.Pages.Accounts
{
    public partial class Login
    {
        private LoginRequest _loginModel = new LoginRequest()
        {
            UserName = "Albren",
            Password = "!!Albren6966!!"
        };
        private bool _loading;

        private async void OnValidSubmit()
        {
            _loading = true;
            try
            {
                var result = await AccountService.Login(_loginModel);

                if (result.Succeeded)
                    NavigationManager.NavigateTo("/");

            }
            catch (Exception ex)
            {
                _loading = false;
                StateHasChanged();
            }
        }
    }
}
