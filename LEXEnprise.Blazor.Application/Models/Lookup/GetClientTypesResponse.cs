using LEXEnprise.Blazor.Shared.Wrapper;
using System.Collections.Generic;
using LookupDTOs = LEXEnprise.Blazor.Application.Models.Lookup;

namespace LEXEnprise.Blazor.Application.Models.Lookup
{
    public class GetClientTypesResponse : Result<List<LookupDTOs.ClientType>>
    {
        public GetClientTypesResponse(List<LookupDTOs.ClientType> countries)
        {
            Data = countries;
        }
    }
}
