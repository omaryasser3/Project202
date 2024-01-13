using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient;
using System.Xml.Linq;

namespace Project_202.Pages.Accounts
{
    public class LoginModel : PageModel
    {

        [BindProperty]

        public string email { get; set; }

        [BindProperty]
        public string password { get; set; }
        public void OnGet()
        {
        }


        public IActionResult OnPostLogin()
        {
            if(email == null) { return Page(); }

            if (email.EndsWith("@zewailcity.edu.eg"))
            {
                string constr = "server=localhost;uid=omar;pwd=amormero;database=try";
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                string info = $"Select * from Admin where Email = '{email}' And Password = '{password}'";
                MySqlCommand command = new MySqlCommand(info, con);
                try
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return RedirectToPage("/Admin/Admin", new { Email = email });
                        }
                        else { return RedirectToPage("/Accounts/Login"); }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally { con.Close(); }
            }
            else if(email != null){
                string constr = "server=localhost;uid=omar;pwd=amormero;database=try";
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                string info = $"select * from fan where Email='{email}' And Password = '{password}'";
                MySqlCommand command = new MySqlCommand(info, con);
                try
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return RedirectToPage("/Fan/Index");
                        }
                        else { return RedirectToPage("/Accounts/Login"); }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally { con.Close(); }


            }
           

            return RedirectToPage();

        } 



        public IActionResult OnPostSignup()
        {
            return RedirectToPage("/Accounts/signup");
        }
    }
}
