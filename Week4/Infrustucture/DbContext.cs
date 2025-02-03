
using Microsoft.EntityFrameworkCore;
using Week4.Domain;

namespace Week4.Infrastructure
{
    public class Week4DbContext : DbContext
    {
        public Week4DbContext(DbContextOptions<Week4DbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<BehaviorScore> BehaviorScores { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Professor)
                .WithMany(p => p.Student)
                .HasForeignKey(s => s.ProfessorID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Major)
                .WithMany(m => m.Student)
                .HasForeignKey(s => s.MajorID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentClass>()
                .HasKey(sc => new { sc.StudentID, sc.ClassID }); 

            modelBuilder.Entity<StudentClass>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentClasses)
                .HasForeignKey(sc => sc.StudentID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentClass>()
                .HasOne(sc => sc.Class)
                .WithMany(c => c.StudentClasses)
                .HasForeignKey(sc => sc.ClassID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
