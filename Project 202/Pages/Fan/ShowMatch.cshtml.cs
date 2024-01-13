using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace Project_202.Pages.Fan
{
    public class ShowMatchModel : PageModel
    {
        [BindProperty(SupportsGet = true)] public string game_weeek { get; set; }
        [BindProperty(SupportsGet = true)] public string home_teeam { get; set; }
        [BindProperty(SupportsGet = true)] public string away_teeam { get; set; }
        [BindProperty(SupportsGet = true)] public string game_week { get; set; }
        [BindProperty(SupportsGet = true)] public string kickoff { get; set; }
        [BindProperty(SupportsGet = true)] public string home_goals { get; set; }
        [BindProperty(SupportsGet = true)] public string guest_goals { get; set; }
        [BindProperty(SupportsGet = true)] public string stadiumname { get; set; }
        [BindProperty(SupportsGet = true)] public string hometeam { get; set; }
        [BindProperty(SupportsGet = true)] public string awayteam { get; set; }
        [BindProperty(SupportsGet = true)] public List<string> homeplayer { get; set; }
        [BindProperty(SupportsGet = true)] public List<string> awayplayer { get; set; }
        [BindProperty(SupportsGet = true)] public List<string> homeminute { get; set; }
        [BindProperty(SupportsGet = true)] public List<string> awayminute { get; set; }
        [BindProperty(SupportsGet = true)] public string minute { get; set; }
        [BindProperty(SupportsGet = true)] public string playername { get; set; }
        [BindProperty(SupportsGet = true)] public string scoringteam { get; set; }

        public void OnGet()
        {
            string constr = "server=localhost;uid=omar;pwd=amormero;database=try";;
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string info = $"SELECT m.Game_Week, m.Kickoff, m.home_goals, m.guest_goals, m.stadiumname, m.hometeam, m.awayteam, COALESCE(g.minute, 'none'), COALESCE(g.playername, 'none'),COALESCE(p.team , 'none') FROM matches m LEFT JOIN goals g ON m.Game_Week = g.gameWeek AND m.hometeam = g.hometeam AND m.awayteam = g.awayteam left JOIN player p ON g.playername = p.PlayerName where m.hometeam='{home_teeam}' and m.awayteam='{away_teeam}' and m.Game_Week='{game_weeek}';";
            MySqlCommand command = new MySqlCommand(info, con);
            try
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        game_week = (reader[0].ToString());
                        kickoff = (reader[1].ToString());
                        home_goals = (reader[2].ToString());
                        guest_goals = (reader[3].ToString());
                        stadiumname = (reader[4].ToString());
                        hometeam = (reader[5].ToString());
                        awayteam = (reader[6].ToString());
                        minute = (reader[7].ToString());
                        playername = (reader[8].ToString());
                        scoringteam = (reader[9].ToString());
                        if (scoringteam == hometeam)
                        {
                            homeplayer.Add(playername);
                            homeminute.Add(minute);
                        }
                        else
                        {
                            awayplayer.Add(playername);
                            awayminute.Add(minute);
                        }
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
            return RedirectToPage("/Fan/Match");
        }
    }
}
