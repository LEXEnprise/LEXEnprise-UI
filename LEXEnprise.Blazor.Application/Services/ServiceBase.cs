using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Application.Services
{
    public class ServiceBase
    {
        protected readonly HttpClient _httpClient;

        public ServiceBase(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
