using catalog_svc.Models;
using Microsoft.EntityFrameworkCore;

namespace catalog_svc.Data 
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<Brand> CatalogBrands { get; set; }
    }
}