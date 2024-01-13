using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace Project_202.Pages.Fan
{
    public class ShowPlayerModel : PageModel
    {
        [BindProperty(SupportsGet = true)] public string namee { get; set; }
        [BindProperty(SupportsGet = true)] public string name { get; set; }
        [BindProperty(SupportsGet = true)] public string nationality { get; set; }
        [BindProperty(SupportsGet = true)] public string teamname { get; set; }
        [BindProperty(SupportsGet = true)] public string pos { get; set; }
        [BindProperty(SupportsGet = true)] public string age { get; set; }
        [BindProperty(SupportsGet = true)] public string goal { get; set; }
        [BindProperty(SupportsGet = true)] public string following { get; set; }

        public void OnGet()
        {
            string constr = "server=localhost;uid=omar;pwd=amormero;database=try";;
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string info = $"SELECT p.*, COALESCE(COUNT(g.playername), 0) AS goals FROM player p Left JOIN goals g ON p.PlayerName = g.playername WHERE p.PlayerName = '{namee}' GROUP BY p.PlayerName;";
            string info2 = $"select count(*) from fan where FavPlayer='{namee}'";
            MySqlCommand command2 = new MySqlCommand(info2, con);
            MySqlCommand command = new MySqlCommand(info, con);
            try
            {
                using (MySqlDataReader reader2 = command2.ExecuteReader())
                {
                    while (reader2.Read())
                    {
                        following = (reader2[0].ToString());
                    }
                }

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        name = (reader[0].ToString());
                        teamname = (reader[1].ToString());
                        pos = (reader[2].ToString());
                        age = (reader[3].ToString());
                        nationality = (reader[4].ToString());
                        goal = (reader[5].ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally { con.Close(); }
        }

        public IActionResult OnPostReturn()
        {
            return RedirectToPage("/Fan/player");
        }
    }
}