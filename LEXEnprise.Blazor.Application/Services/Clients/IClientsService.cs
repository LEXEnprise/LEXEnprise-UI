using LEXEnprise.Blazor.Application.DTOs.Clients;
using LEXEnprise.Blazor.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Application.Services.Clients
{
    public interface IClientsService : IService
    {
        Task<PaginatedResult<GetClientResponse>> GetClients(GetClientsRequest request);
    }
}
