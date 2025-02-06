namespace Recipe_Site.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Ingredients { get; set; } = string.Empty;
        public string Instructions { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        // The ImagePath property will store the relative path of the uploaded image
        public string ImagePath { get; set; } = string.Empty;
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ApplicationUser User { get; set; } = new ApplicationUser();
    }
}
