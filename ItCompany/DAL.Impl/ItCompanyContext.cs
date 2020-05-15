using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Impl
{
    public class ItCompanyContext : DbContext
    {
        public ItCompanyContext (DbContextOptions<ItCompanyContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<EmployeeDepartment> EmployeeDepartment { get; set; }
        public DbSet<ItCompany> ItCompany { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Entities.Task> Task { get; set; }
    }
}
