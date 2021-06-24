using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Application.Models.CaseFolders
{
    public class AddCaseFolderRequest : BaseModel
    {
        public int ClientId { get; set; }
        [Required]
        public string ClientNumber { get; set; }
        [Required]
        [MaxLength(128)]
        [StringLength(128, ErrorMessage = "ClientName is too long. (128 Characters Limit)")]
        public string ClientName { get; set; }
        [Required]
        [MaxLength(60)]
        [StringLength(60, ErrorMessage = "Case Folder Description is too long. (60 Characters Limit)")]
        public string CaseFolderDesc { get; set; }

        [Required(ErrorMessage = "Case Group is required")]
        public int CaseGroupId { get; set; }
        [Required(ErrorMessage = "Supervising Lawyer is required")]
        public int SupervisingLawyerId { get; set; }
        public string SupervisingLawyer { get; set; }
        [Required(ErrorMessage = "Case Owner is required")]
        public int CaseOwnerId { get; set; }
        public string CaseOwner { get; set; }
        [Required(ErrorMessage = "Folder Type is required")]
        public int FolderTypeId { get; set; }
        public string FolderLocation { get; set; } = "";
        [StringLength(1000, ErrorMessage = "Case Folder Description is too long. (1000 Characters Limit)")]
        public string Remarks { get; set; }
    }
}
