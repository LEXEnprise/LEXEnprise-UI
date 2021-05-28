using LEXEnprise.Blazor.Application.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace LEXEnprise.Blazor.Application.Models.Clients
{
    public class AddClientRequest
    {
        [Required]
        [MaxLength(128)]
        [StringLength(128, ErrorMessage = "ClientName is too long. (128 Characters Limit)")]
        public string ClientName { get; set; }

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

        [Required(ErrorMessage = "Date Acquired is required")]
        public DateTime DateAcquired { get; set; }
        public int ClientTypeId { get; set; } = 0;

        [MaxLength(1000)]
        [StringLength(1000, ErrorMessage = "Remarks too long. (1000 Characters Limit.)")]
        public string Remarks { get; set; }

        [MaxLength(128)]
        [Required(ErrorMessage = "Main Account Officer is required")]
        [StringLength(128, ErrorMessage = "Main Account Officer too long. (128 Characters Limit.)")]
        public string MainAccountOfficer { get; set; }

        [MaxLength(128)]
        [Required(ErrorMessage = "Main Account Officer's Email is required")]
        [StringLength(128, ErrorMessage = "Main Account Officer's Email too long. (128 Characters Limit.)")]
        public string MainAccountOfficerEmail { get; set; }

        [MaxLength(32)]
        [Required(ErrorMessage = "Main Account Officer's PhoneNumber is required")]
        [StringLength(32, ErrorMessage = "Main Account Officer's PhoneNumber too long. (32 Characters Limit.)")]
        public string MainAccountOfficerPhoneNumber { get; set; }
        [MaxLength(32)]
        [Required(ErrorMessage = "Main Account Officer's Mobile Number is required")]
        [StringLength(32, ErrorMessage = "Main Account Officer's Mobile Number too long. (128 Characters Limit.)")]
        public string MainAccountOfficerMobileNumber { get; set; }

        [MaxLength(64)]
        [Required(ErrorMessage = "Main Account Officer's Position is required")]
        [StringLength(64, ErrorMessage = "Main Account Officer's Position too long. (64 Characters Limit.)")]
        public string MainAccountOfficerPosition { get; set; }
    }
}
