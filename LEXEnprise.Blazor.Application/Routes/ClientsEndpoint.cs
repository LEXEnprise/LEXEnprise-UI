using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Application.Routes
{
    public static class ClientsEndpoint 
    {
        public static string GetPaged(int pageNumber, int pageSize,
            string searchString, string sortString)
        {
            return $"clients?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&sortString={sortString}";
        }

        public static string Add = "clients/add";
        public static string Delete = "clients/delete";
        public static string Update = "clients/update";

    }
}
