using Microsoft.AspNetCore.Components;

namespace LEXEnprise.Blazor.Shared
{
    public partial class CustomNotFound
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public void NavigateToHome()
        {
            NavigationManager.NavigateTo("/");
        }

        public void ReportToError()
        {
            NavigationManager.NavigateTo("/ReportError/405/Page not found.");
        }
    }
}
