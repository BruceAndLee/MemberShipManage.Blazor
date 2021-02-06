using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Shared.CustomerDTO
{
    public class CustomerUpdateRequest
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "用户名不能为空！")]
        public string UserNo { get; set; }

        [Required(ErrorMessage = "性别不能为空！")]
        public Nullable<int> Sex { get; set; }
        [Required(ErrorMessage = "姓名不能为空！")]
        public string Name { get; set; }
        public int ParentID { get; set; }
    }
}
