using Microsoft.EntityFrameworkCore;

namespace Taskcomapny.models
{
    public class CompanyDbContext :DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options) { 
        
        }
        public DbSet<Company> Companies { get; set; }
    }
}
