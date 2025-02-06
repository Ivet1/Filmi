using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recipe_Site.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe_Site.Controllers
{
    public class RecipeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var recipes = await _context.Recipes.Include(r => r.User).ToListAsync();
            return View("~/Views/Recipe/Index.cshtml", recipes);
        }

        // Details action 
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .Include(r => r.Comments)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (recipe == null)
            {
                return NotFound();
            }

            // Pass whether the current user is the creator of the recipe to the view
            ViewBag.IsCreator = recipe.CreatedBy == User.Identity.Name;
            return View("~/Views/Recipe/Details.cshtml", recipe);
        }

        // Create action 
        public IActionResult Create()
        {
            return View("~/Views/Recipe/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Ingredients,Instructions")] Recipe recipe, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null && image.Length > 0)
                {
                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    recipe.ImagePath = $"/images/{uniqueFileName}";
                }

                recipe.CreatedBy = User.Identity.Name ?? "Unknown";
                recipe.CreatedAt = DateTime.Now;

                _context.Add(recipe);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(recipe);
        }

        // Edit action 
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            if (recipe.CreatedBy != User.Identity.Name)
            {
                return Forbid();
            }

            return View("~/Views/Recipe/Edit.cshtml", recipe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Ingredients,Instructions")] Recipe recipe, IFormFile image)
        {
            if (id != recipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (image != null && image.Length > 0)
                    {
                        var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", uniqueFileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await image.CopyToAsync(stream);
                        }

                        recipe.ImagePath = $"/images/{uniqueFileName}";
                    }

                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Recipes.Any(e => e.Id == recipe.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Recipe/Edit.cshtml", recipe);
        }

        // Delete action for both authenticated and anonymous users
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            // Allow the creator (anonymous or authenticated) to delete the recipe
            if (recipe.CreatedBy != User.Identity.Name && User.Identity.Name != null)
            {
                return Forbid(); // Only authenticated users can delete if they aren't the creator
            }

            return View("~/Views/Recipe/Delete.cshtml", recipe);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe != null)
            {
                _context.Recipes.Remove(recipe);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> MyRecipes()
        {
            var userName = User.Identity.Name;
            if (userName == null)
            {
                return RedirectToAction("Login", "Account"); // Redirect to login page if not authenticated
            }

            var recipes = await _context.Recipes
                .Where(r => r.CreatedBy == userName)
                .ToListAsync();

            return View("~/Views/Recipe/MyRecipes.cshtml", recipes); // Return a view that displays the user's recipes
        }

        // ListOfRecipes action 
        public async Task<IActionResult> ListOfRecipes()
        {
            var recipes = await _context.Recipes.ToListAsync();
            return View("~/Views/Recipe/ListOfRecipes.cshtml", recipes);
        }
    }
}
