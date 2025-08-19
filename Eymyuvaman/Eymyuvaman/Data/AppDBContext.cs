using Eymyuvaman.Model;
using Eymyuvaman.Model.Evant;
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
        public DbSet<Evant> Evant { get; set; }
        public DbSet<EvantArea> EvantArea { get; set; }
        public DbSet<EvantDetial> EvantDetial { get; set; }
        public DbSet<EvantEntry> EvantEntry { get; set; }
        public DbSet<EventEntryLog> EventEntryLog { get; set; }
    }
}
