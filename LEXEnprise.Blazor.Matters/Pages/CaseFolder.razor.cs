using Blazored.Modal;
using Blazored.Modal.Services;
using LEXEnprise.Blazor.Application.Models.Matters;
using LEXEnprise.Blazor.Application.Services.CaseFolders;
using LEXEnprise.Blazor.Matters.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;
using CaseFolderModels = LEXEnprise.Blazor.Application.Models.CaseFolders;
using MattersModels = LEXEnprise.Blazor.Application.Models.Matters;

namespace LEXEnprise.Blazor.Matters.Pages
{
    public partial class CaseFolder
    {
        [Parameter]
        public int CaseFolderId { get; set; }

        [Parameter]
        public string PageTitle { get; set; } = "Case Folder & Matters";

        [Inject]
        public ICaseFoldersService CaseFoldersService { get; set; }

        [Inject]
        public NavigationManager Navigator { get; set; }

        private CaseFolderModels.CaseFolder _caseFolderData { get; set; }
        private List<MattersModels.Matter> _matters { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        private IJSObjectReference _jsModule;

        [CascadingParameter]
        public IModalService Modal { get; set; }

        private void InitializeDataHolders()
        {
            _caseFolderData = new CaseFolderModels.CaseFolder();
            _matters = new List<MattersModels.Matter>();
        }
        protected override async Task OnInitializedAsync()
        {
            InitializeDataHolders();

            await GetCaseFolder();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/LEXEnprise.Blazor.Matters/js/casefolders.js");
            }
        }

        private async Task GetCaseFolder()
        {
            await DisplaySpinner();
            try
            {
                var result = await CaseFoldersService.GetCaseFolder(CaseFolderId);

                _caseFolderData = result.Data.CaseFolder;

                if (_caseFolderData.Matters != null)
                    _matters.AddRange(_caseFolderData.Matters);
            }
            finally
            {
                await HideSpinner();
            }
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

        private async Task ShowHandlingLawyers(List<MatterHandlingLawyer> lawyers)
        {
            var result = await ShowLawyers(lawyers);
        }

        private async Task<ModalResult> ShowLawyers(List<MatterHandlingLawyer> lawyers)
        {
            var options = new ModalOptions { UseCustomLayout = true };
            var parameters = new ModalParameters();
            parameters.Add(nameof(HandlingLawyersModal.HandlingLawyers), lawyers);
            parameters.Add(nameof(HandlingLawyersModal.Title), "Handling Lawyers");
            var filterModalForm = Modal.Show<HandlingLawyersModal>("Custom Layout", parameters, options);
            
            return await filterModalForm.Result;
        }

    }
}
