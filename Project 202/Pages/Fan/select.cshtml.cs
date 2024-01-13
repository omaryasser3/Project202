using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project_202.Pages.Fan
{
    public class selectModel : PageModel
    {
        [BindProperty] public string team { get; set; }
        public IActionResult OnPost()
        {
            return RedirectToPage("/Fan/AfterSelect", new { teamm = team });
        }
    }
}