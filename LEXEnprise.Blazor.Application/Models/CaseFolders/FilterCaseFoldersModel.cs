using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Application.Models.CaseFolders
{
    public class FilterCaseFoldersModel
    {
        public string ClientName { get; set; }
        public string CaseFolderCode { get; set; }
        public int CaseGroupId { get; set; }
        public int FolderTypeId { get; set; }
    }
}
