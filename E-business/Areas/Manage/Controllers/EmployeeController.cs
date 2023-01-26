using E_business.DAL;
using E_business.Models;
using E_business.Utilities;
using E_business.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_business.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class EmployeeController : Controller
    {
        readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public EmployeeController(IWebHostEnvironment env, AppDbContext context)
        {
            _env = env;
            _context = context;
        }
        public IActionResult Index()
        {
           
            return View(_context.Employees.ToList());
        }
        public IActionResult Create()
        {
            ViewBag.Positions = _context.Positions.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateEmployeeVm employeeVm)
        {
            if(!ModelState.IsValid) {
                ViewBag.Positions = _context.Positions.ToList();
                return View(); 
            }
            if(employeeVm == null) NotFound();
            if (!employeeVm.Image.CheckType("image/"))
            {
                ModelState.AddModelError("Image","Type duzgun deyil");
                ViewBag.Positions = _context.Positions.ToList();
                return View();
            }
            if (!employeeVm.Image.CheckSize(300))
            {
                ModelState.AddModelError("Image", "olcu duzgun deyil");
                ViewBag.Positions = _context.Positions.ToList();
                return View();
            }

           
            Employee employee = new Employee
            {
                Name = employeeVm.Name,
                Surname = employeeVm.Surname,
                Salary = employeeVm.Salary,
                FacebookLink = employeeVm.FacebookLink,
               InstagramLink= employeeVm.InstagramLink,
               TwitterLink= employeeVm.InstagramLink,
               PositionId= employeeVm.PositionId,   
                ImageUrl = employeeVm.Image.SaveFile(Path.Combine(_env.WebRootPath, "assets", "img"))
            };

            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
           
        }
        public IActionResult Delete(int Id)
        {
            Employee employee = _context.Employees.Find(Id);
            if (employee == null) return NotFound();
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? Id, CreateEmployeeVm employeeVm)
        {
            if (!ModelState.IsValid) { return View(); }
            if(Id is null) return BadRequest();
            Employee employee=_context.Employees.Find(Id);
            if (employee == null) return NotFound();
  
               
            return RedirectToAction(nameof(Index)); 


        }
      
    }
}
