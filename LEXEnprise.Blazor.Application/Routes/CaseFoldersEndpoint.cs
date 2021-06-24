using LEXEnprise.Blazor.Application.Models.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Application.Routes
{
    public static class CaseFoldersEndpoint 
    {
        public static string GetPaged(int pageNumber, int pageSize,
            string searchString, string sortString)
        {
            //return $"casefolers?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&sortString={sortString}";
            
            //NOTE: These parameters required default values.
            searchString = searchString ?? "*";
            sortString = sortString ?? "CaseFolderCode";

            return $"v1/casefolders?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&sortString={sortString}";
        }

        public static string Get = "v1/casefolders/getcasefolder";
        public static string FilteredPaged = "v1/casefolders/getcasefolders";
        public static string Add = "v1/casefolders/add";
        public static string Delete = "v1/casefolders/delete";
        public static string Update = "v1/casefolders/update";

        //public static string GetPaged(int pageNumber, int pageSize,
        //    string searchString, string sortString)
        //{
        //    //return $"casefolders?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&sortString={sortString}";

        //    //NOTE: These parameters required default values.
        //    searchString = searchString ?? "*";
        //    sortString = sortString ?? "CaseFolderCode";

        //    return $"casefolders-service/casefolders/{pageNumber}/{pageSize}/{searchString}/{sortString}";
        //}

        //public static string Get = "casefolders-service/getcasefolder";
        //public static string FilteredPaged = "casefolders-service/filterclients";
        //public static string Add = "casefolders-service/add";
        //public static string Delete = "casefolders-service/delete";
        //public static string Update = "casefolders-service/update";

    }
}
