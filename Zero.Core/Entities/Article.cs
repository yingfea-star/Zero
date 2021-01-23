using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Core.Entities
{
   public class Article
    {
        public Article() { 
        }


        [Display(Name = "Guid")]
        public Guid Id { get; set; }

        [Display(Name = "文章标题")]
        [MaxLength(255), Required(ErrorMessage = "文章标题")]
        public string Title { get; set; }

        [Display(Name = "文章内容")]
        public string Content { get; set; }

        [Display(Name = "创建时间")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateTime { get; set; }

        [Display(Name = "修改时间")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdateTime { get; set; }
        public ArticleType articleType { get; set; }
    }
}
