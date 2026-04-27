using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCoursesApi.Data;
using StudentCoursesApi.Models;

namespace StudentCoursesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentProfilesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentProfilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StudentProfiles or GET: api/StudentProfiles?id={id}
        // uses ?id= query because swagger UI doesn't support optional route parameters
        [HttpGet]
        public async Task<IActionResult> GetStudentProfiles([FromQuery] int? id)
        {
            // If no ID is provided, return the first 5 student profiles
            if (id == null || id == 0)
            {
                List<StudentProfile> studentProfiles = await _context.StudentProfiles
                    .OrderBy(studentProfile => studentProfile.Id)
                    .Take(5)
                    .ToListAsync();

                return Ok(studentProfiles);
            }

            // If an ID is provided, return the student profile with that ID
            StudentProfile? studentProfile = await _context.StudentProfiles
                .FindAsync(id.Value);

            // If no student profile with the specified ID exists, return a 404 Not Found response
            if (studentProfile == null)
            {
                return NotFound();
            }

            return Ok(studentProfile);
        }

        // GET: api/StudentProfiles/{id}/courses
        // This endpoint returns a student profile along with their course records, ordered by course ID
        [HttpGet("{id}/courses")]
        public async Task<IActionResult> GetStudentProfileWithCourses(int id)
        {
            var studentProfile = await _context.StudentProfiles
                .Where(profile => profile.Id == id)
                .Select(profile => new
                {
                    profile.Id,
                    profile.FullName,
                    profile.CollegeProgram,
                    profile.YearInProgram,
                    profile.FavoriteMajorCourse,
                    profile.FavoriteElectiveCourse,
                    CourseRecords = profile.CourseRecords
                        .OrderBy(course => course.Id)
                        .Select(course => new
                        {
                            course.Id,
                            course.CourseCode,
                            course.CourseName,
                            course.Semester,
                            course.CourseCategory,
                            course.CreditHours,
                            course.CompletionStatus
                        })
                })
                .FirstOrDefaultAsync();

            // If no student profile with the specified ID exists, return a 404 Not Found response
            if (studentProfile == null)
            {
                return NotFound();
            }

            return Ok(studentProfile);
        }

        // POST: api/StudentProfiles
        [HttpPost]
        public async Task<ActionResult<StudentProfile>> CreateStudentProfile(StudentProfile studentProfile)
        {
            _context.StudentProfiles.Add(studentProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetStudentProfiles),
                new { id = studentProfile.Id },
                studentProfile);
        }

        // PUT: api/StudentProfiles/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudentProfile(int id, StudentProfile studentProfile)
        {
            // Ensure the ID in the URL matches the ID in the request body
            if (id != studentProfile.Id)
            {
                return BadRequest();
            }

            // Check if a student profile with the specified ID exists
            bool studentProfileExists = await _context.StudentProfiles
                .AnyAsync(existingStudentProfile => existingStudentProfile.Id == id);

            if (!studentProfileExists)
            {
                return NotFound();
            }

            // Mark the student profile as modified and save changes
            _context.Entry(studentProfile).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/StudentProfiles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentProfile(int id)
        {
            // Find the student profile with the specified ID
            StudentProfile? studentProfile = await _context.StudentProfiles
                .FindAsync(id);

            // If no student profile with the specified ID exists, return a 404 Not Found response
            if (studentProfile == null)
            {
                return NotFound();
            }

            // Remove the student profile from the database and save changes
            _context.StudentProfiles.Remove(studentProfile);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
