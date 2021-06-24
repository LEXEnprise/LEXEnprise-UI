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
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Matters.Components.Lookup
{
    public partial class ApplicantSelectionModal : IDisposable
    {
        [CascadingParameter]
        public BlazoredModalInstance BlazoredModal { get; set; }

        [Parameter]
        public string Title { get; set; } = "Applicants Selection";

        public PageMetaData PageMetaData { get; set; } = new PageMetaData();

        public List<GetApplicantResponse> Applicants { get; set; } = new List<GetApplicantResponse>();

        private GetApplicantsRequest _getApplicantsRequest = new GetApplicantsRequest();

        [Inject]
        public ILookupService LookupService { get; set; }

        [Inject]
        public HttpInterceptorService Interceptor { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        private IJSObjectReference _jsModule;

        private async Task GetApplicants()
        {
            var response = await LookupService.GetPaginatedApplicants(_getApplicantsRequest);

            if (response.Succeeded)
            {
                Applicants = response.Data.ToList();
                PageMetaData = response.PageMetaData;
            }
        }

        private async Task LoadApplicants()
        {
            await DisplaySpinner();
            try
            {
                await GetApplicants();
            }
            finally
            {
                await HideSpinner();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            Interceptor.RegisterEvent();
            await GetApplicants();
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
            _getApplicantsRequest.PageNumber = page;
            await LoadApplicants();
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
            _getApplicantsRequest.PageNumber = 1;
            _getApplicantsRequest.SearchString = searchTerm;
            await LoadApplicants();
        }

        private async Task Cancel() => await BlazoredModal.CancelAsync();

        private async Task SelectRow(int id, string applicantName, string address, string email,
            string phoneNumber, string mobileNumber)
        {
            var selected = new Applicant
            {
                Id = id,
                ApplicantName = applicantName,
                Address = address,
                EmailAddress = email,
                PhoneNumber = phoneNumber,
                MobileNumber = mobileNumber
            };

            await BlazoredModal.CloseAsync(ModalResult.Ok(selected));
        }

        public void Dispose() => Interceptor.DisposeEvent();
    }
}
