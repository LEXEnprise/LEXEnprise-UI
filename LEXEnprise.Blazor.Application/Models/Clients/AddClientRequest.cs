using LEXEnprise.Blazor.Application.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace LEXEnprise.Blazor.Application.Models.Clients
{
    public class AddClientRequest
    {
        [Required]
        [MaxLength(128)]
        public string ClientName { get; set; }

        [MaxLength(128)]
        public string Address1 { get; set; }
        [MaxLength(128)]
        public string Address2 { get; set; }


        public int CityId { get; set; } = 0;

        public int StateId { get; set; } = 0;

        public int CountryId { get; set; } = 0;

        [MaxLength(10)]
        public string ZipCode { get; set; }

        public int ClientIndustryId { get; set; } = 0;

        [MaxLength(128)]
        public string Website { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [MaxLength(20)]
        public string MobileNumber { get; set; }

        [Required]
        [MaxLength(128)]
        [EmailAddress]
        public string Email { get; set; }

        public int BillingCurrencyId { get; set; } = LookupConstants.DEF_BILLINGCURRENCY;

        public string DateAcquired { get; set; }
        public int ClientTypeId { get; set; } = 0;

        [MaxLength(1000)]
        public string Remarks { get; set; }

    }
}
