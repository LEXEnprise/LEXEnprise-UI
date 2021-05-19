using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Application.Routes
{
    public static class AccountsEndpoint
    {
        public static string Login = "http://localhost:50247/api/authmanagement/login";
        public static string RefreshToken = "http://localhost:50247/api/token/refresh";

        //public static string Login = "auth-service/login";
        //public static string RefreshToken = "auth-service/refreshtoken";
    }
}
