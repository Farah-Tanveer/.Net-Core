using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace RoleBasedAuth.Controllers
{
    [Authorize(Roles = "Admin")] // only Admin can access anything in this controller
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AdminController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            try
            {
                var users = _userManager.Users.ToList();
                return View(users);
            }
            catch
            {
                ViewBag.Error = "Database connection timeout. Please refresh.";
                return View(new List<IdentityUser>());
            }
        }

        public IActionResult AddUser()
        {
            return View();
        }

      
        [HttpPost]
        public async Task<IActionResult> AddUser(string email, string password, string role)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Email and password are required";
                return View();
            }

            var user = new IdentityUser { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, role ?? "User");
                return RedirectToAction("Index");
            }

            ViewBag.Error = string.Join(", ", result.Errors.Select(e => e.Description));
            return View();
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
                await _userManager.DeleteAsync(user);
            return RedirectToAction("Index");
        }
    }
}
