using Blazored.Modal;
using Blazored.Modal.Services;
using LEXEnprise.Blazor.Application.Constants;
using LEXEnprise.Blazor.Application.Models;
using LEXEnprise.Blazor.Application.Models.Clients;
using LEXEnprise.Blazor.Application.Models.Lookup;
using LEXEnprise.Blazor.Application.Services;
using LEXEnprise.Blazor.Application.Services.Clients;
using LEXEnprise.Blazor.Application.Services.Lookup;
using LEXEnprise.Blazor.Clients.Components;
using LEXEnprise.Blazor.Clients.Validations;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [CascadingParameter]
        public IModalService Modal { get; set; }

        private string _clientNameId = "clientNameId";
        private string _selectStatesId = "selectStatesId";
        private string _selectCitiesId = "selectedCitiesId";
        private AddClientCustomValidation _addClientValidation;
        private ElementReference _clientContactsRowRef;

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
        private async Task GoTop() => await _jsModule.InvokeVoidAsync("OnScrollEvent");

        private bool IsValidClientInfoEntries()
        {
            _addClientValidation.ClearErrors();
            var errors = new Dictionary<string, List<string>>();

            if (!_addClientModel.Contacts.Any())
            {
                errors.Add(nameof(_addClientModel.Contacts),
                    new() { "Contact is required" });
            }

            if (errors.Count > 0)
            {
                _addClientValidation.DisplayErrors(errors);
                return false;
            }

            return true;
        }

        private async Task OnValidSubmit()
        {
            if (!IsValidClientInfoEntries())
                await GoTop();
            else
            {
                var result = await ClientsService.AddClient(_addClientModel);

                if (result != null)
                    Navigator.NavigateTo("/clients");
            }
        }
        private async Task OnInvalidClientSubmit()
        {
            await GoTop();
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
        
        private async Task<ModalResult> ShowAddContact()
        {
            var options = new ModalOptions { UseCustomLayout = true };
            var parameters = new ModalParameters();
            parameters.Add(nameof(AddContactModal.Title), "Add Contact");
            parameters.Add(nameof(AddContactModal.Contacts), _addClientModel.Contacts);
            var applicantsSelectionModal = Modal.Show<AddContactModal>("Custom Layout", parameters, options);

            return await applicantsSelectionModal.Result;
        }

        private void AddContact(Contact newContact)
        {
            _addClientModel.Contacts.Add(new Contact
            {
                ContactPerson = newContact.ContactPerson,
                Address1 = newContact.Address1,
                Address2 = newContact.Address2,
                Email = newContact.Email,
                PhoneNumber = newContact.PhoneNumber,
                Mobile = newContact.Mobile,
                Position = newContact.Position,
                Remarks = newContact.Remarks,
                IsMainAccountOfficer = newContact.IsMainAccountOfficer
            });
        }

        private async Task ShowAddContactModal()
        {
            var result = await ShowAddContact();

            if (!result.Cancelled)
                AddContact(result.Data as Contact);
        }

        private void DeleteContact(string email)
        {
            var contact = _addClientModel.Contacts.FirstOrDefault(c => c.Email == email);

            if (contact != null)
                _addClientModel.Contacts.Remove(contact);
        }

        private void Cancel()
        {
            Navigator.NavigateTo("/clients");
        }

        public void Dispose() => Interceptor.DisposeEvent();
    }
}
