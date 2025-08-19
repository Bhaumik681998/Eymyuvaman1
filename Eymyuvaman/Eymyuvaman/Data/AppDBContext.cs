using Eymyuvaman.Model;
using Microsoft.EntityFrameworkCore;

namespace Eymyuvaman.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<UserMaster> UserMaster { get; set; }
    }
}
