using LEXEnprise.Blazor.Application.Constants;
using LEXEnprise.Blazor.Application.Models.Clients;
using LEXEnprise.Blazor.Application.Models.Lookup;
using LEXEnprise.Blazor.Application.Services.Account;
using LEXEnprise.Blazor.Application.Services.Clients;
using LEXEnprise.Blazor.Application.Services.Lookup;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Clients.Pages
{
    public partial class AddNewClient : IDisposable
    {
        [Parameter]
        public string PageTitle { get; set; } = "Add Client";

        AddClientRequest _addClientModel;

        [Inject]
        public ILookupService LookupService { get; set; }
        [Inject]
        public IClientsService ClientsService { get; set; }
        [Inject]
        public NavigationManager Navigator { get; set; }
        [Inject]
        public HttpInterceptorService Interceptor { get; set; }

        [Parameter]
        public List<ClientType> ClientTypes { get; set; } = new List<ClientType>();
        [Parameter]
        public List<Industry> Industries { get; set; } = new List<Industry>();
        [Parameter]
        public List<Country> Countries { get; set; } = new List<Country>();
        [Parameter]
        public List<State> States { get; set; } = new List<State>();
        [Parameter]
        public List<City> Cities { get; set; } = new List<City>();
        [Parameter]
        public List<Currency> Currencies { get; set; } = new List<Currency>();

        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        private IJSObjectReference _jsModule;
        private string _clientNameId = "clientNameId";
        private string _selectStatesId = "selectStatesId";
        private string _selectCitiesId = "selectedCitiesId";

        private async Task LoadLookups()
        {
            _addClientModel = new AddClientRequest();
            _addClientModel.DateAcquired = DateTime.Now;

            ClientTypes = await LookupService.GetClientTypes();
            Industries = await LookupService.GetIndustries();

            Countries = await LookupService.GetCountries();
            States = await LookupService.GetStatesByCountry(LookupConstants.DEF_COUNTRYID);
            Currencies = await LookupService.GetCurrencies();
        }
        protected override async Task OnInitializedAsync()
        {
            Interceptor.RegisterEvent();
            await LoadLookups();

            _addClientModel.CountryId = LookupConstants.DEF_COUNTRYID;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "/js/clients/clients.js");
                await InitialDateAcquiredPicker();
                await FocusOnClientName();
            }
        }

        private async Task FocusOnClientName() => await _jsModule.InvokeVoidAsync("focusOnElementById", _clientNameId);
        private async Task FocusOnStates() => await _jsModule.InvokeVoidAsync("focusOnElementById", _selectStatesId);
        private async Task FocusOnCities() => await _jsModule.InvokeVoidAsync("focusOnElementById", _selectCitiesId);
        private async Task InitialDateAcquiredPicker() => await _jsModule.InvokeVoidAsync("initDateAcquiredDatePicker");

        private async Task OnValidSubmit()
        {
            var result = await ClientsService.AddClient(_addClientModel);

            if (result != null)
                Navigator.NavigateTo("/clients");
        }

        private async Task OnChangeCountry(ChangeEventArgs args)
        {
            if (args.Value != null)
            {
                var countryId = int.Parse(args.Value.ToString());

                if (countryId > 0)
                {
                    States = await LookupService.GetStatesByCountry(countryId);
                    await FocusOnStates();
                }
            }
        }

        private async Task OnChangeState(ChangeEventArgs args)
        {
            if (args.Value != null)
            {
                var stateId = int.Parse(args.Value.ToString());

                if (stateId > 0)
                {
                    _addClientModel.StateId = stateId;
                    Cities = await LookupService.GetCitiesByState(stateId);
                    await FocusOnCities();
                }
                    
            }
        }

        private void Cancel()
        {
            Navigator.NavigateTo("/clients");
        }

        public void Dispose() => Interceptor.DisposeEvent();
    }
}
