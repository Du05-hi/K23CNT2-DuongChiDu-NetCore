using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DuongChiDu_2310900022.Models;

public partial class DuongChiDu2310900022Context : DbContext
{
    public DuongChiDu2310900022Context()
    {
    }

    public DuongChiDu2310900022Context(DbContextOptions<DuongChiDu2310900022Context> options)
        : base(options)
    {
    }

    public virtual DbSet<DcdEmployee> DcdEmployees { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-ICPA8AC\\SQLEXPRESS;Database=DuongChiDu_2310900022;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DcdEmployee>(entity =>
        {
            entity.HasKey(e => e.DcdEmpId).HasName("PK__DcdEmplo__AE4A25C869B431FE");

            entity.ToTable("DcdEmployee");

            entity.Property(e => e.DcdEmpId)
                .ValueGeneratedNever()
                .HasColumnName("dcdEmpId");
            entity.Property(e => e.DcdEmpLevel)
                .HasMaxLength(50)
                .HasColumnName("dcdEmpLevel");
            entity.Property(e => e.DcdEmpName)
                .HasMaxLength(100)
                .HasColumnName("dcdEmpName");
            entity.Property(e => e.DcdEmpStartDate).HasColumnName("dcdEmpStartDate");
            entity.Property(e => e.DcdEmpStatus).HasColumnName("dcdEmpStatus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
