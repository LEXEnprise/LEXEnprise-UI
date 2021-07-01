using LEXEnprise.Blazor.Application.Models.Clients;
using LEXEnprise.Blazor.Infrastructure.Extensions;
using LEXEnprise.Blazor.Shared.Wrapper;
using LEXEnprise.Shared.Models.Paging;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Application.Services.Clients
{
    public class ClientsService : ServiceBase, IClientsService
    {
        public ClientsService(HttpClient httpClient) : base(httpClient) { }

        public async Task<PaginatedResult<GetClientResponse>> GetClients(GetClientsRequest request)
        {
            try
            {
                var req = Routes.ClientsEndpoint.GetPaged(request.PageNumber,
                            request.PageSize, request.SearchString, request.SortString);
                var response = await _httpClient.GetAsync(req);

                return await response.ToPaginatedResult<GetClientResponse>();
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public async Task<PaginatedResult<GetClientResponse>> GetFilteredClients(GetFilteredClientsRequest request)
        {
            try
            {
                request.MetaData.PageNumber = 1;
                request.SortString = request.SortString ?? "ClientName";
                var response = await _httpClient.PostAsJsonAsync(Routes.ClientsEndpoint.FilteredPaged, request);
                
                if (response.IsSuccessStatusCode)
                    return await response.ToPaginatedResult<GetClientResponse>();

                return null;                   
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IResult<int>> AddClient(AddClientRequest request)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(Routes.ClientsEndpoint.Add, request);

                if (response.IsSuccessStatusCode)
                    return await response.ToResult<int>();

                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IResult<GetClientResponse>> Get(int clientId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{Routes.ClientsEndpoint.Get}/{clientId}");

                if (response.IsSuccessStatusCode)
                    return await response.ToResult<GetClientResponse>();

                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IResult<int>> UpdateClient(UpdateClientRequest request)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(Routes.ClientsEndpoint.Update, request);

                if (response.IsSuccessStatusCode)
                    return await response.ToResult<int>();

                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
