using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;
using System.Diagnostics;
using System.Reflection;

namespace GoogleKeepBackendClone.Models
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() { }
        public DataBaseContext(DbContextOptions<DataBaseContext> dbContextOptions) : base(dbContextOptions) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-DL3I287;Database=DbGoogleKeepClone; User Id=DESKTOP-DL3I287\\elifn; Encrypt=True; TrustServerCertificate=False;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
