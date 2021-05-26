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

        //public static string GetCountries = "lookup-service/countries";
        //public static string GetStates = "lookup-service/states";
        //public static string GetCities = "lookup-service/cities";
        //public static string GetClientTypes = "lookup-service/clienttypes";
        //public static string GetIndustries = "lookup-service/industries";
        //public static string GetCurrencies = "lookup-service/currencies";
        //public static string GetClientStatuses = "lookup-service/clientstatuses";
    }
}
