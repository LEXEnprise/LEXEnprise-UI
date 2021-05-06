using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;

namespace LEXEnprise.Blazor.Clients.Pages
{
    public partial class ClientsList
    {
        [Parameter]
        public string PageTitle { get; set; }

        [Inject]
        protected IConfiguration Config { get; set; }

        //protected async override Task OnInitializedAsync()
        protected override void OnInitialized()
        {
            PageTitle = Config["PageTitles.ClientListTitle"];
        }
    }
}
