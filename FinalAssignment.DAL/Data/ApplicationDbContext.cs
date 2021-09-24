using FinalAssignment.DAL.Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalAssignment.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
    public class AssetDbContext : DbContext
    {
        public AssetDbContext()
        {

        }
        public AssetDbContext(DbContextOptions<AssetDbContext> options)
            : base(options)
        {
        }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Facility> Facilities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer("Server=LAPTOP-PTL9D25U\\SQLEXPRESS;Database=aspnet-FinalAssignment-88D6E914-C60A-4493-93E6-909C834814F2;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }

}
