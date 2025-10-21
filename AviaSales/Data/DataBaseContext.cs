using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AviaSales.Data;

public partial class DataBaseContext : DbContext
{
    public DataBaseContext()
    {
    }

    public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<Promo> Promos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=AviaSales;Username=postgres;Password=123;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.IdBooking).HasName("Booking_pkey");

            entity.ToTable("Booking");

            entity.Property(e => e.IdBooking).HasColumnName("ID_Booking");
            entity.Property(e => e.IdFlight).HasColumnName("ID_Flight");
            entity.Property(e => e.IdPromo).HasColumnName("ID_Promo");
            entity.Property(e => e.IdUser).HasColumnName("ID_User");

            entity.HasOne(d => d.IdFlightNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.IdFlight)
                .HasConstraintName("Booking_ID_Flight_fkey");

            entity.HasOne(d => d.IdPromoNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.IdPromo)
                .HasConstraintName("Booking_ID_Promo_fkey");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("Booking_ID_User_fkey");
        });

        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasKey(e => e.IdFlight).HasName("Flight_pkey");

            entity.ToTable("Flight");

            entity.Property(e => e.IdFlight).HasColumnName("ID_Flight");
            entity.Property(e => e.Aircraft).HasMaxLength(50);
            entity.Property(e => e.Airline).HasMaxLength(50);
            entity.Property(e => e.ArrivalCity).HasMaxLength(50);
            entity.Property(e => e.Class)
                .HasMaxLength(50)
                .HasDefaultValueSql("'economy'::character varying");
            entity.Property(e => e.DepartureCity).HasMaxLength(50);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValueSql("'scheduled'::character varying");
        });

        modelBuilder.Entity<Promo>(entity =>
        {
            entity.HasKey(e => e.IdPromo).HasName("Promo_pkey");

            entity.ToTable("Promo");

            entity.Property(e => e.IdPromo).HasColumnName("ID_Promo");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("Role_pkey");

            entity.ToTable("Role");

            entity.Property(e => e.IdRole).HasColumnName("ID_Role");
            entity.Property(e => e.Title).HasMaxLength(20);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("User_pkey");

            entity.ToTable("User");

            entity.Property(e => e.IdUser).HasColumnName("ID_User");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.IdRole).HasColumnName("ID_Role");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("User_ID_Role_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
