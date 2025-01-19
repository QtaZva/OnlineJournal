using Microsoft.EntityFrameworkCore;
using OnlineJournal.Models;

namespace OnlineJournal.Classes
{
    public class ApplicationContext: DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<AccessLevels> AccessLevels { get; set; } = null!;
        public DbSet<Marks> Marks { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=EJ.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.AccessLevel)
                .WithOne()
                .HasForeignKey<User>(u => u.AccessId);

            modelBuilder.Entity<Marks>()
                .HasOne(m => m.Subject) 
                .WithMany()             
                .HasForeignKey(m => m.SubjectId);  
        }
    }
}
