using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemberShipManage.Client.Pages.Pager
{
    public class PagerModel : ComponentBase
    {
        [Parameter]
        public PagerResultBase Result { get; set; }

        [Parameter]
        public Action<int> PagerChanged { get; set; }

        protected int StartIndex { get; private set; } = 0;
        protected int FinishIndex { get; private set; } = 0;

        protected override void OnParametersSet()
        {
            StartIndex = Math.Max(Result.CurrentPage - 5, 1);
            FinishIndex = Math.Min(Result.CurrentPage + 5, Result.PageCount);

            base.OnParametersSet();
        }

        protected void PagerButtonClicked(int page)
        {
            PagerChanged?.Invoke(page);
        }
    }
}
