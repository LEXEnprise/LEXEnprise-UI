using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Shared.Components.Paging
{
    public class PagingLink //Holds the page button link properties that will be used for the pagination component.
    {
        public string Text { get; set; } //(Previous, Next, 1,2,3…)
        public int Page { get; set; } //Current Page
        public bool Enabled { get; set; }
        public bool Active { get; set; }
        public PagingLink(int page, bool enabled, string text)
        {
            Page = page;
            Enabled = enabled;
            Text = text;
        }
    }
}
