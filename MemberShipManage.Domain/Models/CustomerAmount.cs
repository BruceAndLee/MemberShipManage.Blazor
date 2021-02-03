using System;
using System.Collections.Generic;

#nullable disable

namespace MemberShipManage.Server.Models
{
    public partial class CustomerAmount
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public DateTime? InDate { get; set; }
        public DateTime? LastEditDate { get; set; }
        public string InUser { get; set; }
        public string LastEditUser { get; set; }
    }
}
