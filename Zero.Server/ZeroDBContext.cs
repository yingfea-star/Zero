using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Zero.Core.Entities;

namespace Zero.Server
{
   public class ZeroDBContext:DbContext
    {
        public ZeroDBContext(DbContextOptions<ZeroDBContext> options) : base(options) { }


        public DbSet<Admin> Admin { get; set; }
        public DbSet<User> User { get; set; }

    }
}
