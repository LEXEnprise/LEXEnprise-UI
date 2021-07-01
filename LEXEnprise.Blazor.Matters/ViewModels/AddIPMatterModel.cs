using LEXEnprise.Blazor.Application.Models;
using LEXEnprise.Blazor.Application.Models.Matters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Matters.ViewModels
{
    public class AddIPMatterModel : BaseModel
    {
        #region Matter Info
        public int ClientId { get; set; }
        public int CaseFolderId { get; set; }
        public string CaseFolderCode { get; set; }
        //[Required(ErrorMessage = "Case Type is required.")]
        public int CaseTypeId { get; set; }
        //[Required(ErrorMessage = "Nature Of Case is required.")]
        [MaxLength(100, ErrorMessage = "Nature Of Case is too long. (100 characters limit)")]
        public string NatureOfCase { get; set; }
        //[Required(ErrorMessage = "Subject Matter is required.")]
        [MaxLength(100, ErrorMessage = "Subject Matter is too long. (100 characters limit)")]
        public string SubjectMatter { get; set; }
        //[Required(ErrorMessage = "Paralegal is required.")]
        public int ParalegalId { get; set; }
        //[Required(ErrorMessage = "DocketNumber is required.")]
        public string DocketNumber { get; set; }
        //[Required(ErrorMessage = "Matter Stage is required.")]
        public int MatterStageId { get; set; }
        public DateTime? StageAsOfDate { get; set; }
        //[Required(ErrorMessage = "Status is required.")]
        public int StatusId { get; set; }
        public string FileNumber { get; set; }
        public DateTime? FileDate { get; set; }
        public string ClientReference { get; set; }

        public List<MatterHandlingLawyer> HandlingLawyers = new List<MatterHandlingLawyer>();

        #endregion Matter info

        #region Other IP Info
        public int ApplicantId { get; set; }
        //[Required(ErrorMessage = "Applicant is required.")]
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
        #endregion Other IP Info

    }
}
