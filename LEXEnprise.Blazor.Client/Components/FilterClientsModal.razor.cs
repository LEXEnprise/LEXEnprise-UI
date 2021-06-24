using Blazored.Modal;
using Blazored.Modal.Services;
using LEXEnprise.Blazor.Application.Models.Clients;
using LEXEnprise.Blazor.Application.Models.Lookup;
using LEXEnprise.Blazor.Application.Services.Lookup;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Clients.Components
{
    public partial class FilterClientsModal
    {
        [CascadingParameter]
        public BlazoredModalInstance BlazoredModal { get; set; }

        [Parameter]
        public string Title { get; set; }
        [Parameter]
        public List<ClientType> ClientTypes { get; set; } = new List<ClientType>();

        [Parameter]
        public List<ClientStatus> ClientStatuses { get; set; } = new List<ClientStatus>();
        [Parameter]
        public List<Industry> Industries { get; set; } = new List<Industry>();

        [Inject]
        public ILookupService LookupService { get; set; }

        FilterClientsModel ClientsFilter = new FilterClientsModel();

        protected override async Task OnInitializedAsync()
        {
            ClientTypes = await LookupService.GetClientTypes();
            Industries = await LookupService.GetIndustries();
            ClientStatuses = await LookupService.GetClientStatuses();
        }

        private async Task SubmitFilter()
        {
            await BlazoredModal.CloseAsync(ModalResult.Ok(ClientsFilter));
        }

        private async Task Cancel() => await BlazoredModal.CancelAsync();
    }
}
