using Blazored.Modal;
using LEXEnprise.Blazor.Application.Models.Matters;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Matters.Components
{
    public partial class HandlingLawyersModal
    {
        [Parameter]
        public string Title { get; set; } = "Handling Lawyers";

        [Parameter]
        public List<MatterHandlingLawyer> HandlingLawyers { get; set; } = new List<MatterHandlingLawyer>();

        [CascadingParameter]
        public BlazoredModalInstance BlazoredModal { get; set; }

        private async Task Close() => await BlazoredModal.CancelAsync();
    }
}
