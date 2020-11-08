using DBMS;
using System;
using Microsoft.EntityFrameworkCore;

namespace WebInterface
{
    public class DbmsContext : DbContext
    {
        //public DbSet<DatabaseViewModel> DbViewModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("SERVER = localhost; DATABASE = master.sys.databases; User ID =admin; Pwd = 04112000");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Database> Databases { get; set; }  
    }
}
