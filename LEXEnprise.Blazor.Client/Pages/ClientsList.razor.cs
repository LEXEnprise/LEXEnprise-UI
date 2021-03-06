using LEXEnprise.Blazor.Application.DTOs.Clients;
using LEXEnprise.Blazor.Application.Services.Clients;
using LEXEnprise.Blazor.Shared.Wrapper;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Clients.Pages
{
    public partial class ClientsList
    {
        [Parameter]
        public string PageTitle { get; set; }
        [Parameter]
        public string BreadCrumbTitle { get; set; }

        [Inject]
        protected IConfiguration Config { get; set; }

        [Inject]
        public IClientsService ClientService { get; set; }

        private GetClientsRequest _getClientsRequest = new GetClientsRequest();

        public PageMetaData PageMetaData { get; set; }
        public List<GetClientResponse> Clients = new List<GetClientResponse>();

        //protected override void OnInitialized()
        protected async override Task OnInitializedAsync()
        {
            PageTitle = Config["PageTitles.ClientListTitle"];
            BreadCrumbTitle = "Clients List";

            await GetClients();
        }

        private async Task GetClients()
        {
            var response = await ClientService.GetClients(_getClientsRequest);

            if (response.Succeeded)
            {
                Clients = response.Data.ToList();
                PageMetaData = response.PageMetaData;
            }
        }
    }
}
