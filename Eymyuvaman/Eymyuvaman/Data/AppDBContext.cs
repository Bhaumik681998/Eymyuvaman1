using Eymyuvaman.Model;
using Eymyuvaman.Model.Event;
using Eymyuvaman.ViewModel.Report;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Eymyuvaman.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        #region :: DB Model ::
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
        public DbSet<City> City { get; set; }
        public DbSet<Zones> Zones { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<Designation> Designation { get; set; }
        #endregion

        public DbSet<YuvakProfileDetailVM> YuvakProfileDetailVM { get; set; }
        public DbSet<YuvakSatsangDetalVM> YuvakSatsangDetalVM { get; set; }
        public DbSet<YuvakSkillDetailVM> YuvakSkillDetailVM { get; set; }
        public DbSet<FamilyMasterDetailVM> FamilyMasterDetailVM { get; set; }
        public DbSet<BirthdayResponseVM> BirthdayResponseVM { get; set; }
        public DbSet<YuvakJobDetailVM> YuvakJobDetailVM { get; set; }
        public DbSet<AttendanceReportDetailVM> AttendanceReportDetailVM { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<YuvakProfileDetailVM>().HasNoKey();
            modelBuilder.Entity<YuvakProfileDetailVM>().Property(x => x.YuvakName).HasColumnName("Yuvak Name");

            modelBuilder.Entity<YuvakSatsangDetalVM>().HasNoKey();
            modelBuilder.Entity<YuvakSatsangDetalVM>().Property(x => x.YuvakName).HasColumnName("Yuvak Name");

            modelBuilder.Entity<YuvakSkillDetailVM>().HasNoKey();

            modelBuilder.Entity<FamilyMasterDetailVM>().HasNoKey();
            modelBuilder.Entity<FamilyMasterDetailVM>().Property(x => x.YuvakName).HasColumnName("Yuvak Name");

            modelBuilder.Entity<YuvakJobDetailVM>().HasNoKey();
            modelBuilder.Entity<YuvakJobDetailVM>().Property(x => x.YuvakName).HasColumnName("Yuvak Name");

            modelBuilder.Entity<BirthdayResponseVM>().HasNoKey();
            modelBuilder.Entity<BirthdayResponseVM>().Property(x => x.YuvakName).HasColumnName("Yuvak Name");

            modelBuilder.Entity<AttendanceReportDetailVM>().HasNoKey();
        }
    }
}
