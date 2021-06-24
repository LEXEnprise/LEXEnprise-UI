using System;
using System.ComponentModel.DataAnnotations;

namespace LEXEnprise.Blazor.Application.Models.Matters
{
    public class IPMatterOtherInfo
    {
        public int MatterId { get; set; }
        public int ApplicantId { get; set; }
       
        public string ApplicantName { get; set; }
        public int ApplicationTypeId { get; set; }
        public string ApplicationNumber { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string CertificateNumber { get; set; }
        public DateTime? CertificateDate { get; set; }
        public string PCTApplicationNumber { get; set; }
        public DateTime? PCTApplicationDate { get; set; }
        public string PCTLanguageNumber { get; set; }
        public DateTime? PCTLanguageDate { get; set; }
        public string PCTPublicationNumber { get; set; }
        public DateTime? PCTPublicationDate { get; set; }
        public string PriorityNumber { get; set; }
        public DateTime? PriorityDate { get; set; }
        public int PriorityCountryFilingId { get; set; }

        public DateTime? DateWithdrawn { get; set; }
        public string ReasonOfWithdrawn { get; set; }
        public DateTime? RenewalDate { get; set; }
        public DateTime? RenewalDau { get; set; }
    }
}
