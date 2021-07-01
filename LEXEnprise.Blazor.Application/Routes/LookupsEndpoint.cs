using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Application.Routes
{
    public static class LookupsEndpoint
    {
        public static string GetCountries = "v1/lookup/countries";
        public static string GetStates = "v1/lookup/states";
        public static string GetCities = "v1/lookup/cities";
        public static string GetClientTypes = "v1/lookup/clienttypes";
        public static string GetIndustries = "v1/lookup/industries";
        public static string GetCurrencies = "v1/lookup/currencies";
        public static string GetClientStatuses = "v1/lookup/clientstatuses";
        public static string GetCaseGroups = "v1/lookup/casegroups";
        public static string GetLawyers = "v1/lookup/lawyers";
        public static string GetFolderStatuses = "v1/lookup/folderstatuses";
        public static string GetFolderTypes = "v1/lookup/foldertypes";
        public static string GetMatterStages = "v1/lookup/matterstages";
        public static string GetMatterStatuses = "v1/lookup/matterstatuses";
        public static string GetCaseTypes = "v1/lookup/casetypes";
        public static string GetParalegals = "v1/lookup/paralegals";
        public static string GetApplicationTypes = "v1/lookup/applicationtypes";
        public static string GetLawyersByGroup = "v1/lookup/lawyersbygroup";
        public static string GetClientCategories = "v1/lookup/clientcategories";
        public static string GetPagedLawyers(int pageNumber, int pageSize,
            string searchString, string sortString)
        {
            searchString = searchString ?? "*";
            sortString = sortString ?? "Fullname";

            return $"v1/lookup/pagedlawyers?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&sortString={sortString}";
        }
        public static string GetPagedApplicants(int pageNumber, int pageSize,
            string searchString, string sortString)
        {
            searchString = searchString ?? "*";
            sortString = sortString ?? "ApplicantName";

            return $"v1/lookup/pagedapplicants?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&sortString={sortString}";
        }

        //public static string GetCountries = "lookup-service/countries";
        //public static string GetStates = "lookup-service/states";
        //public static string GetCities = "lookup-service/cities";
        //public static string GetClientTypes = "lookup-service/clienttypes";
        //public static string GetIndustries = "lookup-service/industries";
        //public static string GetCurrencies = "lookup-service/currencies";
        //public static string GetClientStatuses = "lookup-service/clientstatuses";
        //public static string GetCaseGroups = "lookup-service/casegroups";
        //public static string GetLawyers = "lookup-service/lawyers";
        //public static string GetFolderStatuses = "lookup-service/folderstatuses";
        //public static string GetFolderTypes = "lookup-service/foldertypes";
        //public static string GetMatterStages = "lookup-service/matterstages";
        //public static string GetMatterStatuses = "lookup-service/matterstatuses";
        //public static string GetCaseTypes = "lookup-service/casetypes";
        //public static string GetParalegals = "lookup-service/paralegals";
        //public static string GetApplicationTypes = "lookup-service/applicationtypes";
        //public static string GetLawyersByGroup = "lookup-service/lawyersbygroup";
        //public static string GetClientCategories = "lookup-service/clientcategories";

        //public static string GetPagedLawyers(int pageNumber, int pageSize,
        //    string searchString, string sortString)
        //{
        //    searchString = searchString ?? "*";
        //    sortString = sortString ?? "Fullname";

        //    return $"lookup-service/lawyers/{pageNumber}/{pageSize}/{searchString}/{sortString}";
        //}
        //public static string GetPagedLawyers(int pageNumber, int pageSize,
        //    string searchString, string sortString)
        //{
        //    searchString = searchString ?? "*";
        //    sortString = sortString ?? "Fullname";

        //    return $"lookup-service/pagedapplicants?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&sortString={sortString}";
        //}
    }
}
