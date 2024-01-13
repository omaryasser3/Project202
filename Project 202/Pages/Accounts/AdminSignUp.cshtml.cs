using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient;

namespace Project_202.Pages.Accounts
{
    public class AdminSignUpModel : PageModel
    {

        [BindProperty]
        [MinLength(3, ErrorMessage = "Your Name is too short")]
        [MaxLength(15, ErrorMessage = "Too long make it below 15")]
        public string firstname { get; set; }

        [BindProperty]
        [MinLength(3, ErrorMessage = "Your Name is too short")]
        [MaxLength(15, ErrorMessage = "Too long make it below 15")]
        public string lastname { get; set; }

        [BindProperty]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@zewailcity\.edu\.eg$", ErrorMessage = "Email should belong to zewailcity")]
        public string email { get; set; }

        [BindProperty]
        public string password { get; set; }

        [BindProperty]
        [Compare(nameof(password), ErrorMessage = "Password is not the same as the original")]
        public string confirmPassword { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPostLogin()
        {
            if (ModelState.IsValid)
            {
                string constr = "server=localhost;uid=omar;pwd=amormero;database=try";
                MySqlConnection con = new MySqlConnection(constr);
                string q = $"Insert Into Admin values('{firstname}', '{lastname}', '{email}', '{password}')";


                try
                {

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(q, con);
                    cmd.ExecuteReader();
                    con.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally { con.Close(); }

                return RedirectToPage("/Accounts/Login");
            }
            else { return Page(); }
        }


        public IActionResult OnPostLoginGo()
        {
            return RedirectToPage("/Accounts/Login");
        }
    }
}
