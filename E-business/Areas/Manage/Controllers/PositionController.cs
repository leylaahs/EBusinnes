using E_business.DAL;
using E_business.Models;
using E_business.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_business.Areas.Manage.Controllers
{
    public class PositionController : Controller
    {
        readonly AppDbContext _context;
        public PositionController(AppDbContext context)
        {
            _context= context;  
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]

        public IActionResult Create(CreatePositionVm positionVm) 
        {
            if(!ModelState.IsValid) { return View(); }
            if (positionVm == null) return NotFound();
            

            Position position = new Position
            {
                Name = positionVm.Name,
            };
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Delete(int Id)
        {
            Position position = _context.Positions.Find(Id);
            if(position == null) return NotFound(); 
            _context.Positions.Remove(position);
            return RedirectToAction(nameof(Index));
        }
    }
}
