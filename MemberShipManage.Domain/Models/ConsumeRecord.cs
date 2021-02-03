using System;
using System.Collections.Generic;

#nullable disable

namespace MemberShipManage.Server.Models
{
    public partial class ConsumeRecord
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public string Detail { get; set; }
        public DateTime? InDate { get; set; }
        public string InUser { get; set; }
        public bool? Status { get; set; }
    }
}
