using LEXEnprise.Blazor.Application.Models.Matters;
using LEXEnprise.Blazor.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Application.Services.Matters
{
    public interface IMattersService : IService
    {
        Task<IResult<int>> AddIPMatter(AddIPMatterRequest request);
    }
}
