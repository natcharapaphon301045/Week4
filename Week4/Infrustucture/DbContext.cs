using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Week4.Domain;

namespace Week4.Infrastructure
{
    public class Week4DbContext : DbContext
    {
        public Week4DbContext(DbContextOptions<Week4DbContext> options) : base(options) { }

        public DbSet<Student> Student { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Major> Majors { get; set; }

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
        }
    }
}
