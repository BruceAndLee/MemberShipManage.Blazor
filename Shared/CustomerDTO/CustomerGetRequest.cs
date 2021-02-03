using System;
using System.Collections.Generic;
using System.Text;

namespace MemberShipManage.Shared.CustomerDTO
{
    public class CustomerGetRequest : PagerEntity
    {
        public string UserNo { get; set; }
        public string Name { get; set; }
        public int? Sex { get; set; }
    }
}
