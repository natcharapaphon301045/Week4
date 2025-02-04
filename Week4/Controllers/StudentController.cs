using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week4.Infrastructure;
using Week4.Domain;

namespace Week4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly Week4DbContext _context;
        
        public StudentController(Week4DbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudent()
        {
            var student = await _context.Students
                .Include(s => s.Professor)
                .Include(s => s.Major)
                .ToListAsync();
            
            return Ok(student);
        }
    }
}
