using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PageAdmin.Models;

namespace PageAdmin.Models
{
    public class AdminDbContext:DbContext
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options)
        {

        }
       
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<PageAdmin.Models.SalesPerson> SalesPerson { get; set; }
        public DbSet<PageAdmin.Models.Invoice> Invoice { get; set; }
    }
}
