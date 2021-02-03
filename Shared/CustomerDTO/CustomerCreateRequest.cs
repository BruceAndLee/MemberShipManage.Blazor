using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace MemberShipManage.Shared.CustomerDTO
{
    public class CustomerCreateRequest
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "用户名不能为空！")]
        public string UserNo { get; set; }

        [Required(ErrorMessage = "性别不能为空！")]
        public Nullable<int> Sex { get; set; }
        public Nullable<System.DateTime> InDate { get; set; }
        public string InUser { get; set; }
        [Required(ErrorMessage = "姓名不能为空！")]
        public string Name { get; set; }
        public int ParentID { get; set; }
        [Required(ErrorMessage = "密码不能为空！")]
        [StringLength(10, ErrorMessage = "密码长度必须介于6到10位！", MinimumLength = 6)]
        [RegularExpression("^[0-9a-zA-Z_]{1,}$", ErrorMessage = "密码必须由字母数组和下划线组成！")]
        public string Password { get; set; }
        [Required(ErrorMessage = "确认密码不能为空！")]
        [Compare("Password", ErrorMessage = "确认密码和密码不一致！")]
        public string RePassword { get; set; }
        public bool Status { get; set; }
    }
}
