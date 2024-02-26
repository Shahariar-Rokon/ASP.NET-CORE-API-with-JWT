using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CAPIV3.Models;

public partial class Capiv3dbContext : DbContext
{
    public Capiv3dbContext()
    {
    }

    public Capiv3dbContext(DbContextOptions<Capiv3dbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CAPIV3DB;Trusted_Connection=true;TrustServerCertificate=true;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F111923A2DF");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ImageName).IsUnicode(false);
            entity.Property(e => e.ImageUrl).IsUnicode(false);
            entity.Property(e => e.JoinDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.HasKey(e => e.ExperienceId).HasName("PK__tmp_ms_x__2F4E3449F1BE2DB1");

            entity.ToTable("Experience");

            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Employee).WithMany(p => p.Experiences)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Experienc__Emplo__31EC6D26");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.TblUserId).HasName("PK__tmp_ms_x__A717A8B9A4EA7DE2");

            entity.ToTable("TblUser");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.EmailId).IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
