using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Repository.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Region> Regions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobHistory> JobHistories { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

       
            modelBuilder.Entity<JobHistory>()
                 .HasOne(jh => jh.Employee)
                 .WithMany(e => e.Histories)
                 .HasForeignKey(jh => jh.EmployeeId)
                 .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<JobHistory>()
                .HasOne(jh => jh.Job)
                .WithMany(j => j.JobHistories)
                .HasForeignKey(jh => jh.JobId)
                .OnDelete(DeleteBehavior.Restrict);  

            modelBuilder.Entity<JobHistory>()
                .HasOne(jh => jh.Department)
                .WithMany(d => d.JobHistories)
                .HasForeignKey(jh => jh.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);  
        }
    }
}
