using LEXEnprise.Blazor.Shared.Wrapper;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Shared.Components.Paging
{
    public partial class Pagination
    {
        [Parameter]
        public PageMetaData MetaData { get; set; } //
        [Parameter]
        public int Spread { get; set; } //number of page buttons (links) to show before and after the current selected page.
        [Parameter]
        public EventCallback<int> SelectedPage { get; set; } //to run the methods from the parent component inside the child component.

        public List<PagingLink> _links;

        protected override void OnParametersSet()
        {
            CreatePaginationLinks();
        }

        private void CreatePaginationLinks()
        {
            _links = new List<PagingLink>();

            _links.Add(new PagingLink(MetaData.PageNumber - 1, MetaData.HasPrevious, "Previous"));

            for (int i = 1; i <= MetaData.TotalPages; i++)
            {
                if (i >= MetaData.PageNumber - Spread && i <= MetaData.PageNumber + Spread)
                {
                    _links.Add(new PagingLink(i, true, i.ToString()) { Active = MetaData.PageNumber == i });
                }
            }

            _links.Add(new PagingLink(MetaData.PageNumber + 1, MetaData.HasNext, "Next"));
        }

        private async Task OnSelectedPage(PagingLink link)
        {
            if (link.Page == MetaData.PageNumber || !link.Enabled)
                return;

            MetaData.PageNumber = link.Page;
            await SelectedPage.InvokeAsync(link.Page);
        }
    }
}
