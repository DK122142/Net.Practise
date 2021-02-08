using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EF.DbFirst.Models
{
    public partial class ef_taskContext : DbContext
    {
        public ef_taskContext()
        {
        }

        public ef_taskContext(DbContextOptions<ef_taskContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }
        public virtual DbSet<EmployeePayHistory> EmployeePayHistories { get; set; }
        public virtual DbSet<JobCandidate> JobCandidates { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<SalesPerson> SalesPersons { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=desktop-k9eou6n;Database=ef_task;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasIndex(e => e.Name, "IX_Departments_Name")
                    .IsUnique()
                    .HasFilter("([Name] IS NOT NULL)");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.BusinessEntityId);

                entity.HasIndex(e => new { e.NationalIdNumber, e.LoginId }, "IX_Employees_NationalIdNumber_LoginId")
                    .IsUnique();

                entity.HasIndex(e => e.PersonId, "IX_Employees_PersonId");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PersonId);
            });

            modelBuilder.Entity<EmployeeDepartment>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.DepartmentId, e.ShiftId, e.StartDate });

                entity.ToTable("EmployeeDepartment");

                entity.HasIndex(e => e.DepartmentId, "IX_EmployeeDepartment_DepartmentId");

                entity.HasIndex(e => e.ShiftId, "IX_EmployeeDepartment_ShiftId");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.EmployeeDepartments)
                    .HasForeignKey(d => d.DepartmentId);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeDepartments)
                    .HasForeignKey(d => d.EmployeeId);

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.EmployeeDepartments)
                    .HasForeignKey(d => d.ShiftId);
            });

            modelBuilder.Entity<EmployeePayHistory>(entity =>
            {
                entity.HasKey(e => e.RateChangeDate);

                entity.HasIndex(e => e.EmployeeBusinessEntityId, "IX_EmployeePayHistories_EmployeeBusinessEntityId");

                entity.HasOne(d => d.EmployeeBusinessEntity)
                    .WithMany(p => p.EmployeePayHistories)
                    .HasForeignKey(d => d.EmployeeBusinessEntityId);
            });

            modelBuilder.Entity<JobCandidate>(entity =>
            {
                entity.HasIndex(e => e.BusinessEntityId1, "IX_JobCandidates_BusinessEntityId1");

                entity.HasOne(d => d.BusinessEntityId1Navigation)
                    .WithMany(p => p.JobCandidates)
                    .HasForeignKey(d => d.BusinessEntityId1);
            });

            modelBuilder.Entity<SalesPerson>(entity =>
            {
                entity.HasKey(e => e.BusinessEntityId);

                entity.HasIndex(e => e.EmployeeBusinessEntityId, "IX_SalesPersons_EmployeeBusinessEntityId");

                entity.HasOne(d => d.EmployeeBusinessEntity)
                    .WithMany(p => p.SalesPeople)
                    .HasForeignKey(d => d.EmployeeBusinessEntityId);
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.HasIndex(e => new { e.Name, e.StartTime, e.EndTime }, "IX_Shifts_Name_StartTime_EndTime")
                    .IsUnique()
                    .HasFilter("([Name] IS NOT NULL)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
