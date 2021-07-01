using LEXEnprise.Blazor.Application.Constants;
using LEXEnprise.Blazor.Application.Models.Lookup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LEXEnprise.Blazor.Application.Models.Clients
{
    public class UpdateClientRequest
    {
        public int Id { get; set; }

        public string ClientNumber { get; set; }

        [Required]
        [MaxLength(128)]
        [StringLength(128, ErrorMessage = "ClientName is too long. (128 Characters Limit)")]
        public string ClientName { get; set; }

        public string UnitDescription { get; set; }

        [MaxLength(128)]
        [StringLength(128, ErrorMessage = "Address1 is too long. (128 Characters Limit)")]
        public string Address1 { get; set; }
        [MaxLength(128)]
        [StringLength(128, ErrorMessage = "Address2 is too long. (128 Characters Limit)")]
        public string Address2 { get; set; }

        public int CityId { get; set; } = 0;

        public int StateId { get; set; } = 0;

        public int CountryId { get; set; } = 0;

        [MaxLength(10)]
        [StringLength(10, ErrorMessage = "ZipCode too long. (10 Characters Limit.)")]
        public string ZipCode { get; set; }

        public int ClientIndustryId { get; set; } = 0;
        public int ClientCategoryId { get; set; } = 0;

        [MaxLength(128)]
        public string Website { get; set; }

        [MaxLength(20)]
        [StringLength(20, ErrorMessage = "PhoneNumber too long. (10 Characters Limit.)")]
        public string PhoneNumber { get; set; }

        [MaxLength(20)]
        [StringLength(20, ErrorMessage = "MobileNumber too long. (10 Characters Limit.)")]
        public string MobileNumber { get; set; }

        [Required]
        [MaxLength(128)]
        [StringLength(128, ErrorMessage = "Email too long. (128 Characters Limit.)")]
        [EmailAddress]
        public string Email { get; set; }

        public int BillingCurrencyId { get; set; } = LookupConstants.DEF_BILLINGCURRENCY;
        public int? ClientStatusId { get; set; }
        public ClientStatus Status { get; set; }
        public int? AccountManagerId { get; set; }

        [Required(ErrorMessage = "Date Acquired is required")]
        public DateTime DateAcquired { get; set; }
        public int ClientTypeId { get; set; } = 0;

        [MaxLength(1000)]
        [StringLength(1000, ErrorMessage = "Remarks too long. (1000 Characters Limit.)")]
        public string Remarks { get; set; }

        public List<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
