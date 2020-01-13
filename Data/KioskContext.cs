using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using IceCreamDesktop.Core.Entities;

namespace IceCreamDesktop.Data
{
    public class KioskContext : DbContext
    {
        public DbSet<IceCream> IceCreams { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
