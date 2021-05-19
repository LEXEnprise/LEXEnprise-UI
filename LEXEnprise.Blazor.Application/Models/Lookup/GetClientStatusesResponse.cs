using LEXEnprise.Blazor.Shared.Wrapper;
using System.Collections.Generic;
using LookupDTOs = LEXEnprise.Blazor.Application.Models.Lookup;

namespace LEXEnprise.Blazor.Application.Models.Lookup
{
    public class GetClientStatusesResponse : Result<List<LookupDTOs.ClientStatus>>
    {
        public GetClientStatusesResponse(List<LookupDTOs.ClientStatus> statuses)
        {
            Data = statuses;
        }
    }
}
