using LEXEnprise.Blazor.Application.Models.Clients;
using LEXEnprise.Blazor.Shared.Wrapper;
using LEXEnprise.Shared.Models.Paging;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Application.Services.Clients
{
    public interface IClientsService : IService
    {
        Task<PaginatedResult<GetClientResponse>> GetClients(GetClientsRequest request);
        Task<PaginatedResult<GetClientResponse>> GetFilteredClients(GetFilteredClientsRequest request);
        Task<IResult<int>> AddClient(AddClientRequest request);
    }
}
