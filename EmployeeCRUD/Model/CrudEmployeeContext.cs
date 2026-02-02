using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCRUD.Model;

public partial class CrudEmployeeContext : DbContext
{
    public CrudEmployeeContext()
    {
    }

    public CrudEmployeeContext(DbContextOptions<CrudEmployeeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {/*THE CONEXION HAS BEEN MOVED*/ }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdEmployee).HasName("PK__Employee__51C8DD7A83BC422F");

            entity.ToTable("Employee");

            entity.Property(e => e.Cellphone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Mail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.ObjRol).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Rolid)
                .HasConstraintName("FK_Rol");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__2A49584CC68C4063");

            entity.ToTable("Rol");

            entity.Property(e => e.Detail).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
