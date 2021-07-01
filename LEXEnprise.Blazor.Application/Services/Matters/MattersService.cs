using LEXEnprise.Blazor.Application.Models.Matters;
using LEXEnprise.Blazor.Infrastructure.Extensions;
using LEXEnprise.Blazor.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Application.Services.Matters
{
    public class MattersService : ServiceBase, IMattersService
    {
        public MattersService(HttpClient httpClient) : base(httpClient) { }

        public async Task<IResult<int>> AddIPMatter(AddIPMatterRequest request)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(Routes.MattersEndpoint.AddIPMatter, request);

                if (response.IsSuccessStatusCode)
                    return await response.ToResult<int>();

                return null;
            }
            catch (Exception ex)
            {
                 return null;
            }
        }
    }
}
