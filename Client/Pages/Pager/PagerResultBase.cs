using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberShipManage.Client.Pages.Pager
{
    public abstract class PagerResultBase
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }
    }

    public class PagerResult<T> : PagerResultBase where T : class
    {
        public IList<T> Results { get; set; }

        public PagerResult()
        {
            Results = new List<T>();
        }
    }
}
