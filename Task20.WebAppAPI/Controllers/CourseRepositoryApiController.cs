using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task20.DataContext.DataBaseContext;
using Task20.Models;
using Task20.Entities;

namespace Task20.WebAppAPI.Controllers
{
    public class CourseRepositoryApiController : MyControllerBase
    {
        private readonly UniversityDbContext _context;

        public CourseRepositoryApiController(UniversityDbContext context)
        {
            _context = context;
        }

        // GET /CourseRepositoryApi
        [HttpGet]
        public async Task<ActionResult<CourseEntity[]>> GetAllCoursesAsync()
        {
            var courses = await _context.Courses.ToArrayAsync();
            if (courses is null)
            {
                return NotFound();
            }

            return Ok(courses);
        }
    }
}
