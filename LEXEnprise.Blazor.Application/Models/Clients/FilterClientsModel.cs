using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Application.Models.Clients
{
    public class FilterClientsModel
    {
        public string ClientNumber { get; set; }
        public string ClientName { get; set; }
        public string UnitDescription { get; set; }
        public int ClientIndustryId { get; set; }
        public int ClientStatusId { get; set; }
        public int ClientTypeId { get; set; }
    }
}
