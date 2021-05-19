using LEXEnprise.Blazor.Application.Models.Lookup;
using LEXEnprise.Blazor.Application.Routes;
using System.Net.Http;
using System.Threading.Tasks;
using LEXEnprise.Blazor.Infrastructure.Extensions;
using System.Collections.Generic;
using LEXEnprise.Blazor.Infrastructure.Helpers;

namespace LEXEnprise.Blazor.Application.Services.Lookup
{
    public class LookupService : ServiceBase, ILookupService
    {
        private const string CountriesKey = "CountriesKey";
        private const string ClientTypesKey = "ClientTypesKey";
        private const string IndustriesKey = "IndustriesKey";
        private const string CurrenciesKey = "CurrenciesKey";
        private const string ClientStatusesKey = "ClientStatusesKey";

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
    }
}
