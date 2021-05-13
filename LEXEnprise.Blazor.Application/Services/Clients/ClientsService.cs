using LEXEnprise.Blazor.Application.DTOs.Clients;
using LEXEnprise.Blazor.Shared.Wrapper;
using System.Net.Http;
using System.Threading.Tasks;
using LEXEnprise.Blazor.Infrastructure.Extensions;
using LEXEnprise.Shared.Models.Paging;

namespace LEXEnprise.Blazor.Application.Services.Clients
{
    public class ClientsService : ServiceBase, IClientsService
    {
        public ClientsService(HttpClient httpClient) : base(httpClient) { }

        public async Task<PaginatedResult<GetClientResponse>> GetClients(GetClientsRequest request)
        {
            var req = Routes.ClientsEndpoint.GetPaged(request.PageNumber,
                            request.PageSize, request.SearchString, request.SortString);
            var response = await _httpClient.GetAsync(req);
            
            return await response.ToPaginatedResult<GetClientResponse>();
        }
    }
}
