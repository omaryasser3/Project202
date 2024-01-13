using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace Project_202.Pages.Admin
{
    public class AdminModel : PageModel
    {
        [BindProperty(SupportsGet = true)] public string Email { get; set; }
        [BindProperty] public string name { get; set; }
        
        public void OnGet()
        {
             string constr = "server=localhost;uid=omar;pwd=amormero;database=try";
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                string info = $"Select FName, LName from Admin where Email = '{Email}'";
                MySqlCommand command = new MySqlCommand(info, con);
                try
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                    while (reader.Read())
                    {
                        name = reader[0].ToString() + ' ' +reader[1].ToString();
                    }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally { con.Close(); }
            }
    }
}
