using System.ComponentModel.DataAnnotations;

namespace MemberShipManage.Shared.UserDTO
{
    public class UserEntity
    {
        [Required(ErrorMessage = "用户名不能为空")]
        [MaxLength(20, ErrorMessage = "用户名长度不能超过20")]
        public string UserNo { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        [MaxLength(15, ErrorMessage = "用户名长度不能超过15")]
        public string Password { get; set; }
    }
}
