using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Core.Entities
{
    /// <summary>
    /// 管理员表
    /// </summary>
   public class Admin
    {
        [Display(Name = "编号")]
        public Guid Id { get; set; }

        [Display(Name = "账户")]
        [MaxLength(16),Required(ErrorMessage ="账户不能为空")]
        public string Account { get; set; }

        [Display(Name = "密码")]
        [MaxLength(16), Required(ErrorMessage = "账户不能为空")]
        [DefaultValue("123456")]
        public string Password { get; set; }

        [Display(Name = "用户工号")]
        [MaxLength(16)]
        public string workNumber { get; set; }

    }
}
