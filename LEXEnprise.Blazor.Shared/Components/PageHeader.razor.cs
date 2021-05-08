using Microsoft.AspNetCore.Components;

namespace LEXEnprise.Blazor.Shared.Components
{
    public partial class PageHeader
    {
        [Parameter]
        public string PageTitle { get; set; }

        [Parameter]
        public string BreadCrumbTitle { get; set; }
    }
}
