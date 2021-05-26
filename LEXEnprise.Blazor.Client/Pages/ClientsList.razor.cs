using Blazored.Modal;
using Blazored.Modal.Services;
using LEXEnprise.Blazor.Application.Models.Clients;
using LEXEnprise.Blazor.Application.Models.Lookup;
using LEXEnprise.Blazor.Application.Services.Account;
using LEXEnprise.Blazor.Application.Services.Clients;
using LEXEnprise.Blazor.Application.Services.Lookup;
using LEXEnprise.Blazor.Clients.Components;
using LEXEnprise.Blazor.Shared.Wrapper;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Clients.Pages
{
    public partial class ClientsList : IDisposable
    {
        [Parameter]
        public string PageTitle { get; set; }
        [Parameter]
        public string BreadCrumbTitle { get; set; }

        [Inject]
        protected IConfiguration Config { get; set; }

        [Inject]
        public ILookupService LookupService { get; set; }

        [Inject]
        public IClientsService ClientService { get; set; }

        private GetClientsRequest _getClientsRequest = new GetClientsRequest();

        [Inject]
        public HttpInterceptorService Interceptor { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        private IJSObjectReference _jsModule;

        [CascadingParameter] 
        public IModalService Modal { get; set; }

        public PageMetaData PageMetaData { get; set; } = new PageMetaData();

        public List<GetClientResponse> Clients = new List<GetClientResponse>();

        public List<Country> Countries = new List<Country>();
        
        
        protected override async Task OnInitializedAsync()
        {
            PageTitle = Config["PageTitles:ClientListTitle"];
            BreadCrumbTitle = "Clients List";
            Interceptor.RegisterEvent();

            _getClientsRequest.PageSize = int.Parse(Config["PaginationSettings:PageSize"]);

            await GetClients();
            await HideSpinner();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "/js/clients/clients.js");
            }
        }

        private async Task GetLookup()
        {
            Countries = await LookupService.GetCountries();
        }

        private async Task GetClients()
        {
            //Clients.Clear();
            var response = await ClientService.GetClients(_getClientsRequest);

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

        private async Task GetFilteredClients(FilterClientsModel filter)
        {
            await DisplaySpinner();
            try
            {
                var filterRequest = new GetFilteredClientsRequest
                {
                    MetaData = new PageMetaData { PageNumber = _getClientsRequest.PageNumber, PageSize = _getClientsRequest.PageSize },
                    Filter = filter
                };
                var response = await ClientService.GetFilteredClients(filterRequest);

                if (response.Succeeded)
                {
                    Clients = response.Data.ToList();
                    PageMetaData = response.PageMetaData;
                }
            }
            finally
            {
                await HideSpinner();
            }
        }

        private async Task ShowFilterModal()
        {
            var options = new ModalOptions { UseCustomLayout = true };
            var parameters = new ModalParameters();
            parameters.Add(nameof(FilterClientsModal.Title), "Advance Filter");
            var filterModalForm = Modal.Show<FilterClientsModal>("Custom Layout", parameters, options);
            var result = await filterModalForm.Result;

            if (!result.Cancelled)
            {
                var filter = result.Data != null ? (result.Data as FilterClientsModel) : null;

                await GetFilteredClients(filter);
            }

        }

        public void Dispose() => Interceptor.DisposeEvent();
    }
}
