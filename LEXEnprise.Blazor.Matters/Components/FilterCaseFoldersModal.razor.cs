using Blazored.Modal;
using Blazored.Modal.Services;
using LEXEnprise.Blazor.Application.Models.CaseFolders;
using LEXEnprise.Blazor.Application.Models.Lookup.Matters;
using LEXEnprise.Blazor.Application.Services.Lookup;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Matters.Components
{
    public partial class FilterCaseFoldersModal
    {
        [CascadingParameter]
        public BlazoredModalInstance BlazoredModal { get; set; }

        [Parameter]
        public string Title { get; set; } = "Advance Filter - Case Folder";
        [Parameter]
        public List<CaseGroup> CaseGroups { get; set; } = new List<CaseGroup>();

        [Parameter]
        public List<FolderType> FolderTypes { get; set; } = new List<FolderType>();

        [Inject]
        public ILookupService LookupService { get; set; }

        FilterCaseFoldersModel CaseFolderFilter = new FilterCaseFoldersModel();

        protected override async Task OnInitializedAsync()
        {
            CaseGroups = await LookupService.GetCaseGroups();
            FolderTypes = await LookupService.GetFolderTypes();
        }

        private async Task SubmitFilter()
        {
            await BlazoredModal.CloseAsync(ModalResult.Ok(CaseFolderFilter));
        }

        private async Task Cancel() => await BlazoredModal.CancelAsync();
    }
}
