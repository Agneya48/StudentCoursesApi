using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StudentCoursesApi.Models
{
    public class StudentProfile
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string CollegeProgram { get; set; } = string.Empty;

        [Required]
        [StringLength(30)]
        public string YearInProgram { get; set; } = string.Empty;

        [StringLength(100)]
        public string? FavoriteMajorCourse { get; set; } = string.Empty;
        
        [StringLength(100)]
        public string? FavoriteElectiveCourse { get; set; } = string.Empty;

        // One to many relationship with CourseRecord, a student can have many course records
        [JsonIgnore]
        public List<CourseRecord> CourseRecords { get; set; } = new(); 
    }
}
