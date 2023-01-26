using Lumia.DAL;
using Lumia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lumia.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class PositionController : Controller
    {
        public readonly AppDbContext _context;
        public PositionController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Positions);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Position position)
        {
            if (position == null) return BadRequest();
            if (!ModelState.IsValid) return View();
            Position position1 = new Position
            {
                Name = position.Name,
            };
            await _context.Positions.AddAsync(position1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var post = await _context.Positions.FirstOrDefaultAsync(p => p.Id == id);
            if (post == null) return NotFound();
            _context.Positions.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();
            var positon = await _context.Positions.FirstOrDefaultAsync(p => p.Id == id);
            return View(positon);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, Position position)
        {
            if (id == null) return BadRequest();
            var post = await _context.Positions.FirstOrDefaultAsync(p => p.Id == id);
            if (post == null) return NotFound();
            if (!ModelState.IsValid) return View();
            post.Name = position.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
