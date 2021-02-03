using System;
using System.Collections.Generic;

#nullable disable

namespace MemberShipManage.Server.Models
{
    public partial class SystemConfig
    {
        public int Id { get; set; }
        public string ConfigKey { get; set; }
        public string ConfigValue { get; set; }
        public DateTime? InDate { get; set; }
        public string InUser { get; set; }
        public string Display { get; set; }
    }
}
