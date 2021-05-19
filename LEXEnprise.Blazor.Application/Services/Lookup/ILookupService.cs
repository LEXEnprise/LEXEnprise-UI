using LEXEnprise.Blazor.Application.Models.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Application.Services.Lookup
{
    public interface ILookupService : IService
    {
        Task<List<Country>> GetCountries();
        Task<List<ClientType>> GetClientTypes();
        Task<List<Industry>> GetIndustries();
        Task<List<Currency>> GetCurrencies();
        Task<List<ClientStatus>> GetClientStatuses();
    }
}
