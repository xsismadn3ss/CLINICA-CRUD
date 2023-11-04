using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CLINICA_CRUD.Models;

public partial class CrudClinicaContext : DbContext
{
    public CrudClinicaContext()
    {
    }

    public CrudClinicaContext(DbContextOptions<CrudClinicaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alergium> Alergia { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<Discapacidad> Discapacidads { get; set; }

    public virtual DbSet<Enfermedad> Enfermedads { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<RegistroMedico> RegistroMedicos { get; set; }

    public virtual DbSet<Tratamiento> Tratamientos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=CRUD_CLINICA;Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alergium>(entity =>
        {
            entity.ToTable("Alergium");
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdPaciente).HasColumnName("Id_Paciente");
        });

        modelBuilder.Entity<Discapacidad>(entity =>
        {
            entity.ToTable("Discapacidad");
        });

        modelBuilder.Entity<Enfermedad>(entity =>
        {
            entity.ToTable("Enfermedad");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.ToTable("Paciente");
        });

        modelBuilder.Entity<RegistroMedico>(entity =>
        {
            entity.ToTable("RegistroMedico");

            entity.HasIndex(e => e.CitasId, "IX_RegistroMedico_CitasId");

            entity.HasIndex(e => e.IdAlergiaNavigationId, "IX_RegistroMedico_IdAlergiaNavigationId");

            entity.HasIndex(e => e.IdDiscapacidadNavigationId, "IX_RegistroMedico_IdDiscapacidadNavigationId");

            entity.HasIndex(e => e.IdEnfermedadNavigationId, "IX_RegistroMedico_IdEnfermedadNavigationId");

            entity.HasIndex(e => e.IdPacienteNavigationId, "IX_RegistroMedico_IdPacienteNavigationId");

            entity.HasIndex(e => e.IdTratamientoNavigationId, "IX_RegistroMedico_IdTratamientoNavigationId");

            entity.HasOne(d => d.Citas).WithMany(p => p.RegistroMedicos).HasForeignKey(d => d.CitasId);

            entity.HasOne(d => d.IdAlergiaNavigation).WithMany(p => p.RegistroMedicos).HasForeignKey(d => d.IdAlergiaNavigationId);

            entity.HasOne(d => d.IdDiscapacidadNavigation).WithMany(p => p.RegistroMedicos).HasForeignKey(d => d.IdDiscapacidadNavigationId);

            entity.HasOne(d => d.IdEnfermedadNavigation).WithMany(p => p.RegistroMedicos).HasForeignKey(d => d.IdEnfermedadNavigationId);

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.RegistroMedicos).HasForeignKey(d => d.IdPacienteNavigationId);

            entity.HasOne(d => d.IdTratamientoNavigation).WithMany(p => p.RegistroMedicos).HasForeignKey(d => d.IdTratamientoNavigationId);
        });

        modelBuilder.Entity<Tratamiento>(entity =>
        {
            entity.ToTable("Tratamiento");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
