using LEXEnprise.Blazor.Application.DTOs.Clients;
using LEXEnprise.Blazor.Application.Services.Account;
using LEXEnprise.Blazor.Application.Services.Clients;
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
        public IClientsService ClientService { get; set; }

        private GetClientsRequest _getClientsRequest = new GetClientsRequest();

        [Inject]
        public HttpInterceptorService Interceptor { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        private IJSObjectReference _jsModule;

        public PageMetaData PageMetaData { get; set; } = new PageMetaData();

        public List<GetClientResponse> Clients = new List<GetClientResponse>();

        //protected override void OnInitialized()
        protected async override Task OnInitializedAsync()
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
                _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./js/clients/clients.js");
            }
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

        //private async Task RefreshClients()
        //{
        //    await GetClients();
        //}
        private async Task SelectedPage(int page)
        {
            _getClientsRequest.PageNumber = page;
            
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

        //private async Task DisplaySpinner() => await _jsModule.InvokeVoidAsync("displaySpinner", _spinnerRef);
        private async Task DisplaySpinner() => await _jsModule.InvokeVoidAsync("displaySpinner", "spinner");

        private async Task HideSpinner() => await _jsModule.InvokeVoidAsync("hideSpinner", "spinner");

        public void Dispose() => Interceptor.DisposeEvent();
    }
}
