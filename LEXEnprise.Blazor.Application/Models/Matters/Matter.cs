using LEXEnprise.Blazor.Application.Models.CaseFolders;
using LEXEnprise.Blazor.Application.Models.Lookup.Matters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LEXEnprise.Blazor.Application.Models.Matters
{
    public class Matter : BaseModel
    {
        public int CaseFolderId { get; set; }
        public int ClientId { get; set; }
        public string MatterCode { get; set; }
        public int CaseTypeId { get; set; }
        public string NatureOfCase { get; set; }
        [Required(ErrorMessage = "Subject Matter is required")]
        [StringLength(100, ErrorMessage = "Subject Matter is too long. (100 Characters Limit)")]
        public string SubjectMatter { get; set; }
        public int ParalegalId { get; set; }
        public string DocketNumber { get; set; }
        public int MatterStageId { get; set; }
        public DateTime? StageAsOfDate { get; set; }
        public int StatusId { get; set; }
        public string FileNumber { get; set; }
        public DateTime? FileDate { get; set; }
        public string ClientReference { get; set; }

        public CaseType CaseType { get; set; }
        public List<MatterHandlingLawyer> HandlingLawyers { get; set; } = new List<MatterHandlingLawyer>();
        //public List<MatterContact> Contacts { get; set; }
        public CaseFolder CaseFolder { get; set; }

        public Paralegal Paralegal { get; set; }
        //public MatterStage Stage { get; set; }
        public MatterStatus Status { get; set; }

        //public IPMatterOtherInfo IPMatterOtherInfo { get; set; }
        //public NonIPMatterOtherInfo NonIPMatterOtherInfo { get; set; }

        //public List<Activity> Activities { get; set; }
        //public List<DueDate> DueDates { get; set; }
    }
}
