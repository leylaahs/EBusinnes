using E_business.DAL;
using E_business.Models;
using E_business.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_business.Controllers
{
    public class AccountController : Controller
    {
        readonly AppDbContext _context;
        UserManager<Appuser> _userManager;
        SignInManager<Appuser> _signInManager;
        public AccountController(AppDbContext context, UserManager<Appuser> userManager, SignInManager<Appuser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }



        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(CreateRegisterVm registerVm)
        {
            if (!ModelState.IsValid) return View();

            Appuser user = await _userManager.FindByNameAsync(registerVm.Username);
            if (user == null)
            {
                ModelState.AddModelError("UserName", "Bu istifadeci artiq movcuddur");
                return View();

            }
            user = new Appuser
            {
                FirstName = registerVm.FirstName,
                LastName = registerVm.LastName,
                UserName = registerVm.Username,
                Email = registerVm.Password
            };
            IdentityResult result = await _userManager.CreateAsync(user, registerVm.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            await _signInManager.SignInAsync(user, true);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Login()
        {
            return View();
        }

    }
}
