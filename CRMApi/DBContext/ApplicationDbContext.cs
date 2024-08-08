using CRMApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CRMApi.DBContext
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        
        }  
        public DbSet<Customer> customers {  get; set; }      
    }
}
