using IandZ.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IandZ.Dal
{
    public class AdminDal : DbContext
    {
        public DbSet<Admin> admin { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Admin>().ToTable("Admins_tbl");
        }
    }
}