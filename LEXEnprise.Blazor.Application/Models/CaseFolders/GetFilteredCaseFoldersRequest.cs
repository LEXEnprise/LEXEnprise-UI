using LEXEnprise.Blazor.Shared.Wrapper;

namespace LEXEnprise.Blazor.Application.Models.CaseFolders
{
    public class GetFilteredCaseFoldersRequest
    {
        public PageMetaData MetaData { get; set; }
        public FilterCaseFoldersModel Filter { get; set; }
        public string SortString { get; set; }
    }
}
