using System;
using System.Collections.Generic;
using System.Text;

namespace MemberShipManage.Infrastructurer.Pagination
{
    public interface ICustomPagedList<T> : IList<T>
    {
        int PageIndex { get; }
        int PageSize { get; }
        int TotalCount { get; }
        int TotalPages { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
    }
}
