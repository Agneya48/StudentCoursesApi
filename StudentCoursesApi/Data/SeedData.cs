using Microsoft.EntityFrameworkCore;
using StudentCoursesApi.Models;

namespace StudentCoursesApi.Data
{
    public class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentProfile>().HasData(
                new StudentProfile
                {
                    Id = 1,
                    FullName = "Joshua Hampton",
                    CollegeProgram = "Information Technology",
                    YearInProgram = "Sophomore",
                    FavoriteMajorCourse = "Programming II",
                    FavoriteElectiveCourse = "Second-Year Japanese 1"
                },
                new StudentProfile
                {
                    Id = 2,
                    FullName = "Alex Morgan",
                    CollegeProgram = "Computer Science",
                    YearInProgram = "Sophomore",
                    FavoriteMajorCourse = "Data Structures",
                    FavoriteElectiveCourse = "Basic French I"
                },
                new StudentProfile
                {
                    Id = 3,
                    FullName = "Taylor Reed",
                    CollegeProgram = "Economics",
                    YearInProgram = "Freshman",
                    FavoriteMajorCourse = "Macroeconomics",
                    FavoriteElectiveCourse = "Basic Spanish I"
                },
                new StudentProfile
                {
                    Id = 4,
                    FullName = "Jordan Blake",
                    CollegeProgram = "Mathematics",
                    YearInProgram = "Junior",
                    FavoriteMajorCourse = "Calculus III",
                    FavoriteElectiveCourse = "Japanese Pop, Anime, and Video Game Music"
                },
                new StudentProfile
                {
                    Id = 5,
                    FullName = "Casey Nguyen",
                    CollegeProgram = "Nursing",
                    YearInProgram = "Sophomore",
                    FavoriteMajorCourse = "Fundamentals of Patient Centered Care",
                    FavoriteElectiveCourse = "Introduction to Psychology"
                }
            );

