using LEXEnprise.Blazor.Application.Models.CaseFolders;
using LEXEnprise.Blazor.Infrastructure.Extensions;
using LEXEnprise.Blazor.Shared.Wrapper;
using LEXEnprise.Shared.Models.Paging;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Application.Services.CaseFolders
{
    public class CaseFoldersService : ServiceBase, ICaseFoldersService
    {
        public CaseFoldersService(HttpClient httpClient) : base(httpClient) { }

        public async Task<PaginatedResult<GetCaseFolderResponse>> GetCaseFolders(GetCaseFoldersRequest request)
        {
            try
            {
                var req = Routes.CaseFoldersEndpoint.GetPaged(request.PageNumber,
                            request.PageSize, request.SearchString, request.SortString);
                var response = await _httpClient.GetAsync(req);

                return await response.ToPaginatedResult<GetCaseFolderResponse>();
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public async Task<PaginatedResult<GetCaseFolderResponse>> GetFilteredCaseFolders(GetFilteredCaseFoldersRequest request)
        {
            try
            {
                request.MetaData.PageNumber = 1;
                request.SortString = request.SortString ?? "CaseFolderCode";
                var response = await _httpClient.PostAsJsonAsync(Routes.CaseFoldersEndpoint.FilteredPaged, request);
                
                if (response.IsSuccessStatusCode)
                    return await response.ToPaginatedResult<GetCaseFolderResponse>();

                return null;                   
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IResult<int>> AddCaseFolder(AddCaseFolderRequest request)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(Routes.CaseFoldersEndpoint.Add, request);

                if (response.IsSuccessStatusCode)
                    return await response.ToResult<int>();

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IResult<GetCaseFolderAndMattersResponse>> GetCaseFolder(int caseFolderId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{Routes.CaseFoldersEndpoint.Get}/{caseFolderId}");

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.ToResult<GetCaseFolderAndMattersResponse>();

                    return data;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
