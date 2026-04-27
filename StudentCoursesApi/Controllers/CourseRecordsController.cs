using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCoursesApi.Data;
using StudentCoursesApi.Models;

namespace StudentCoursesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseRecordsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CourseRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CourseRecords or GET: api/CourseRecords?id={id}
        // uses ?id= query because swagger UI doesn't support optional route parameters
        [HttpGet]
        public async Task<IActionResult> GetCourseRecords([FromQuery] int? id)
        {
            // If no ID is provided, return the first 5 course records
            if (id == null || id == 0)
            {
                List<CourseRecord> courseRecords = await _context.CourseRecords
                    .OrderBy(courseRecord => courseRecord.Id)
                    .Take(5)
                    .ToListAsync();

                return Ok(courseRecords);
            }

            // If an ID is provided, return the course record with that ID
            CourseRecord? courseRecord = await _context.CourseRecords
                .FindAsync(id.Value);

            // If the course record with the specified ID does not exist, return a 404 Not Found response
            if (courseRecord == null)
            {
                return NotFound();
            }

            return Ok(courseRecord);
        }

        // POST: api/CourseRecords
        [HttpPost]
        public async Task<ActionResult<CourseRecord>> CreateCourseRecord(CourseRecord courseRecord)
        {
            // Validate that the provided StudentProfileId exists in the database
            bool studentProfileExists = await _context.StudentProfiles
                .AnyAsync(studentProfile => studentProfile.Id == courseRecord.StudentProfileId);

            if (!studentProfileExists)
            {
                return BadRequest("The provided StudentProfileId does not exist.");
            }

            // Add the new course record to the database
            _context.CourseRecords.Add(courseRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetCourseRecords),
                new { id = courseRecord.Id },
                courseRecord);
        }

        // PUT: api/CourseRecords/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourseRecord(int id, CourseRecord courseRecord)
        {
            // Validate that the ID in the URL matches the ID in the request body
            if (id != courseRecord.Id)
            {
                return BadRequest();
            }

            bool courseRecordExists = await _context.CourseRecords
                .AnyAsync(existingCourseRecord => existingCourseRecord.Id == id);

            if (!courseRecordExists)
            {
                return NotFound();
            }

            // Validate that the provided StudentProfileId exists in the database
            bool studentProfileExists = await _context.StudentProfiles
                .AnyAsync(studentProfile => studentProfile.Id == courseRecord.StudentProfileId);

            if (!studentProfileExists)
            {
                return BadRequest("The provided StudentProfileId does not exist.");
            }

            // Update the course record in the database
            _context.Entry(courseRecord).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/CourseRecords/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseRecord(int id)
        {
            // Find the course record with the specified ID
            CourseRecord? courseRecord = await _context.CourseRecords
                .FindAsync(id);

            // If the course record with the specified ID does not exist, return a 404 Not Found response
            if (courseRecord == null)
            {
                return NotFound();
            }

            // Remove the course record from the database
            _context.CourseRecords.Remove(courseRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
