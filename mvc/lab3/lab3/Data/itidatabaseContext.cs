using lab3.Models;
using Microsoft.EntityFrameworkCore;

namespace lab3.Data
{
    public class itidatabaseContext : DbContext
    {
        internal object courses;

        public virtual DbSet<Student> students {get;set;}
        public virtual DbSet<Department> department {get;set;}
        public virtual DbSet<studentCourse> studentsCourse {get;set;}
        public virtual DbSet<course> Courses { get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=mvc2;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
        //set PK ,exc with data fluint here
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<course>().HasKey(a => a.courseId);//courseid as PK
            modelBuilder.Entity<course>().Property(a => a.courseName).IsRequired();
            modelBuilder.Entity<studentCourse>().HasKey(a => new { a.stdId, a.crsId });
            base.OnModelCreating(modelBuilder);
        }
    }
    
}
