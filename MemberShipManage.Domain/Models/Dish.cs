using System;
using System.Collections.Generic;

#nullable disable

namespace MemberShipManage.Server.Models
{
    public partial class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? InDate { get; set; }
        public string InUser { get; set; }
        public int? CategoryId { get; set; }
    }
}
