using System;
using System.Collections.Generic;

namespace KassaPro.Data.Entities;

public partial class Company
{
    public ulong Id { get; set; }

    public string? CompanyName { get; set; }

    public string? SubDomainPrefix { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }= new List<OrderDetail>();
    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();
    public virtual ICollection<Product> Products { get; set; }= new List<Product>();
    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
    public virtual ICollection<Coupon> Coupons { get; set; }= new List<Coupon>();
    public virtual ICollection<Order> Orders { get; set; }= new List<Order>();
    public virtual ICollection<Brand> Brands { get; set; } = new List<Brand>();
    public virtual ICollection<BusinessSetting> BusinessSettings { get; set; } = new List<BusinessSetting>();
    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
    public virtual ICollection<ProductStockIn> ProductStockIns { get; set; } = new List<ProductStockIn>();
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();



}
