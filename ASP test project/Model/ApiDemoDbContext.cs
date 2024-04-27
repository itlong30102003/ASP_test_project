using Microsoft.EntityFrameworkCore;

namespace ASP_test_project.Model
{
    public class ApiDemoDbContext : DbContext
    {
        public ApiDemoDbContext(DbContextOptions<ApiDemoDbContext> options) : base(options) 
        {

        }
        public DbSet<Users> Users { get; set; }
    }
}
