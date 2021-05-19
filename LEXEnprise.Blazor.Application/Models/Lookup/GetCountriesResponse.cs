using LEXEnprise.Blazor.Shared.Wrapper;
using System.Collections.Generic;
using LookupDTOs = LEXEnprise.Blazor.Application.Models.Lookup;

namespace LEXEnprise.Blazor.Application.Models.Lookup
{
    public class GetCountriesResponse : Result<List<LookupDTOs.Country>>
    {
        public GetCountriesResponse(List<LookupDTOs.Country> countries)
        {
            Data = countries;
        }
    }
}
