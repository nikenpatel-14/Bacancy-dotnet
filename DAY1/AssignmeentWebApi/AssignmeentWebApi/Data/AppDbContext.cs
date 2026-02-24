using AssignmeentWebApi.Repository.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace AssignmeentWebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        public DbSet<Product> products { get; set; }
    }
}
