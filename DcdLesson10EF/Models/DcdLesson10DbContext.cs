using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DcdLesson10EF.Models;

public partial class DcdLesson10DbContext : DbContext
{
    public DcdLesson10DbContext()
    {
    }

    public DcdLesson10DbContext(DbContextOptions<DcdLesson10DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cate> Cates { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-ICPA8AC\\SQLEXPRESS;Database=DcdLesson10DB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cate>(entity =>
        {
            entity.ToTable("Cate");

            entity.Property(e => e.CateId)
                .ValueGeneratedNever()
                .HasColumnName("CateID");
            entity.Property(e => e.CateName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
