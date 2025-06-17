using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal.models;

public partial class CrownBeefContext : DbContext
{
    public CrownBeefContext()
    {
    }

    public CrownBeefContext(DbContextOptions<CrownBeefContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=michal;Database=CrownBeef;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryCode).HasName("PK__Categori__43107BC07EF695D7");

            entity.Property(e => e.CategoryCode).HasColumnName("categoryCode");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("categoryName");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerCode).HasName("PK__Customer__47BC9F2C434A7A3A");

            entity.Property(e => e.CustomerCode).HasColumnName("customerCode");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("customerName");
            entity.Property(e => e.DateOfBirth).HasColumnName("dateOfBirth");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductCode).HasName("PK__Products__C2068388B5F5A4BE");

            entity.Property(e => e.ProductCode).HasColumnName("productCode");
            entity.Property(e => e.CategoryCode).HasColumnName("categoryCode");
            entity.Property(e => e.LastUpdateDate).HasColumnName("last_update_date");
            entity.Property(e => e.Picture)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("picture");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductDescription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("productDescription");
            entity.Property(e => e.ProductName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("productName");
            entity.Property(e => e.QuantityInStock).HasColumnName("quantity_in_stock");

            entity.HasOne(d => d.CategoryCodeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__catego__398D8EEE");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.PurchaseCode).HasName("PK__Purchase__9D0E3D05B10880AE");

            entity.ToTable("Purchase");

            entity.Property(e => e.PurchaseCode).HasColumnName("purchaseCode");
            entity.Property(e => e.CustomerCode).HasColumnName("customerCode");
            entity.Property(e => e.Note)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("note");
            entity.Property(e => e.PurchaseAmount).HasColumnName("purchaseAmount");
            entity.Property(e => e.PurchaseDate).HasColumnName("purchaseDate");

            entity.HasOne(d => d.CustomerCodeNavigation).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.CustomerCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Purchase__custom__3E52440B");
        });

        modelBuilder.Entity<PurchaseDetail>(entity =>
        {
            entity.HasKey(e => e.DetailsCode).HasName("PK__Purchase__09FBEE710ECBF8AE");

            entity.Property(e => e.DetailsCode).HasColumnName("detailsCode");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.ProductCode).HasColumnName("productCode");
            entity.Property(e => e.PurchaseCode).HasColumnName("purchaseCode");

            entity.HasOne(d => d.ProductCodeNavigation).WithMany(p => p.PurchaseDetails)
                .HasForeignKey(d => d.ProductCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseD__produ__4222D4EF");

            entity.HasOne(d => d.PurchaseCodeNavigation).WithMany(p => p.PurchaseDetails)
                .HasForeignKey(d => d.PurchaseCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseD__purch__412EB0B6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
