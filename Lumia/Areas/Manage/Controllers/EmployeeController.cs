using Lumia.DAL;
using Lumia.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lumia.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class EmployeeController : Controller
    {
        public readonly AppDbContext _context;
        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var employee = _context.Employees.ToList();
            return View(employee);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if(employee == null) return NotFound();
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            Employee employee = _context.Employees.Find(id);
            if(employee == null) return NotFound();
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0) return BadRequest();
            Employee employee = _context.Employees.Find(id);
            if (employee is null) return NotFound();
            return View(employee);
        }
        [HttpPost]
        public IActionResult Update(Employee employee,int? id)
        {
            if (id == null || id == 0 || id != employee.Id || employee is null) return BadRequest();
            if (!ModelState.IsValid) return View();
            Employee anotheremployee = _context.Employees.FirstOrDefault(s => s.PositionId == employee.PositionId);
            if (anotheremployee != null)
            {
                anotheremployee.PositionId = _context.Employees.Find(id).PositionId;
            }
            Employee exist = _context.Employees.Find(id);
            exist.Name = employee.Name;
            exist.Surname = employee.Surname;
            exist.ImageUrl = employee.ImageUrl;
            exist.InstagramUrl = employee.InstagramUrl;
            exist.FacebookUrl = employee.FacebookUrl;
            exist.TwitterUrl = employee.TwitterUrl;
            //_context.Employees.Update(employee);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
