using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Recipe_Site.Models;
using System.Diagnostics;

namespace Recipe_Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Landing Page
        public IActionResult Index()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                // Redirect to Recipes page if the user is already logged in
                return RedirectToAction("Recipes");
            }

            return View(); // Show the landing page
        }

        // Recipes Page
        [HttpGet]
        public IActionResult Recipes()
        {
            if (User.Identity == null || !User.Identity.IsAuthenticated)
            {
                // Redirect unauthenticated users to the login page
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        // Error Page
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            _logger.LogError("An error occurred with Request ID: {RequestId}", requestId); // Log error
            return View(new ErrorViewModel { RequestId = requestId });
        }
    }
}
