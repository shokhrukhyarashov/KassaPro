using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace KassaPro.Data.Entities;

public partial class PosContext : DbContext
{
    // public PosContext()
    // {
    // }

    public PosContext(DbContextOptions<PosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<AdminRole> AdminRoles { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<BusinessSetting> BusinessSettings { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Coupon> Coupons { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<FailedJob> FailedJobs { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<PasswordReset> PasswordResets { get; set; }

    public virtual DbSet<AccessToken> AccessTokens { get; set; }
    public virtual DbSet<AccessToken> RefreshTokens { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<SoftCredential> SoftCredentials { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<TemporaryFile> TemporaryFiles { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<ProductStockIn> ProductStockIns { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    //     => optionsBuilder.UseMySql("server=localhost;port=3306;database=pos;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    modelBuilder.Entity<BusinessSetting>()
        .HasOne(b => b.Company)
        .WithMany(c => c.BusinessSettings)
        .HasForeignKey(b => b.CompanyId)
        .OnDelete(DeleteBehavior.SetNull); 

    modelBuilder.Entity<SubCategory>()
        .HasOne(c => c.Category)
        .WithMany(c => c.SubCategories)
        .HasForeignKey(c => c.CategoryId)
        .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<Category>()
        .HasOne(c => c.Company)
        .WithMany(c => c.Categories)
        .HasForeignKey(c => c.CompanyId)
        .OnDelete(DeleteBehavior.SetNull);
    
    modelBuilder.Entity<Product>()
        .HasOne(p => p.Category)
        .WithMany(c => c.Products)
        .HasForeignKey(p => p.CategoryId)
        .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<Product>()
        .HasOne(p => p.SubCategory)
        .WithMany(sc => sc.Products)
        .HasForeignKey(p => p.SubCategoryId)
        .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<ProductStockIn>()
        .HasOne(p => p.Product)
        .WithMany(p => p.ProductStockIns)
        .HasForeignKey(p => p.ProductId)
        .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<ProductStockIn>()
        .HasOne(p => p.CreatedBy)
        .WithMany(a => a.ProductStockIns)
        .HasForeignKey(p => p.CreatedByAdminId)
        .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<ProductStockIn>()
        .HasOne(p => p.Company)
        .WithMany(c => c.ProductStockIns)
        .HasForeignKey(p => p.CompanyId)
        .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<Transaction>()
        .HasOne(t => t.Account)
        .WithMany(a=> a.Transactions)
        .HasForeignKey(t => t.AccountId)
        .OnDelete(DeleteBehavior.SetNull);

    modelBuilder.Entity<Transaction>()
        .HasOne(t => t.Customer)
        .WithMany(t=> t.Transactions)
        .HasForeignKey(t => t.CustomerId)
        .OnDelete(DeleteBehavior.SetNull);

    modelBuilder.Entity<Transaction>()
        .HasOne(t => t.Supplier)
        .WithMany()
        .HasForeignKey(t => t.SupplierId)
        .OnDelete(DeleteBehavior.SetNull);

    modelBuilder.Entity<Transaction>()
        .HasOne(t => t.Order)
        .WithOne(t=> t.Tran)
        .HasForeignKey<Transaction>(t => t.OrderId)
        .OnDelete(DeleteBehavior.SetNull);

    modelBuilder.Entity<Transaction>()
        .HasOne(t => t.Company)
        .WithMany(t=> t.Transactions)
        .HasForeignKey(t => t.CompanyId)
        .OnDelete(DeleteBehavior.SetNull);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
