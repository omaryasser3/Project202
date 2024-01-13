using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient;

namespace Project_202.Pages.Accounts
{
    public class FanSignUpModel : PageModel
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
        [MinLength(3, ErrorMessage = "Your Name is too short")]
        public string favoriteTeam { get; set; }

        [BindProperty]
        [MinLength(3, ErrorMessage = "Your Name is too short")]
        public string favoritePlayer { get; set; }

        [BindProperty]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
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

            string fullname = firstname + " " + lastname;
            string constr = "server=localhost;uid=omar;pwd=amormero;database=try";
                MySqlConnection con = new MySqlConnection(constr);
            string count = "select count(*) from Fan";
            Int64 ID;

                try
                {

                con.Open();

                MySqlCommand cmd = new MySqlCommand(count, con);
                ID = 1 + (Int64) cmd.ExecuteScalar();
                string q = $"Insert Into Fan (name,id, Email, password, FavTeam, FavPlayer) values('{fullname}',{ID}, '{email}', '{password}' , '{favoriteTeam}', '{favoritePlayer}')";
                MySqlCommand cmd2 = new MySqlCommand(q, con);
                cmd2.ExecuteReader();
                    con.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally { con.Close(); }

                return RedirectToPage("/Index");
            
        }
            else { return Page(); }
        }
    }
}
