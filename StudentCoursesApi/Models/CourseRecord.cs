using System.ComponentModel.DataAnnotations;

namespace StudentCoursesApi.Models
{
    public class CourseRecord
    {
        public int Id { get; set; }

        public int StudentProfileId { get; set; } // Foreign key to StudentProfile

        public StudentProfile? StudentProfile { get; set; } // Navigation property to StudentProfile

        [Required]
        [StringLength(20)]
        public string CourseCode { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string CourseName { get; set; } = string.Empty;

        [Required]
        [StringLength(30)]
        public string Semester { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string CourseCategory { get; set; } = string.Empty; // e.g., "Major", "Elective", "General Education"

        [Range(1, 6)]
        public int Credits { get; set; }

        [Required]
        [StringLength(30)]
        public string CompletionStatus { get; set; } = string.Empty; // e.g., "Completed", "In Progress", "Planned"
    }
}
