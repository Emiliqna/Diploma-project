using System;
using System.Collections.Generic;
using System.Text;
using DechkoWebApp.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DechkoWebApp.Models.Product;

namespace DechkoWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<DechkoWebApp.Models.Product.ProductEditVM> ProductEditVM { get; set; }
        public DbSet<DechkoWebApp.Models.Product.ProductDetailsVM> ProductDetailsVM { get; set; }
        public DbSet<DechkoWebApp.Models.Product.ProductDeleteVM> ProductDeleteVM { get; set; }
      //  public DbSet<DechkoWebApp.Models.Product.ProductCreateVM> ProductCreateVM { get; set; }
      //  public DbSet<DechkoWebApp.Models.Product.ProductIndexVM> ProductIndexVM { get; set; }
    }
}
