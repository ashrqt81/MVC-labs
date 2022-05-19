using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorpageApp.Pages
{
    public class DisplayModel : PageModel
    {
        public int x;
        public void OnGet()
        {
            x = 55;
        }
        public void OnPost()
        {
            x = 88;
        }
    }
}