using Blazored.Modal;
using Blazored.Modal.Services;
using LEXEnprise.Blazor.Application.Models.Lookup;
using LEXEnprise.Blazor.Application.Models.Lookup.Matters;
using LEXEnprise.Blazor.Application.Models.Matters;
using LEXEnprise.Blazor.Application.Services;
using LEXEnprise.Blazor.Application.Services.CaseFolders;
using LEXEnprise.Blazor.Application.Services.Lookup;
using LEXEnprise.Blazor.Application.Services.Matters;
using LEXEnprise.Blazor.Matters.Components.Lookup;
using LEXEnprise.Blazor.Matters.Mapping;
using LEXEnprise.Blazor.Matters.Validations;
using LEXEnprise.Blazor.Matters.ViewModels;
using LEXEnprise.Blazor.Shared.Enums;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseFoldersModels = LEXEnprise.Blazor.Application.Models.CaseFolders;

namespace LEXEnprise.Blazor.Matters.Pages
{
    public partial class AddIPMatter : IDisposable
    {
        [Parameter]
        public int CaseFolderId { get; set; }

        [Parameter]
        public string PageTitle { get; set; } = "Add IP Matter";

        [Inject]
        public HttpInterceptorService Interceptor { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        private IJSObjectReference _jsModule;
        private IJSObjectReference _jsAddIpModule;

        [CascadingParameter]
        public IModalService Modal { get; set; }

        private AddIPMatterModel _addIPMatterModel;

        private CaseFoldersModels.CaseFolder _caseFolderData { get; set; }
        private Matter _matter { get; set; }

        [Inject]
        public ILookupService LookupService { get; set; }

        [Inject]
        public ICaseFoldersService CaseFoldersService { get; set; }
        [Inject]
        public IMattersService MattersService { get; set; }

        [Inject]
        public NavigationManager Navigator { get; set; }
        [Parameter]
        public List<CaseType> CaseTypes { get; set; } = new List<CaseType>();
        [Parameter]
        public List<ApplicationType> ApplicationTypes { get; set; } = new List<ApplicationType>();
        [Parameter]
        public List<MatterStage> MatterStages { get; set; } = new List<MatterStage>();
        [Parameter]
        public List<Paralegal> Paralegals { get; set; } = new List<Paralegal>();
        [Parameter]
        public List<Country> Countries { get; set; } = new List<Country>();

        private string _selectStageId = "_selectStageId";
        private MattersCustomValidation _customValidation;
        private ElementReference _handlingLawyersRowRef;

        private async Task LoadLookups()
        {
            Paralegals = await LookupService.GetParalegals(_caseFolderData.CaseGroupId);
            CaseTypes = await LookupService.GetCaseTypes();
            ApplicationTypes = await LookupService.GetApplicationTypes();
            Countries = await LookupService.GetCountries();
        }

        private async Task GetCaseFolder()
        {
            var result = await CaseFoldersService.GetCaseFolder(CaseFolderId);

            _caseFolderData = result.Data.CaseFolder;
        }

        private void CreateEntryModels()
        {
            _addIPMatterModel = new AddIPMatterModel
            {
                CaseFolderId = _caseFolderData.Id,
                ClientId = _caseFolderData.ClientId,
                CaseFolderCode = _caseFolderData.CaseFolderCode,

                StageAsOfDate = DateTime.Now,
                FileDate = DateTime.Now,
                ApplicationDate = DateTime.Now,
                PublicationDate = DateTime.Now,
                CertificateDate = DateTime.Now,
                PCTApplicationDate = DateTime.Now,
                PCTLanguageDate = DateTime.Now,
                PCTPublicationDate = DateTime.Now,
                PriorityDate = DateTime.Now,
            };
        }

        protected override async Task OnInitializedAsync()
        {
            Interceptor.RegisterEvent();
            
            await GetCaseFolder();
            await LoadLookups();
            CreateEntryModels();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "/js/common.js");
                //_jsAddIpModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/LEXEnprise.Blazor.Matters/js/ipMatter.js");
            }
        }

        private async Task FocusOnMatterStage() => await _jsModule.InvokeVoidAsync("focusOnElementById", _selectStageId);

        private async Task OnChangeCaseType(ChangeEventArgs args)
        {
            if (args.Value != null)
            {
                var caseTypeId = int.Parse(args.Value.ToString());

                if (caseTypeId > 0)
                {
                    _addIPMatterModel.CaseTypeId = caseTypeId;
                    MatterStages = await LookupService.GetMatterStages(caseTypeId);
                    await FocusOnMatterStage();
                }
            }
        }

        private async Task GoTop() => await _jsModule.InvokeVoidAsync("OnScrollEvent");

