using Diginovasi.BusinessObjects.Masters;
using Diginovasi.BusinessObjects.Sales;
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
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<SalesOrderItem> SalesOrderItems { get; set; }
        
    }
}
