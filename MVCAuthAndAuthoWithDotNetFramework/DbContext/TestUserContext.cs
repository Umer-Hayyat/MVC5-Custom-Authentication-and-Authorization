using MVCAuthAndAuthoWithDotNetFramework.DbContext.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCAuthAndAuthoWithDotNetFramework.DbContext
{
    public class TestUserContext : System.Data.Entity.DbContext
    {
        public DbSet<UserDBModel> Users { get; set; }

        public TestUserContext() : base(nameOrConnectionString: "Default") { }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<MVCAuthAndAuthoWithDotNetFramework.Models.UsersModel> UsersModels { get; set; }
    }
}