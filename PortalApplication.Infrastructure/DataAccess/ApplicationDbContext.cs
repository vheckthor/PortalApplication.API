using System;
using Microsoft.EntityFrameworkCore;
using PortalApplication.Core.Models;

namespace PortalApplication.Infrastructure.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<ContactFormModel> ContactForms { get; set; }
        public DbSet<VacancyModel> Vacancy { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               // optionsBuilder.UseSqlite("Data Source=portal.db");
            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
