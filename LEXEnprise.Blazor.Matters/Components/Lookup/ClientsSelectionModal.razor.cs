using Blazored.Modal;
using Blazored.Modal.Services;
using LEXEnprise.Blazor.Application.Models.Clients;
using LEXEnprise.Blazor.Application.Services;
using LEXEnprise.Blazor.Application.Services.Clients;
using LEXEnprise.Blazor.Shared.Wrapper;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//NOTE: Later this should be a shared component.
namespace LEXEnprise.Blazor.Matters.Components.Lookup
{
    public partial class ClientsSelectionModal : IDisposable
    {
        [CascadingParameter]
        public BlazoredModalInstance BlazoredModal { get; set; }

        [Parameter]
        public string Title { get; set; } = "Client Selection";

        public PageMetaData PageMetaData { get; set; } = new PageMetaData();

        public List<GetClientResponse> Clients { get; set; } = new List<GetClientResponse>();

        private GetClientsRequest _getClientsRequest = new GetClientsRequest();

        [Inject]
        public IClientsService ClientsService { get; set; }

        [Inject]
        public HttpInterceptorService Interceptor { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        private IJSObjectReference _jsModule;

        private async Task GetClients()
        {
            var response = await ClientsService.GetClients(_getClientsRequest);

            if (response.Succeeded)
            {
                Clients = response.Data.ToList();
                PageMetaData = response.PageMetaData;
            }
        }

        private async Task LoadClients()
        {
            await DisplaySpinner();
            try
            {
                await GetClients();
            }
            finally
            {
                await HideSpinner();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            Interceptor.RegisterEvent();
            await GetClients();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "/js/clients/clients.js");
            }
        }

        private async Task SelectedPage(int page)
        {
            _getClientsRequest.PageNumber = page;
            await LoadClients();
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

        private async Task SubmitSearchValue(string searchTerm)
        {
            Console.WriteLine(searchTerm);
            _getClientsRequest.PageNumber = 1;
            _getClientsRequest.SearchString = searchTerm;
            await LoadClients();
        }

        private async Task Cancel() => await BlazoredModal.CancelAsync();

        private async Task SelectRow(int clientId, string clientNumber, string clientName)
        {
            var selectedClient = new ClientInfo
            {
                Id = clientId,
                ClientNumber = clientNumber,
                ClientName = clientName
            };

            await BlazoredModal.CloseAsync(ModalResult.Ok(selectedClient));
        }

        public void Dispose() => Interceptor.DisposeEvent();
    }
}
