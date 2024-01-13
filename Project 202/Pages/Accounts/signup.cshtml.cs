using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Project_202.Pages.Accounts
{
    public class signupModel : PageModel { 


        public void OnGet(){}
    public IActionResult OnPostLoginGo()
        {
            return RedirectToPage("/Accounts/Login");
        }

        public IActionResult OnPostFan()
        {
            return RedirectToPage("/Accounts/FanSignUp");
        }
        public IActionResult OnPostAdmin()
        {
            return RedirectToPage("/Accounts/AdminSignUp");
        }
    }
}

