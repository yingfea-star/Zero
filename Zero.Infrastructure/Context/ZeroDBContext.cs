using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Zero.Core.Entities;

namespace Zero.Infrastructure.Context
{
   public class ZeroDBContext:DbContext
    {
        public ZeroDBContext(DbContextOptions<ZeroDBContext> options)
       : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<ArticleType> ArticleType { get; set; }
    }
}
