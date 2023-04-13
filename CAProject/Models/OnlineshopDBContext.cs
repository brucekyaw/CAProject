using Microsoft.EntityFrameworkCore;

namespace CAProject.Models
{
    public class OnlineshopDBContext : DbContext
    {

        public OnlineshopDBContext(DbContextOptions<OnlineshopDBContext> options):base(options) 
        { 
        
        }

        public DbSet<Products> Products { get; set; }

    }
}
