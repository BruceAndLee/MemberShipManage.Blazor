using System;
using System.Collections.Generic;

#nullable disable

namespace MemberShipManage.Server.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string UserNo { get; set; }
        public int? Sex { get; set; }
        public DateTime? InDate { get; set; }
        public string InUser { get; set; }
        public string Name { get; set; }
        public int ParentID { get; set; }
        public string Password { get; set; }
        public bool? Status { get; set; }
    }
}
