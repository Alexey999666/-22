using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Практос_22.ModelsDB;

public partial class EditionsCityContext : DbContext
{
    public EditionsCityContext()
    {
    }

    public EditionsCityContext(DbContextOptions<EditionsCityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Edition> Editions { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress; Database=EditionsCity; User=исп-31; Password= 1234567890; Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Edition>(entity =>
        {
            entity.HasKey(e => e.Index).HasName("PK_Editions");

            entity.ToTable("Edition");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.TitleEdition).HasMaxLength(255);
            entity.Property(e => e.Type).HasMaxLength(255);
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK_Organizations");

            entity.ToTable("Organization");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.TitleOrganization).HasMaxLength(255);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.HasKey(e => e.SubscriptionNumber);

            entity.ToTable("Subscription");

            entity.Property(e => e.Discount).HasColumnType("numeric(12, 2)");
            entity.Property(e => e.SubscriptionDate).HasColumnType("datetime");

            entity.HasOne(d => d.CodeNavigation).WithMany(p => p.Subscriptions)
                .HasForeignKey(d => d.Code)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Subscription_Organization");

            entity.HasOne(d => d.IndexNavigation).WithMany(p => p.Subscriptions)
                .HasForeignKey(d => d.Index)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Subscription_Edition");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.UserLogin).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e.UserPassword).HasMaxLength(50);
            entity.Property(e => e.UserPatronymic).HasMaxLength(50);
            entity.Property(e => e.UserSurname).HasMaxLength(50);

            entity.HasOne(d => d.UserRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
