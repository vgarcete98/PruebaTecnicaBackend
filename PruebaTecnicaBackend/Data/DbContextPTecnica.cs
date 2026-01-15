using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaBackend.Domain.Entities;

namespace PruebaTecnicaBackend.Data;

public partial class DbContextPTecnica : DbContext
{
    public DbContextPTecnica()
    {
    }

    public DbContextPTecnica(DbContextOptions<DbContextPTecnica> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.User).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasIndex(e => e.Code, "IX_Currencies_Code").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.RateToBase).HasColumnType("NUMERIC");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Email, "IX_Users_Email").IsUnique();

            entity.Property(e => e.IsActive).HasDefaultValue(1);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
