using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Application.Models.Matters
{
    public class AddNonIPMatterRequest : AddMatterBaseRequest
    {
        public NonIPMatterOtherInfo OtherInfo { get; set; } = new NonIPMatterOtherInfo();
    }
}
