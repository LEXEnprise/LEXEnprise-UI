using Microsoft.AspNetCore.Components;

namespace LEXEnprise.Blazor.Shared.Components
{
    public partial class UserInfo
    {
        [Parameter]
        public string UserName { get; set; }

        [Parameter]
        public string UserImage { get; set; }
    }
}
