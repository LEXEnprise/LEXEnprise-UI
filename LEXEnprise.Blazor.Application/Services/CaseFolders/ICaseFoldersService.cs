using LEXEnprise.Blazor.Application.Models.CaseFolders;
using LEXEnprise.Blazor.Application.Models.Clients;
using LEXEnprise.Blazor.Shared.Wrapper;
using LEXEnprise.Shared.Models.Paging;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Application.Services.CaseFolders
{
    public interface ICaseFoldersService : IService
    {
        Task<PaginatedResult<GetCaseFolderResponse>> GetCaseFolders(GetCaseFoldersRequest request);
        Task<PaginatedResult<GetCaseFolderResponse>> GetFilteredCaseFolders(GetFilteredCaseFoldersRequest request);
        Task<IResult<int>> AddCaseFolder(AddCaseFolderRequest request);
        Task<IResult<GetCaseFolderAndMattersResponse>> GetCaseFolder(int caseFolderId);
    }
}
