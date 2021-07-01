using LEXEnprise.Blazor.Application.Models.Lookup;
using System;
using System.Collections.Generic;

namespace LEXEnprise.Blazor.Application.Models.Clients
{
    public class GetClientResponse : BaseModel
    {
        public string ClientNumber { get; set; }
        public string ClientName { get; set; }
        public string UnitDescription { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public int ClientIndustryId { get; set; }
        public string Website { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public int ClientCategoryId { get; set; }
        public int BillingCurrencyId { get; set; }
        public DateTime DateAcquired { get; set; }
        public int? ClientStatusId { get; set; }
        public int ClientTypeId { get; set; }
        public string Remarks { get; set; }
        public int? AccountManagerId { get; set; } //Lookup is Contacts.
        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
        public City City { get; set; }
        public State State { get; set; }
        public Country Country { get; set; }
        public ClientCategory Category { get; set; }
        public ClientStatus Status { get; set; }
        public Currency BillingCurrency { get; set; }
        public Industry Industry { get; set; }
        public ClientType ClientType { get; set; }
        public Contact AccountManager { get; set; }

    }
}
