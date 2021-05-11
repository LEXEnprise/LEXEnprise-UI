using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LEXEnprise.Blazor.Application.Models;
using LEXEnprise.Blazor.Application.Models.Account;
using LEXEnprise.Blazor.Shared.Wrapper;

namespace LEXEnprise.Blazor.Application.Services.Account
{
    public interface IAccountService : IService
    {
        UserIdentity User { get; }
        Task Initialize();
        Task<IResult> Login(LoginRequest loginRequest);
    }
}
