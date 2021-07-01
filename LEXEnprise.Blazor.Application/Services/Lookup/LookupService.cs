using LEXEnprise.Blazor.Application.Models.Lookup;
using LEXEnprise.Blazor.Application.Routes;
using System.Net.Http;
using System.Threading.Tasks;
using LEXEnprise.Blazor.Infrastructure.Extensions;
using System.Collections.Generic;
using LEXEnprise.Blazor.Infrastructure.Helpers;
using LEXEnprise.Blazor.Application.Models.Lookup.Matters;
using System;
using LEXEnprise.Shared.Models.Paging;

namespace LEXEnprise.Blazor.Application.Services.Lookup
{
    public class LookupService : ServiceBase, ILookupService
    {
        private const string CountriesKey = "CountriesKey";
        private const string ClientTypesKey = "ClientTypesKey";
        private const string IndustriesKey = "IndustriesKey";
        private const string CurrenciesKey = "CurrenciesKey";
        private const string ClientStatusesKey = "ClientStatusesKey";
        private const string CaseGroupsKey = "CaseGroupsKey";
        private const string LawyersKey = "LawyersKey";
        private const string FolderStatusesKey = "FolderStatusesKey";
        private const string FolderTypesKey = "FolderTypesKey";
        private const string MatterStagesKey = "MatterStagesKey";
        private const string MatterStatusesKey = "MatterStatusesKey";
        private const string CaseTypesKey = "CaseTypesKey";
        private const string ParalegalsKey = "ParalegalsKey";
        private const string ApplicationTypesKey = "ApplicationTypesKey";

        private readonly ILocalStorageHelper _localStorage;
        public LookupService(HttpClient httpClient, ILocalStorageHelper localStorage)
            : base(httpClient)
        {
            _localStorage = localStorage;
        }

        public async Task<List<Country>> GetCountries()
        {
            var countries = await _localStorage.GetItemAsync<List<Country>>(CountriesKey);

            if (countries == null)
            {
                var response = await _httpClient.GetAsync(LookupsEndpoint.GetCountries);
                var result = await response.ToResult<List<Country>>();

                countries = result.Data;
                await _localStorage.SetItemAsync<List<Country>>(CountriesKey, countries);
            }

            return countries;
        }

        public async Task<List<State>> GetStatesByCountry(int countryId)
        {
            var response = await _httpClient.GetAsync($"{LookupsEndpoint.GetStates}/{countryId}");

            var result = await response.ToResult<List<State>>();
            var states = result.Data;

            return states;
        }

        public async Task<List<City>> GetCitiesByState(int stateId)
        {
            var response = await _httpClient.GetAsync($"{LookupsEndpoint.GetCities}/{stateId}");

            var result = await response.ToResult<List<City>>();
            var cities = result.Data;

            return cities;
        }

        public async Task<List<ClientType>> GetClientTypes()
        {
            var clientTypes = await _localStorage.GetItemAsync<List<ClientType>>(ClientTypesKey);

            if (clientTypes == null)
            {
                var response = await _httpClient.GetAsync(LookupsEndpoint.GetClientTypes);
                var result = await response.ToResult<List<ClientType>>();

                clientTypes = result.Data;
                await _localStorage.SetItemAsync<List<ClientType>>(ClientTypesKey, clientTypes);
            }

            return clientTypes;
        }

        public async Task<List<Industry>> GetIndustries()
        {
            var industries = await _localStorage.GetItemAsync<List<Industry>>(IndustriesKey);

            if (industries == null)
            {
                var response = await _httpClient.GetAsync(LookupsEndpoint.GetIndustries);
                var result = await response.ToResult<List<Industry>>();

                industries = result.Data;
                await _localStorage.SetItemAsync<List<Industry>>(IndustriesKey, industries);
            }

            return industries;
        }

        public async Task<List<Currency>> GetCurrencies()
        {
            var currencies = await _localStorage.GetItemAsync<List<Currency>>(CurrenciesKey);

            if (currencies == null)
            {
                var response = await _httpClient.GetAsync(LookupsEndpoint.GetCurrencies);
                var result = await response.ToResult<List<Currency>>();

                currencies = result.Data;
                await _localStorage.SetItemAsync<List<Currency>>(CurrenciesKey, currencies);
            }

            return currencies;
        }

        public async Task<List<ClientStatus>> GetClientStatuses()
        {
            var statuses = await _localStorage.GetItemAsync<List<ClientStatus>>(ClientStatusesKey);

            if (statuses == null)
            {
                var response = await _httpClient.GetAsync(LookupsEndpoint.GetClientStatuses);
                var result = await response.ToResult<List<ClientStatus>>();

                statuses = result.Data;
                await _localStorage.SetItemAsync<List<ClientStatus>>(ClientStatusesKey, statuses);
            }

            return statuses;
        }

