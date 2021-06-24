using Blazored.Modal;
using Blazored.Modal.Services;
using LEXEnprise.Blazor.Application.Models.Lookup.Matters;
using LEXEnprise.Blazor.Application.Services;
using LEXEnprise.Blazor.Application.Services.Lookup;
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
    public partial class LawyersSelectionModal : IDisposable
    {
        [CascadingParameter]
        public BlazoredModalInstance BlazoredModal { get; set; }

        [Parameter]
        public string Title { get; set; } = "Lawyers Selection";
        [Parameter]
        public int CaseGroupId { get; set; }

        public PageMetaData PageMetaData { get; set; } = new PageMetaData();

        public List<GetLawyerResponse> Lawyers { get; set; } = new List<GetLawyerResponse>();

        private GetLawyersRequest _getLawyersRequest = new GetLawyersRequest();

        [Inject]
        public ILookupService LookupService { get; set; }

        [Inject]
        public HttpInterceptorService Interceptor { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        private IJSObjectReference _jsModule;

        private async Task GetLawyers()
        {

            if (CaseGroupId > 0)
            {
                Lawyers = await LookupService.GetLawyersByGroup(CaseGroupId);
            }
            else
            {
                var response = await LookupService.GetPaginatedLawyers(_getLawyersRequest);

                if (response.Succeeded)
                {
                    Lawyers = response.Data.ToList();
                    PageMetaData = response.PageMetaData;
                }
            }
        }

        private async Task LoadLawyers()
        {
            await DisplaySpinner();
            try
            {
                await GetLawyers();
            }
            finally
            {
                await HideSpinner();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            Interceptor.RegisterEvent();
            await GetLawyers();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "/js/commons.js");
            }
        }

        private async Task SelectedPage(int page)
        {
            _getLawyersRequest.PageNumber = page;
            await LoadLawyers();
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
            _getLawyersRequest.PageNumber = 1;
            _getLawyersRequest.SearchString = searchTerm;
            await LoadLawyers();
        }

        private async Task Cancel() => await BlazoredModal.CancelAsync();

        private async Task SelectRow(int id, string fullname, string email)
        {
            var selected = new Lawyer
            {
                Id = id,
                Fullname = fullname,
                EmailAddress = email
            };

            await BlazoredModal.CloseAsync(ModalResult.Ok(selected));
        }

        public void Dispose() => Interceptor.DisposeEvent();
    }
}
