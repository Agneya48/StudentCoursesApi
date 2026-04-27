using Microsoft.EntityFrameworkCore;
using StudentCoursesApi.Models;

namespace StudentCoursesApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) 
        { 
        }

        public DbSet<StudentProfile> StudentProfiles { get; set; } = null!;

        public DbSet<CourseRecord> CourseRecords { get; set; } = null!;

        // Customize the model creation if needed (e.g., configure relationships, constraints, etc.)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the one-to-many relationship between StudentProfile and CourseRecord
            modelBuilder.Entity<CourseRecord>()
                .HasOne(courseRecord => courseRecord.StudentProfile)
                .WithMany(studentProfile => studentProfile.CourseRecords)
                .HasForeignKey(courseRecord => courseRecord.StudentProfileId);

            // Seed initial data
            SeedData.Seed(modelBuilder);
        }
    }
}
