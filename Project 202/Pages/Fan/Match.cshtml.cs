using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project_202.Pages.Fan
{
    public class MatchModel : PageModel
    {
        [BindProperty] public string game_week { get; set; }
        [BindProperty] public string home_team { get; set; }
        [BindProperty] public string away_team { get; set; }

        public IActionResult OnPost()
        {
            return RedirectToPage("/Fan/ShowMatch", new { game_weeek = game_week, home_teeam = home_team, away_teeam = away_team });
        }
    }
}

