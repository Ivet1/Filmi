using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Recipe_Site.Models;

namespace Recipe_Site.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Account/Register
        public IActionResult Register() => View();

        // POST: Account/Register
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName,
                ProfilePicture = "/images/default-profile-picture.jpg"
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Recipe");  // Redirect to Recipe Index after registration
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        // GET: Account/Login
        public IActionResult Login() => View();

        // POST: Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel LoginViewmodel, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(LoginViewmodel);
            }

            // Ensure Email is provided
            if (string.IsNullOrEmpty(LoginViewmodel.Email))
            {
                ModelState.AddModelError(string.Empty, "Email is required.");
                return View(LoginViewmodel);
            }

            var user = await _userManager.FindByEmailAsync(LoginViewmodel.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, LoginViewmodel.Password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    // Ensure returnUrl is not null
                    returnUrl = returnUrl ?? Url.Action("Index", "Recipe");
                    return Redirect(returnUrl);
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(LoginViewmodel);
        }

        // GET: Account/Logout
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();  // Signs out the user
            return RedirectToAction("Index", "Home");  // Redirect to Home page after logout
        }
    }
}