        public async Task<List<CaseGroup>> GetCaseGroups()
        {
            //var caseGroups = await _localStorage.GetItemAsync<List<CaseGroup>>(CaseGroupsKey);

            //if (caseGroups == null)
            //{
            //    var response = await _httpClient.GetAsync(LookupsEndpoint.GetCaseGroups);
            //    var result = await response.ToResult<List<CaseGroup>>();

            //    caseGroups = result.Data;
            //    await _localStorage.SetItemAsync<List<CaseGroup>>(CaseGroupsKey, caseGroups);
            //}

            //return caseGroups;

            var response = await _httpClient.GetAsync(LookupsEndpoint.GetCaseGroups);
            var result = await response.ToResult<List<CaseGroup>>();

            var caseGroups = result.Data;

            return caseGroups;
        }

        public async Task<List<Lawyer>> GetLawyers()
        {
            var lawyers = await _localStorage.GetItemAsync<List<Lawyer>>(CaseGroupsKey);

            if (lawyers == null)
            {
                var response = await _httpClient.GetAsync(LookupsEndpoint.GetLawyers);
                var result = await response.ToResult<List<Lawyer>>();

                lawyers = result.Data;
                await _localStorage.SetItemAsync<List<Lawyer>>(CaseGroupsKey, lawyers);
            }

            return lawyers;
        }

        public async Task<List<FolderStatus>> GetFolderStatuses()
        {
            //var folderStatuses = await _localStorage.GetItemAsync<List<FolderStatus>>(FolderStatusesKey);

            //if (folderStatuses == null)
            //{
            //    var response = await _httpClient.GetAsync(LookupsEndpoint.GetFolderStatuses);
            //    var result = await response.ToResult<List<FolderStatus>>();

            //    folderStatuses = result.Data;
            //    await _localStorage.SetItemAsync<List<FolderStatus>>(FolderStatusesKey, folderStatuses);
            //}

            //return folderStatuses;

            var response = await _httpClient.GetAsync(LookupsEndpoint.GetFolderStatuses);
            var result = await response.ToResult<List<FolderStatus>>();

            var folderStatuses = result.Data;

            return folderStatuses;
        }

        public async Task<List<FolderType>> GetFolderTypes()
        {
            //var folderTypes = await _localStorage.GetItemAsync<List<FolderType>>(FolderTypesKey);

            //if (folderTypes == null)
            //{
            //    var response = await _httpClient.GetAsync(LookupsEndpoint.GetFolderTypes);
            //    var result = await response.ToResult<List<FolderType>>();

            //    folderTypes = result.Data;
            //    await _localStorage.SetItemAsync<List<FolderType>>(FolderTypesKey, folderTypes);
            //}

            //return folderTypes;

            var response = await _httpClient.GetAsync(LookupsEndpoint.GetFolderTypes);
            var result = await response.ToResult<List<FolderType>>();

            var folderTypes = result.Data;

            return folderTypes;
        }

