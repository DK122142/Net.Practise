using EF.CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF.CodeFirst.EF
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<EmployeePayHistory> EmployeePayHistories { get; set; }

        public DbSet<SalesPerson> SalesPersons { get; set; }

        public DbSet<JobCandidate> JobCandidates { get; set; }

        public DbSet<Shift> Shifts { get; set; }

        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=desktop-k9eou6n;Initial Catalog=ef_task;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeDepartment>()
                .HasKey(ed => new {ed.EmployeeId, ed.DepartmentId, ed.ShiftId, ed.StartDate});

            modelBuilder.Entity<EmployeeDepartment>()
                .HasOne<Employee>(ed => ed.Employee)
                .WithMany(e => e.EmployeeDepartments)
                .HasForeignKey(ed => ed.EmployeeId);

            modelBuilder.Entity<EmployeeDepartment>()
                .HasOne<Department>(ed => ed.Department)
                .WithMany(d => d.EmployeeDepartments)
                .HasForeignKey(ed => ed.DepartmentId);

            modelBuilder.Entity<EmployeeDepartment>()
                .HasOne<Shift>(ed => ed.Shift)
                .WithMany(s => s.EmployeeDepartments)
                .HasForeignKey(ed => ed.ShiftId);
        }
    }
}
