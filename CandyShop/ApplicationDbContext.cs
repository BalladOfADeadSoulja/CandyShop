using CandyShop.Models;
using Microsoft.EntityFrameworkCore;
using CandyShop.Models;
using System.Collections.Generic;
using System.Reflection.Emit;


namespace CandyShop
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Candy> Candys { get; set; }
        public DbSet<Category> Categories { get; set; }

        /*public DbSet<Client> Clients { get; set; }
        public DbSet<Role> Roles { get; set; }*/

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candy>()
                .HasOne(s => s.Category)
                .WithMany(c => c.Candys)
                .HasForeignKey(s => s.CategoryId);

            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();

            /* modelBuilder.Entity<Client>()
                 .HasOne(s => s.Role)
                 .WithMany(c => c.Clients)
                 .HasForeignKey(s => s.RoleId);

             modelBuilder.Entity<Role>()
                 .HasIndex(c => c.Name)
                 .IsUnique();*/
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=1234;Database=post;");
    }
}
