using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebSalesMvc.Models;

namespace WebSalesMvc.Data
{
    public class WebSalesMvcContext : DbContext
    {
        public WebSalesMvcContext(DbContextOptions<WebSalesMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<SalesRecord> SalesRecords { get; set; }

    }
}
