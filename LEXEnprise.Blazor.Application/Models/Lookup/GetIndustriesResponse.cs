using LEXEnprise.Blazor.Shared.Wrapper;
using System.Collections.Generic;
using LookupDTOs = LEXEnprise.Blazor.Application.Models.Lookup;

namespace LEXEnprise.Blazor.Application.Models.Lookup
{
    public class GetIndustriesResponse : Result<List<LookupDTOs.Industry>>
    {
        public GetIndustriesResponse(List<LookupDTOs.Industry> industries)
        {
            Data = industries;
        }
    }
}
