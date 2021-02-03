using System;
using System.Collections.Generic;

#nullable disable

namespace MemberShipManage.Server.Models
{
    public partial class RechargeRecord
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public DateTime? InDate { get; set; }
        public string InUser { get; set; }
        public bool? Status { get; set; }
    }
}