        public async Task<PaginatedResult<GetLawyerResponse>> GetPaginatedLawyers(GetLawyersRequest request)
        {
            try
            {
                var req = Routes.LookupsEndpoint.GetPagedLawyers(request.PageNumber,
                            request.PageSize, request.SearchString, request.SortString);
                var response = await _httpClient.GetAsync(req);

                return await response.ToPaginatedResult<GetLawyerResponse>();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<List<GetLawyerResponse>> GetLawyersByGroup(int caseGroupId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{LookupsEndpoint.GetLawyersByGroup}/{caseGroupId}");
                var result =  await response.ToResult<List<GetLawyerResponse>>();

                var lawyers = result.Data;

                return lawyers;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<List<MatterStage>> GetMatterStages(int caseTypeId)
        {
            //var matterStages = await _localStorage.GetItemAsync<List<MatterStage>>(MatterStagesKey);

            //if (matterStages == null)
            //{
            //    var response = await _httpClient.GetAsync($"{LookupsEndpoint.GetMatterStages}/{caseTypeId}");
            //    var result = await response.ToResult<List<MatterStage>>();

            //    matterStages = result.Data;
            //    await _localStorage.SetItemAsync<List<MatterStage>>(MatterStagesKey, result.Data);
            //}

            //return matterStages;

            var response = await _httpClient.GetAsync($"{LookupsEndpoint.GetMatterStages}/{caseTypeId}");
            var result = await response.ToResult<List<MatterStage>>();

            var matterStages = result.Data;

            return matterStages;
        }

        public async Task<List<MatterStatus>> GetMatterStatuses(int caseTypeId)
        {
            //var matterStatuses = await _localStorage.GetItemAsync<List<MatterStatus>>(MatterStatusesKey);

            //if (matterStatuses == null)
            //{
            //    var response = await _httpClient.GetAsync($"{LookupsEndpoint.GetMatterStatuses}/{caseTypeId}");
            //    var result = await response.ToResult<List<MatterStatus>>();

            //    matterStatuses = result.Data;
            //    await _localStorage.SetItemAsync<List<MatterStatus>>(MatterStatusesKey, result.Data);
            //}

            //return matterStatuses;

            var response = await _httpClient.GetAsync($"{LookupsEndpoint.GetMatterStatuses}/{caseTypeId}");
            var result = await response.ToResult<List<MatterStatus>>();

            var matterStatuses = result.Data;

            return matterStatuses;
        }

        public async Task<List<CaseType>> GetCaseTypes()
        {
            //var caseTypes = await _localStorage.GetItemAsync<List<CaseType>>(CaseTypesKey);

            //if (caseTypes == null)
            //{
            //    var response = await _httpClient.GetAsync(LookupsEndpoint.GetCaseTypes);
            //    var result = await response.ToResult<List<CaseType>>();

            //    caseTypes = result.Data;
            //    await _localStorage.SetItemAsync<List<CaseType>>(CaseTypesKey, caseTypes);
            //}

            //return caseTypes;

            var response = await _httpClient.GetAsync(LookupsEndpoint.GetCaseTypes);
            var result = await response.ToResult<List<CaseType>>();

            var caseTypes = result.Data;

            return caseTypes;
        }

        public async Task<List<Paralegal>> GetParalegals(int caseGroupId)
        {
            //var paralegals = await _localStorage.GetItemAsync<List<Paralegal>>(ParalegalsKey);

            //if (paralegals == null)
            //{
            //    var response = await _httpClient.GetAsync($"{LookupsEndpoint.GetParalegals}/{caseGroupId}");
            //    var result = await response.ToResult<List<Paralegal>>();

            //    paralegals = result.Data;
            //    await _localStorage.SetItemAsync<List<Paralegal>>(ParalegalsKey, paralegals);
            //}

            //return paralegals;

            var response = await _httpClient.GetAsync($"{LookupsEndpoint.GetParalegals}/{caseGroupId}");
            var result = await response.ToResult<List<Paralegal>>();
            var paralegals = result.Data;

            return paralegals;
        }

        public async Task<PaginatedResult<GetApplicantResponse>> GetPaginatedApplicants(GetApplicantsRequest request)
        {
            try
            {
                var req = Routes.LookupsEndpoint.GetPagedApplicants(request.PageNumber,
                            request.PageSize, request.SearchString, request.SortString);
                var response = await _httpClient.GetAsync(req);

                return await response.ToPaginatedResult<GetApplicantResponse>();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<List<ApplicationType>> GetApplicationTypes()
        {
            //var applicationTypes = await _localStorage.GetItemAsync<List<ApplicationType>>(ApplicationTypesKey);

            //if (applicationTypes == null)
            //{
            //    var response = await _httpClient.GetAsync(LookupsEndpoint.GetApplicationTypes);
            //    var result = await response.ToResult<List<ApplicationType>>();

            //    applicationTypes = result.Data;
            //    await _localStorage.SetItemAsync<List<ApplicationType>>(ApplicationTypeKey, applicationTypes);
            //}

            //return applicationTypes;

            var response = await _httpClient.GetAsync(LookupsEndpoint.GetApplicationTypes);
            var result = await response.ToResult<List<ApplicationType>>();

            var applicationTypes = result.Data;

            return applicationTypes;
        }

        public async Task<List<ClientCategory>> GetClientCategories()
        {
            //var applicationTypes = await _localStorage.GetItemAsync<List<ApplicationType>>(ApplicationTypesKey);

            //if (applicationTypes == null)
            //{
            //    var response = await _httpClient.GetAsync(LookupsEndpoint.GetApplicationTypes);
            //    var result = await response.ToResult<List<ApplicationType>>();

            //    applicationTypes = result.Data;
            //    await _localStorage.SetItemAsync<List<ApplicationType>>(ApplicationTypeKey, applicationTypes);
            //}

            //return applicationTypes;

            var response = await _httpClient.GetAsync(LookupsEndpoint.GetClientCategories);
            var result = await response.ToResult<List<ClientCategory>>();

            var categories = result.Data;

            return categories;
        }
    }
}
