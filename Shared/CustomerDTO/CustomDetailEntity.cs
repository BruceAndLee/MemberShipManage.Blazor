using System;
using System.Collections.Generic;
using System.Text;
using MemberShipManage.Server.Models;

namespace MemberShipManage.Shared.CustomerDTO
{
    public class CustomerDetailEntity : Customer
    {
        public decimal? Amount { get; set; }
        public decimal? RebateAmount { get; set; }
        public string ParentCustomerName { get; set; }
    }
}
