using GymManagement.Agregateroot.Models;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Repository.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Slot> Slots { get; set; }
        public DbSet<Trainer> Trainers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Slot>().ToTable("Slots");
            modelBuilder.Entity<Trainer>().ToTable("Trainers");
        }
    }
}
