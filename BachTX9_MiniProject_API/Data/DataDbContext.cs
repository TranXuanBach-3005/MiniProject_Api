using BachTX9_MiniProject_API.Models;
using Microsoft.EntityFrameworkCore;

namespace BachTX9_MiniProject_API.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext( DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedData.SeedAllData(modelBuilder);
            modelBuilder.Entity<UserTest>(entity =>
            {
                entity.HasOne(e => e.user)
                .WithMany(e => e.userTests)
                .HasForeignKey(e => e.UserId)
                .HasConstraintName("FK_UserTest_User");

                entity.HasOne(e => e.test)
                .WithMany(e => e.userTests)
                .HasForeignKey(e => e.TestId)
                .HasConstraintName("FK_UserTest_Test");
            });
            modelBuilder.Entity<Questions>()
                .HasOne<Test>(s => s.Test)
                .WithMany(g => g.questions)
                .HasForeignKey(s => s.TestId);

            modelBuilder.Entity<Answers>()
                .HasOne<Questions>(s => s.Questions)
                .WithMany(g => g.answers)
                .HasForeignKey(s => s.QuesId);
        }
        public DbSet<User> users { get; set; }
        public DbSet<Test> tests { get; set; }
        public DbSet<UserTest> userTests { get; set; }
        public DbSet<Questions> questions { get; set; }
        public DbSet<Answers> answers { get; set; }
    }
}
