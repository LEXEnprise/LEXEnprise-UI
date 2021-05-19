using LEXEnprise.Blazor.Application.Models.Clients;
using LEXEnprise.Shared.Models.Paging;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Application.Services.Clients
{
    public interface IClientsService : IService
    {
        Task<PaginatedResult<GetClientResponse>> GetClients(GetClientsRequest request);
        Task<PaginatedResult<GetClientResponse>> GetFilteredClients(GetFilteredClientsRequest request);
    }
}
