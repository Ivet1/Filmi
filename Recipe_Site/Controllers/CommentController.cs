using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recipe_Site.Models;
using System;
using System.Threading.Tasks;

namespace Recipe_Site.Controllers
{
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: Comment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentText, RecipeId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                // Set the comment's properties
                comment.CreatedBy = User.Identity.Name ?? "Anonymous";
                comment.CreatedAt = DateTime.Now;

                // Add the comment to the database
                _context.Add(comment);
                await _context.SaveChangesAsync();

                // Redirect to the Recipe's details page after adding the comment
                return RedirectToAction("Details", "Recipe", new { id = comment.RecipeId });
            }

            // Redirect back to the recipe details page if model state is not valid
            return RedirectToAction("Details", "Recipe", new { id = comment.RecipeId });
        }

        // POST: Comment/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            // Prevent deletion of comments made by other users
            if (comment.CreatedBy != User.Identity.Name)
            {
                return Forbid();
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Recipe", new { id = comment.RecipeId });
        }
    }
}
