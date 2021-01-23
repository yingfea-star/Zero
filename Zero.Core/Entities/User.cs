using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Core.Entities
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class User
    {
        [Display(Name = "Guid")]
        public Guid Id { get; set; }

        [Display(Name = "用户编号")]
        [MaxLength(16), Required(ErrorMessage = "用户编号为必填项")]
        public string No { get; set; }

        [Display(Name = "账户")]
        [MaxLength(16), Required(ErrorMessage = "账户为必填项")]
        public string Account { get; set; }

        [Display(Name = "密码")]
        [MaxLength(16), Required(ErrorMessage = "账户为必填项")]
        public string Password { get; set; }

        [Display(Name = "用户昵称")]
        [MaxLength(16), Required(ErrorMessage = "用户昵称为必填项")]
        public string NickName { get; set; }

        [Display(Name = "头像")]
        [MaxLength(255)]
        public string ProfliePhoto { get; set; }

        [Display(Name = "出生日期")]
        [Column(TypeName = "date")]
        public DateTime birthday { get; set; }

        [Display(Name = "QQ")]
        [MaxLength(11)]
        public int QQ { get; set; }

        [Display(Name = "微信")]
        [MaxLength(255)]
        public string WeChat { get; set; }

        [Display(Name = "Github")]
        [MaxLength(255)]
        public string Github { get; set; }

        [Display(Name = "创建时间")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateTime { get; set; }

        [Display(Name = "修改时间")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdateTime { get; set; }
    }
}
