using LEXEnprise.Blazor.Application.Models.Clients;
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
            //return $"clients?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&sortString={sortString}";
            
            //NOTE: These parameters required default values.
            searchString = searchString ?? "*";
            sortString = sortString ?? "ClientName";

            return $"v1/clients/getpaged?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&sortString={sortString}";
        }

        public static string FilteredPaged = "v1/clients/getclients";
        public static string Add = "v1/clients/addclient";
        public static string Get = "v1/clients/getclient";
        public static string Delete = "v1/clients/delete";
        public static string Update = "v1/clients/update";

        //public static string GetPaged(int pageNumber, int pageSize,
        //    string searchString, string sortString)
        //{
        //    //return $"clients?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&sortString={sortString}";

        //    //NOTE: These parameters required default values.
        //    searchString = searchString ?? "*";
        //    sortString = sortString ?? "ClientName";

        //    return $"clients-service/clients/{pageNumber}/{pageSize}/{searchString}/{sortString}";
        //}

        //public static string FilteredPaged = "clients-service/filterclients";
        //public static string Add = "clients-service/add";
        //public static string Get = "clients-service/getclient";
        //public static string Delete = "clients-service/delete";
        //public static string Update = "clients-service/update";

    }
}
