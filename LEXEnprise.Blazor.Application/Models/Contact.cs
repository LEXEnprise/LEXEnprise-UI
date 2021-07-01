using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Application.Models
{
    public class Contact : BaseModel
    {
        public int ClientId { get; set; }
        [Required(ErrorMessage = "Contact Person's Name is required.")]
        [MaxLength(128, ErrorMessage = "Contact Person's Name too long. (128 Characters Limit.)")]
        public string ContactPerson { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [MaxLength(128, ErrorMessage = "Email too long. (128 Characters Limit.)")]
        public string Email { get; set; }
        [Required(ErrorMessage = "PhoneNumber is required.")]
        [MaxLength(32, ErrorMessage = "PhoneNumber too long. (32 Characters Limit.)")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Mobile Number is required.")]
        [MaxLength(32, ErrorMessage = "PhoneNumber too long. (32 Characters Limit.)")]
        public string Mobile { get; set; }
        [MaxLength(64, ErrorMessage = "Position too long. (64 Characters Limit.)")]
        public string Position { get; set; }
        [MaxLength(128, ErrorMessage = "Position too long. (128 Characters Limit.)")]
        public string Remarks { get; set; }

        public bool? IsMainAccountOfficer { get; set; } = false;
        public short Action { get; set; } = 0;
    }
}
