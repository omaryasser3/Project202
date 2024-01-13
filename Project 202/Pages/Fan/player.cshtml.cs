using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project_202.Pages.Fan
{
    public class playerModel : PageModel
    {
        [BindProperty] public string name { get; set; }
        public IActionResult OnPost()
        {
            return RedirectToPage("/Fan/ShowPlayer", new { namee = name });
        }
    }
}