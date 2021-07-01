using LEXEnprise.Blazor.Application.Models.Lookup;
using LEXEnprise.Blazor.Application.Models.Lookup.Matters;
using LEXEnprise.Shared.Models.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Application.Services.Lookup
{
    public interface ILookupService : IService
    {
        Task<List<Country>> GetCountries();
        Task<List<State>> GetStatesByCountry(int countryId);
        Task<List<City>> GetCitiesByState(int stateId);
        Task<List<ClientType>> GetClientTypes();
        Task<List<Industry>> GetIndustries();
        Task<List<Currency>> GetCurrencies();
        Task<List<ClientStatus>> GetClientStatuses();
        Task<List<CaseGroup>> GetCaseGroups();
        Task<List<Lawyer>> GetLawyers();
        Task<List<FolderStatus>> GetFolderStatuses();
        Task<List<FolderType>> GetFolderTypes();
        Task<PaginatedResult<GetLawyerResponse>> GetPaginatedLawyers(GetLawyersRequest request);
        Task<List<GetLawyerResponse>> GetLawyersByGroup(int caseGroupId);
        Task<List<MatterStage>> GetMatterStages(int caseTypeId);
        Task<List<MatterStatus>> GetMatterStatuses(int caseTypeId);
        Task<List<CaseType>> GetCaseTypes();
        Task<List<Paralegal>> GetParalegals(int caseGroupId);
        Task<PaginatedResult<GetApplicantResponse>> GetPaginatedApplicants(GetApplicantsRequest request);
        Task<List<ApplicationType>> GetApplicationTypes();
        Task<List<ClientCategory>> GetClientCategories();
    }
}