        private bool IsValidHandlingLawyers()
        {
            _customValidation.ClearErrors();
            var errors = new Dictionary<string, List<string>>();

            if (!_addIPMatterModel.HandlingLawyers.Any())
            {
                errors.Add(nameof(_addIPMatterModel.HandlingLawyers),
                    new() { "Handling Lawyers is required" });
            }
            else
            {
                var mainLawyerCount = _addIPMatterModel.HandlingLawyers.Count(l => l.IsMainLawyer);

                if (mainLawyerCount > 1)
                {
                    errors.Add(nameof(_addIPMatterModel.HandlingLawyers),
                        new() { "There should be only one Main Handling Lawyer" });
                }

                if (mainLawyerCount == 0)
                {
                    errors.Add(nameof(_addIPMatterModel.HandlingLawyers),
                        new() { "There should be one Main Handling Lawyer" });
                }
            }

            if (errors.Count > 0)
            {
                _customValidation.DisplayErrors(errors);
                return false;
            }

            return true;
        }

        private async Task OnSubmitIPMatter()
        {
            if (!IsValidHandlingLawyers())
                await GoTop();
            else
            {
                var request = MattersMapper.MapToAddIPMatterRequest(_addIPMatterModel);
                var result = await MattersService.AddIPMatter(request);

                if (result != null)
                    Navigator.NavigateTo($"caseFolder/{_caseFolderData.Id}");
            }
                
        }

        private async Task OnInvalidIPMatterSubmit()
        {
            await GoTop();
        }

        private async Task<ModalResult> ShowApplicants()
        {
            var options = new ModalOptions { UseCustomLayout = true };
            var parameters = new ModalParameters();
            parameters.Add(nameof(ApplicantSelectionModal.Title), "Applicant Selection");
            var applicantsSelectionModal = Modal.Show<ApplicantSelectionModal>("Custom Layout", parameters, options);
            
            return await applicantsSelectionModal.Result;
        }

        private async Task ShowApplicantsLookup()
        {
            var result = await ShowApplicants();

            if (!result.Cancelled)
            {
                var selected = result.Data as Applicant;

                _addIPMatterModel.ApplicantId = selected.Id;
                _addIPMatterModel.ApplicantName = selected.ApplicantName;
            }
        }

        private async Task<ModalResult> ShowLawyersLookup()
        {
            var options = new ModalOptions { UseCustomLayout = true };
            var parameters = new ModalParameters();
            parameters.Add(nameof(LawyersSelectionModal.Title), "Lawyer Selection");
            parameters.Add(nameof(LawyersSelectionModal.CaseGroupId), _caseFolderData.CaseGroupId);
            var lawyersSelectionModal = Modal.Show<LawyersSelectionModal>("Custom Layout", parameters, options);
            var result = await lawyersSelectionModal.Result;

            return result;

        }

        private async Task ShowHandlingLawyersLookup()
        {
            var result = await ShowLawyersLookup();

            if (!result.Cancelled)
            {
                var selected = result.Data as Lawyer;

                if (_addIPMatterModel.HandlingLawyers.Any(l => l.LawyerId == selected.Id))
                {
                    _customValidation.ClearErrors();
                    var errors = new Dictionary<string, List<string>>();

                    errors.Add(nameof(_addIPMatterModel.HandlingLawyers),
                        new() { "You are not allowed to add previously selected lawyer" });

                    _customValidation.DisplayErrors(errors);
                    await GoTop();
                    return;
                }

                var handlingLawyer = new MatterHandlingLawyer
                {
                    LawyerId = selected.Id,
                    IsMainLawyer = false,
                    Action = DataActions.Add,
                    HandlingLawyer = new Lawyer
                    {
                        Fullname = selected.Fullname,
                        EmailAddress = selected.EmailAddress
                    }
                };

                _addIPMatterModel.HandlingLawyers.Add(handlingLawyer) ;
            }
        }


        private void Cancel()
        {
            Navigator.NavigateTo($"caseFolder/{_caseFolderData.Id}");
        }

        private async Task CheckMainLawyer(MatterHandlingLawyer handlingLawyer)
        {
            _customValidation.ClearErrors();
            var errors = new Dictionary<string, List<string>>();

            if (!handlingLawyer.IsMainLawyer)
            {
                if (_addIPMatterModel.HandlingLawyers.Any(l => l.IsMainLawyer && l.LawyerId != handlingLawyer.LawyerId))
                {
                    handlingLawyer.IsMainLawyer = false;
                    errors.Add(nameof(_addIPMatterModel.HandlingLawyers),
                        new() { "You already have a selected Main Lawyer. There should be only 1 Main Lawyer" });

                    _customValidation.DisplayErrors(errors);
                    await GoTop();
                    return;
                }

                handlingLawyer.IsMainLawyer = true;
            }
            else
                handlingLawyer.IsMainLawyer = false;
        }

        private async Task DeleteLawyer(string lawyerName, int lawyerId)
        {
            //var confirmed = await JSRuntime.InvokeAsync<bool>("confirm", $"Are you sure you want to delete this lawyer - {lawyerName}?");

            //if (confirmed)
            //{

            //}
            var lawyerToDelete = _addIPMatterModel.HandlingLawyers.FirstOrDefault(l => l.LawyerId == lawyerId);

            if (lawyerToDelete != null)
                _addIPMatterModel.HandlingLawyers.Remove(lawyerToDelete);
        }

        public void Dispose() => Interceptor.DisposeEvent();
    }
}
