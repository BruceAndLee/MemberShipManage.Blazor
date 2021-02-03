using System;
using System.Collections.Generic;
using System.Text;

namespace MemberShipManage.Shared.CustomerDTO
{
    public class CustomerGetResponse
    {
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }

        public List<CustomerDetailEntity> CustomerDetailList { get; set; }
    }
}
