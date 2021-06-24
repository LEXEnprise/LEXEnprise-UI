using Blazored.Modal;
using Blazored.Modal.Services;
using LEXEnprise.Blazor.Application.Models.CaseFolders;
using LEXEnprise.Blazor.Application.Services;
using LEXEnprise.Blazor.Application.Services.CaseFolders;
using LEXEnprise.Blazor.Application.Services.Lookup;
using LEXEnprise.Blazor.Matters.Components;
using LEXEnprise.Blazor.Shared.Wrapper;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Matters.Pages
{
    public partial class CaseFoldersList : IDisposable
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
        public ICaseFoldersService CaseFoldersService { get; set; }

        private GetCaseFoldersRequest _getCaseFoldersRequest = new GetCaseFoldersRequest();

        [Inject]
        public HttpInterceptorService Interceptor { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        private IJSObjectReference _jsModule;

        [CascadingParameter] 
        public IModalService Modal { get; set; }

        public PageMetaData PageMetaData { get; set; } = new PageMetaData();

        public List<GetCaseFolderResponse> CaseFolders = new List<GetCaseFolderResponse>();

        //public List<CaseGroup> CaseGroups = new List<CaseGroup>();
        //public List<FolderType> FolderTypes = new List<FolderType>();
        //public List<FolderStatus> FolderStatuses = new List<FolderStatus>();
        //public List<Lawyer> Lawyers = new List<Lawyer>();


        protected override async Task OnInitializedAsync()
        {
            PageTitle = Config["PageTitles:CaseFoldersListTitle"];
            BreadCrumbTitle = "Case Folders List";
            Interceptor.RegisterEvent();

            _getCaseFoldersRequest.PageSize = int.Parse(Config["PaginationSettings:PageSize"]);

            await GetCaseFolders();
            await HideSpinner();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/LEXEnprise.Blazor.Matters/js/casefolders.js");
            }
        }

        //private async Task GetLookup()
        //{
        //    CaseGroups = await LookupService.GetCaseGroups();
        //    Lawyers = await LookupService.GetLawyers();
        //    FolderTypes = await LookupService.GetFolderTypes();
        //    FolderStatuses = await LookupService.GetFolderStatuses();
        //}

        private async Task GetCaseFolders()
        {
            //Clients.Clear();
            var response = await CaseFoldersService.GetCaseFolders(_getCaseFoldersRequest);

            if (response.Succeeded)
            {
                CaseFolders = response.Data.ToList();
                PageMetaData = response.PageMetaData;
            }
        }

        private async Task LoadCaseFolders()
        {
            await DisplaySpinner();
            try
            {
                await GetCaseFolders();
            }
            finally
            {
                await HideSpinner();
            }
        }
        private async Task SelectedPage(int page)
        {
            _getCaseFoldersRequest.PageNumber = page;
            await LoadCaseFolders();
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
            _getCaseFoldersRequest.PageNumber = 1;
            _getCaseFoldersRequest.SearchString = searchTerm;
            await LoadCaseFolders();
        }

        private async Task GetFilteredCaseFolders(FilterCaseFoldersModel filter)
        {
            await DisplaySpinner();
            try
            {
                var filterRequest = new GetFilteredCaseFoldersRequest
                {
                    MetaData = new PageMetaData { PageNumber = _getCaseFoldersRequest.PageNumber, PageSize = _getCaseFoldersRequest.PageSize },
                    Filter = filter
                };
                var response = await CaseFoldersService.GetFilteredCaseFolders(filterRequest);

                if (response.Succeeded)
                {
                    CaseFolders = response.Data.ToList();
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
            parameters.Add(nameof(FilterCaseFoldersModal.Title), "Advance Filter - Case Folders");
            var filterModalForm = Modal.Show<FilterCaseFoldersModal>("Custom Layout", parameters, options);
            var result = await filterModalForm.Result;

            if (!result.Cancelled)
            {
                var filter = result.Data != null ? (result.Data as FilterCaseFoldersModel) : null;

                await GetFilteredCaseFolders(filter);
            }

        }

        public void Dispose() => Interceptor.DisposeEvent();
    }
}
