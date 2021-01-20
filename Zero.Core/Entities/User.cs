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

        [Display(Name = "员工编号")]
        [MaxLength(16), Required(ErrorMessage = "员工编号为必填项")]
        public string No { get; set; }


        [Display(Name = "员工姓名")]
        [MaxLength(16), Required(ErrorMessage = "员工姓名为必填项")]
        public string Name { get; set; }

        [Display(Name = "出生日期")]
        [Required(ErrorMessage = "员工姓名为必填项"), Column(TypeName = "date")]
        public DateTime birthday { get; set; }

        [Display(Name = "联系方式")]
        [MaxLength(12), Required(ErrorMessage = "员工姓名为必填项")]
        public string Contact { get; set; }

        [Display(Name = "是否员工")]
        [DefaultValue(true)]
        public bool IsWorker { get; set; }

        [Display(Name = "车间")]
        [DefaultValue("00000000-0000-0000-0000-000000000000")]
        public Guid WorkShopId { get; set; }

        [Display(Name = "部门")]
        [DefaultValue("00000000-0000-0000-0000-000000000000")]
        public Guid DepartmentId { get; set; }

        [Display(Name = "组")]
        [DefaultValue("00000000-0000-0000-0000-000000000000")]
        public Guid GroupId { get; set; }

        [Display(Name = "职位")]
        [DefaultValue("00000000-0000-0000-0000-000000000000")]
        public Guid Position { get; set; }
    }
}
