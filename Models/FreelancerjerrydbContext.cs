using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FreelancerJerry.Models;

public partial class FreelancerjerrydbContext : DbContext
{
    // public FreelancerjerrydbContext()
    // {
    // }

    public FreelancerjerrydbContext(DbContextOptions<FreelancerjerrydbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Freelancer> Freelancers { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__BOOKING__5DE3A5B1F1C6EB62");

            entity.ToTable("BOOKING");

            entity.Property(e => e.BookingId)
                .ValueGeneratedNever()
                .HasColumnName("booking_id");
            entity.Property(e => e.BookingName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("booking_name");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.FreelancerId).HasColumnName("freelancer_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__BOOKING__custome__3B75D760");

            entity.HasOne(d => d.Freelancer).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.FreelancerId)
                .HasConstraintName("FK__BOOKING__freelan__3C69FB99");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__CUSTOMER__CD65CB85FC7939C7");

            entity.ToTable("CUSTOMER");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("customer_id");
            entity.Property(e => e.Email)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Password_Hash)
            .HasMaxLength(100)
            .IsUnicode(false)
            .HasColumnName("password_hash");
        });

        modelBuilder.Entity<Freelancer>(entity =>
        {
            entity.HasKey(e => e.FreelancerId).HasName("PK__FREELANC__292D1C2069BAC186");

            entity.ToTable("FREELANCER");

            entity.Property(e => e.FreelancerId)
                .ValueGeneratedNever()
                .HasColumnName("freelancer_id");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("phone_number");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__PAYMENT__ED1FC9EA64B95E60");

            entity.ToTable("PAYMENT");

            entity.Property(e => e.PaymentId)
                .ValueGeneratedNever()
                .HasColumnName("payment_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.FreelancerId).HasColumnName("freelancer_id");
            entity.Property(e => e.TransactionDate)
                .HasColumnType("datetime")
                .HasColumnName("transaction_date");

            entity.HasOne(d => d.Booking).WithMany(p => p.Payments)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK__PAYMENT__booking__412EB0B6");

            entity.HasOne(d => d.Customer).WithMany(p => p.Payments)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__PAYMENT__custome__3F466844");

            entity.HasOne(d => d.Freelancer).WithMany(p => p.Payments)
                .HasForeignKey(d => d.FreelancerId)
                .HasConstraintName("FK__PAYMENT__freelan__403A8C7D");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__REVIEW__60883D906487C300");

            entity.ToTable("REVIEW");

            entity.Property(e => e.ReviewId)
                .ValueGeneratedNever()
                .HasColumnName("review_id");
            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.FreelancerId).HasColumnName("freelancer_id");
            entity.Property(e => e.Rating).HasColumnName("rating");

            entity.HasOne(d => d.Booking).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK__REVIEW__booking___45F365D3");

            entity.HasOne(d => d.Customer).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__REVIEW__customer__44FF419A");

            entity.HasOne(d => d.Freelancer).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.FreelancerId)
                .HasConstraintName("FK__REVIEW__freelanc__440B1D61");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
