using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ass2.Data;
using ass2.Models;

namespace ass2.Controllers
{
    [Produces("application/json")]
    [Route("api/ActivityCategories")]
    public class ActivityCategoriesApiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivityCategoriesApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ActivityCategories
        [HttpGet]
        public IEnumerable<ActivityCategory> GetActivityCategories()
        {
            return _context.ActivityCategories;
        }

        // GET: api/ActivityCategories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivityCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var activityCategory = await _context.ActivityCategories.SingleOrDefaultAsync(m => m.ActivityCategoryId == id);

            if (activityCategory == null)
            {
                return NotFound();
            }

            return Ok(activityCategory);
        }

        private bool ActivityCategoryExists(int id)
        {
            return _context.ActivityCategories.Any(e => e.ActivityCategoryId == id);
        }
    }
}