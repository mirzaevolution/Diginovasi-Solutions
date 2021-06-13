using Diginovasi.BusinessObjects.Masters;
using Diginovasi.BusinessObjects.Sales;
using Diginovasi.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diginovasi.Data
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Satuan> Satuans { get; set; }
        public virtual DbSet<SalesOrder> SalesOrders { get; set; }
        public virtual DbSet<SalesOrderItem> SalesOrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CustomerEntityConfiguration());
            builder.ApplyConfiguration(new MaterialEntityConfiguration());
            builder.ApplyConfiguration(new SatuanEntityConfiguration());
            builder.ApplyConfiguration(new SalesOrderEntityConfiguration());
            builder.ApplyConfiguration(new SalesOrderEntityConfiguration());
        }

    }
}
