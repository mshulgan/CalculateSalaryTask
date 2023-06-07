using Microsoft.EntityFrameworkCore;
using SalaryCalculation.Extensions;
using SalaryCalculation.Models;
using System.Runtime.ConstrainedExecution;

namespace SalaryCalculation
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Position)
                .WithMany(p => p.Employees)
                .HasForeignKey(e => e.PositionId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Scores)
                .WithOne(s => s.Employee)
                .HasForeignKey(s => s.EmployeeId);

            modelBuilder.Entity<Position>()
                .HasMany(p => p.BaseSalaries)
                .WithOne(bs => bs.Position)
                .HasForeignKey(bs => bs.PositionId);

            modelBuilder.Entity<SatisfactionScore>()
                .HasOne(ss => ss.Score)
                .WithMany(s => s.SatisfactionScores)
                .HasForeignKey(ss => ss.ScoreId);

            modelBuilder.Seed();

        }
    }
}
