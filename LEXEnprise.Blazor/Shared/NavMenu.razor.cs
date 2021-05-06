using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace LEXEnprise.Blazor.Shared
{
    public partial class NavMenu
    {
        [Parameter]
        public string UserName { get; set; } 

        [Parameter]
        public string UserImage { get; set; }

        protected override void OnInitialized()
        {
            UserName = "Alex Deyto";
            UserImage = "img/user2-160x160.jpg";
        }
    }
}
