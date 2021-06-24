using Blazored.Modal;
using Blazored.Modal.Services;
using LEXEnprise.Blazor.Application.Models.CaseFolders;
using LEXEnprise.Blazor.Application.Models.Clients;
using LEXEnprise.Blazor.Application.Models.Lookup.Matters;
using LEXEnprise.Blazor.Application.Services;
using LEXEnprise.Blazor.Application.Services.CaseFolders;
using LEXEnprise.Blazor.Application.Services.Lookup;
using LEXEnprise.Blazor.Matters.Components.Lookup;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Matters.Pages
{
    public partial class AddCaseFolder : IDisposable
    {
        [Parameter]
        public string PageTitle { get; set; } = "Add Case Folder";

        [Parameter]
        public List<CaseGroup> CaseGroups { get; set; } = new List<CaseGroup>();
        
        [Parameter]
        public List<FolderStatus> FolderStatuses { get; set; } = new List<FolderStatus>();
        [Parameter]
        public List<FolderType> FolderTypes { get; set; } = new List<FolderType>();

        private AddCaseFolderRequest _addCaseFolderModel;
        [Inject]
        public HttpInterceptorService Interceptor { get; set; }

        [Inject]
        public ILookupService LookupService { get; set; }

        [Inject]
        public ICaseFoldersService CaseFoldersService { get; set; }

        [Inject]
        public NavigationManager Navigator { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [CascadingParameter]
        public IModalService Modal { get; set; }

        private IJSObjectReference _jsModule;

        private string _clientNameId = "clientNameId";
        private string _caseFolderDescId = "caseFolderDescId";

        private async Task LoadLookups()
        {
            CaseGroups = await LookupService.GetCaseGroups();
            FolderStatuses = await LookupService.GetFolderStatuses();
            FolderTypes = await LookupService.GetFolderTypes();
        }

        protected override async Task OnInitializedAsync()
        {
            Interceptor.RegisterEvent();
            _addCaseFolderModel = new AddCaseFolderRequest();
            await LoadLookups();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "/js/common.js");
                
                await FocusOnClientName();
            }
        }

        private async Task FocusOnClientName() => await _jsModule.InvokeVoidAsync("focusOnElementById", _clientNameId);
        private async Task FocusOnCaseFolderDesc() => await _jsModule.InvokeVoidAsync("focusOnElementById", _caseFolderDescId);

        private async Task GoTop() => await _jsModule.InvokeVoidAsync("OnScrollEvent");

        private async Task OnInvalidCaseFolderSubmit()
        {
            await GoTop();
        }

        private async Task ShowClientsLookup()
        {
            var options = new ModalOptions { UseCustomLayout = true };
            var parameters = new ModalParameters();
            parameters.Add(nameof(ClientsSelectionModal.Title), "Client Selection");
            var clientSelectionModal = Modal.Show<ClientsSelectionModal>("Custom Layout", parameters, options);
            var result = await clientSelectionModal.Result;

            if (!result.Cancelled)
            {
                var selected = result.Data as ClientInfo;

                _addCaseFolderModel.ClientId = selected.Id;
                _addCaseFolderModel.ClientNumber = selected.ClientNumber;
                _addCaseFolderModel.ClientName = selected.ClientName;

                await FocusOnCaseFolderDesc();
            }

        }

        private async Task<ModalResult> ShowLawyersLookup()
        {
            var options = new ModalOptions { UseCustomLayout = true };
            var parameters = new ModalParameters();
            parameters.Add(nameof(LawyersSelectionModal.Title), "Lawyer Selection");
            var lawyersSelectionModal = Modal.Show<LawyersSelectionModal>("Custom Layout", parameters, options);
            var result = await lawyersSelectionModal.Result;

            return result;
            
        }

        private async Task ShowSupervisingLawyersLookup()
        {
            var result = await ShowLawyersLookup();

            if (!result.Cancelled)
            {
                var selected = result.Data as Lawyer;

                _addCaseFolderModel.SupervisingLawyerId = selected.Id;
                _addCaseFolderModel.SupervisingLawyer = selected.Fullname;
            }
        }

        private async Task ShowCaseOwnerLookup()
        {
            var result = await ShowLawyersLookup();

            if (!result.Cancelled)
            {
                var selected = result.Data as Lawyer;

                _addCaseFolderModel.CaseOwnerId = selected.Id;
                _addCaseFolderModel.CaseOwner = selected.Fullname;
            }
        }

        private async Task OnSubmitCaseFolder()
        {
            var result = await CaseFoldersService.AddCaseFolder(_addCaseFolderModel);

            if (result != null)
                Navigator.NavigateTo("/casefolders");

            Navigator.NavigateTo("/500");
        }

        private void Cancel()
        {
            Navigator.NavigateTo("/casefolders");
        }

        public void Dispose() => Interceptor.DisposeEvent();
    }
}