            modelBuilder.Entity<CourseRecord>().HasData(
                // Joshua Hampton - Information Technology
                new CourseRecord
                {
                    Id = 1,
                    StudentProfileId = 1,
                    CourseCode = "IT-2045C",
                    CourseName = "Programming II",
                    Semester = "Spring 2025",
                    CourseCategory = "Major",
                    CreditHours = 3,
                    CompletionStatus = "Completed"
                },
                new CourseRecord
                {
                    Id = 2,
                    StudentProfileId = 1,
                    CourseCode = "IT-3045C",
                    CourseName = "Client-Side Web Programming",
                    Semester = "Summer 2025",
                    CourseCategory = "Major",
                    CreditHours = 3,
                    CompletionStatus = "Completed"
                },
                new CourseRecord 
                { 
                    Id = 3,
                    StudentProfileId = 1,
                    CourseCode = "IT-2035C",
                    CourseName = "Network Infrastructure Management",
                    Semester = "Spring 2026",
                    CourseCategory = "Major",
                    CreditHours = 3,
                    CompletionStatus = "In Progress"
                },
                new CourseRecord
                {
                    Id = 4,
                    StudentProfileId = 1,
                    CourseCode = "JAPN-2001",
                    CourseName = "Second-Year Japanese 1",
                    Semester = "Fall 2026",
                    CourseCategory = "Elective",
                    CreditHours = 5,
                    CompletionStatus = "Planned"
                },

                // Alex Morgan - Computer Science
                new CourseRecord
                {
                    Id = 5,
                    StudentProfileId = 2,
                    CourseCode = "CS-1021C",
                    CourseName = "Computer Science I",
                    Semester = "Fall 2025",
                    CourseCategory = "Major",
                    CreditHours = 3,
                    CompletionStatus = "Completed"
                },
                new CourseRecord
                {
                    Id = 6,
                    StudentProfileId = 2,
                    CourseCode = "MATH-1062",
                    CourseName = "Calculus II",
                    Semester = "Fall 2025",
                    CourseCategory = "General Education",
                    CreditHours = 3,
                    CompletionStatus = "Completed"
                },
                new CourseRecord
                {
                    Id = 7,
                    StudentProfileId = 2,
                    CourseCode = "CS-2028C",
                    CourseName = "Data Structures",
                    Semester = "Spring 2026",
                    CourseCategory = "Major",
                    CreditHours = 3,
                    CompletionStatus = "In Progress"
                },
                new CourseRecord
                {
                    Id = 8,
                    StudentProfileId = 2,
                    CourseCode = "FREN-1001",
                    CourseName = "Basic French I",
                    Semester = "Spring 2026",
                    CourseCategory = "Elective",
                    CreditHours = 5,
                    CompletionStatus = "In Progress"
                },

                // Taylor Reed - Economics
                new CourseRecord
                {
                    Id = 9,
                    StudentProfileId = 3,
                    CourseCode = "ECON-1001",
                    CourseName = "Introduction to Microeconomics",
                    Semester = "Fall 2025",
                    CourseCategory = "Major",
                    CreditHours = 3,
                    CompletionStatus = "Completed"
                },
                new CourseRecord
                {
                    Id = 10,
                    StudentProfileId = 3,
                    CourseCode = "ECON-1002",
                    CourseName = "Introduction to Macroeconomics",
                    Semester = "Spring 2026",
                    CourseCategory = "Major",
                    CreditHours = 3,
                    CompletionStatus = "In Progress"
                },
                new CourseRecord
                {
                    Id = 11,
                    StudentProfileId = 3,
                    CourseCode = "SPAN-1001",
                    CourseName = "Basic Spanish I",
                    Semester = "Spring 2026",
                    CourseCategory = "Elective",
                    CreditHours = 5,
                    CompletionStatus = "In Progress"
                },

                // Jordan Blake - Mathematics
                new CourseRecord
                {
                    Id = 12,
                    StudentProfileId = 4,
                    CourseCode = "MATH-1062",
                    CourseName = "Calculus II",
                    Semester = "Spring 2025",
                    CourseCategory = "Major",
                    CreditHours = 4,
                    CompletionStatus = "Completed"
                },
                new CourseRecord
                {
                    Id = 13,
                    StudentProfileId = 4,
                    CourseCode = "MATH-2063",
                    CourseName = "Multivariable Calculus",
                    Semester = "Fall 2025",
                    CourseCategory = "Major",
                    CreditHours = 4,
                    CompletionStatus = "Completed"
                },
                new CourseRecord
                {
                    Id = 14,
                    StudentProfileId = 4,
                    CourseCode = "FAM-2050",
                    CourseName = "Japanese Pop, Anime, and Video Game Music",
                    Semester = "Fall 2025",
                    CourseCategory = "Elective",
                    CreditHours = 3,
                    CompletionStatus = "Completed"
                },

                // Casey Nguyen - Nursing
                new CourseRecord
                {
                    Id = 15,
                    StudentProfileId = 5,
                    CourseCode = "NBSN-1101",
                    CourseName = "Introduction to Professional Nursing",
                    Semester = "Fall 2025",
                    CourseCategory = "Major",
                    CreditHours = 3,
                    CompletionStatus = "Completed"
                },
                new CourseRecord
                {
                    Id = 16,
                    StudentProfileId = 5,
                    CourseCode = "NBSN-2101C",
                    CourseName = "Fundamentals of Patient Centered Care",
                    Semester = "Spring 2026",
                    CourseCategory = "Major",
                    CreditHours = 6,
                    CompletionStatus = "In Progress"
                },
                new CourseRecord
                {
                    Id = 17,
                    StudentProfileId = 5,
                    CourseCode = "PSY-1001",
                    CourseName = "Introduction to Psychology",
                    Semester = "Fall 2026",
                    CourseCategory = "Elective",
                    CreditHours = 3,
                    CompletionStatus = "Completed"
                }
            );
        }
    }
}
