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
        public DbSet<NewYuvakDetails> NewYuvakDetails { get; set; }
        public DbSet<SabhaSession> SabhaSession { get; set; }
        public DbSet<NewYuvakSabhaAttend> NewYuvakSabhaAttend { get; set; }
        public DbSet<Kishore> Kishore { get; set; }
    }
}
