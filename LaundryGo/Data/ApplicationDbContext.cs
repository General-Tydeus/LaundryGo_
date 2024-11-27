using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using LaundryGo.Models;

namespace LaundryGo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<LaundryGo.Models.Shop> Shop { get; set; }
        public DbSet<LaundryGo.Models.Users> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasNoKey(); // Mark the entity as keyless
                entity.ToView("UserRoles"); // Map it to the database view
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
