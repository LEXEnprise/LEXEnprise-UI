using LEXEnprise.Blazor.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Application.Models.Account
{
    public class RefreshTokenResponse 
    {
        public string NewToken { get; set; }
        public string NewRefreshToken { get; set; }
    }
}
