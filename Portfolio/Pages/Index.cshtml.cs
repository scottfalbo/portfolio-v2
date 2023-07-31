using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Portfolio.Pages
{
    public class IndexModel : PageModel
    {
        public string ImageUrl { get; set; }

        public void OnGet()
        {
            ImageUrl = "https://placehold.co/500x700";
        }
    }
}