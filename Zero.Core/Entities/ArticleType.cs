using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Core.Entities
{
    public class ArticleType
    {
        [Display(Name = "Guid")]
        public Guid Id { get; set; }

        [Display(Name = "类别")]
        [MaxLength(255), Required(ErrorMessage = "类别为必填项")]
        public string Name { get; set; }

        [Display(Name = "父级类别")]
        [DefaultValue("00000000-0000-0000-0000-000000000001")]
        public Guid ParentId { get; set; }


    }
}
