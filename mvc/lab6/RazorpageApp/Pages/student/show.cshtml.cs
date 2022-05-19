using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorpageApp.Pages.student
{
    public class showModel : PageModel
    {
        public int X { get; set; }
        public void OnGet(int x)
        {
            X= x;
        }
    }
}
