using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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


    public virtual DbSet<OauthAccessToken> OauthAccessTokens { get; set; }

    public virtual DbSet<OauthAuthCode> OauthAuthCodes { get; set; }

    public virtual DbSet<OauthClient> OauthClients { get; set; }

    public virtual DbSet<OauthPersonalAccessClient> OauthPersonalAccessClients { get; set; }

    public virtual DbSet<OauthRefreshToken> OauthRefreshTokens { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<PasswordReset> PasswordResets { get; set; }

    public virtual DbSet<PersonalAccessToken> PersonalAccessTokens { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<SoftCredential> SoftCredentials { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<TemporaryFile> TemporaryFiles { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<User> Users { get; set; }

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

    


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
