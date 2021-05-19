using LEXEnprise.Blazor.Shared.Wrapper;

namespace LEXEnprise.Blazor.Application.Models.Clients
{
    public class GetFilteredClientsRequest
    {
        public PageMetaData MetaData { get; set; }
        public FilterClientsModel Filter { get; set; }
        public string SortString { get; set; }
    }
}
