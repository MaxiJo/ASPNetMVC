using ASPNetMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPNetMVC.Contacts
{
    public class MyContext : DbContext
    {
        
        public MyContext():base("ASPNetMVC"){}
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Account> Accounts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Employee>()
                .HasRequired<Division>(d => d.Divisions)
                .WithMany(e => e.Employees)
                .HasForeignKey<int>(e => e.divisionId);
        }

    }
}