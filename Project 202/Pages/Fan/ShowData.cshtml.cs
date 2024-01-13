using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace Project_202.Pages.Fan
{
    public class ShowDataModel : PageModel
    {
        [BindProperty(SupportsGet = true)] public string game_week { get; set; }

        [BindProperty(SupportsGet = true)] public string hometeam { get; set; }
        [BindProperty(SupportsGet = true)] public string awayteam { get; set; }

        [BindProperty(SupportsGet = true)] public string Goals { get; set; }
        [BindProperty(SupportsGet = true)] public string team { get; set; }
        [BindProperty(SupportsGet = true)] public string sum_goals { get; set; }
        [BindProperty(SupportsGet = true)] public string PlayerName { get; set; }
        [BindProperty(SupportsGet = true)] public string GoalCount { get; set; }
        [BindProperty(SupportsGet = true)] public string TeamName { get; set; }
        [BindProperty(SupportsGet = true)] public string TeamN { get; set; }
        [BindProperty(SupportsGet = true)] public string CleanSheet { get; set; }


        public void OnGet()
        {
            string constr = "server=localhost;uid=omar;pwd=amormero;database=try";;
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            string info = "select Game_Week,hometeam,awayteam,(matches.home_goals+matches.guest_goals) as goals from matches order by goals desc limit 1;";
            MySqlCommand command = new MySqlCommand(info, con);
            try
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        game_week = (reader[0].ToString());
                        hometeam = (reader[1].ToString());
                        awayteam = (reader[2].ToString());
                        Goals = (reader[3].ToString());


                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally { con.Close(); }


            con.Open();
            string info2 = "SELECT team, SUM(goals) AS total_goals FROM (SELECT hometeam AS team, SUM(home_goals) AS goals FROM matches   GROUP BY hometeam UNION ALL  SELECT awayteam AS team, SUM(guest_goals) AS goals  FROM matches  GROUP BY awayteam) AS combined_goals GROUP BY team order by total_goals desc limit 1;";
            MySqlCommand command2 = new MySqlCommand(info2, con);
            try
            {
                using (MySqlDataReader reader2 = command2.ExecuteReader())
                {
                    while (reader2.Read())
                    {
                        team = (reader2[0].ToString());
                         sum_goals = (reader2[1].ToString());
                         


                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally { con.Close(); }
        


        con.Open();
            string info3 = "SELECT g.playername,count(*),team FROM goals as g join player p on g.playername =p.PlayerName GROUP BY playername ORDER BY COUNT(*)  DESC LIMIT 1;";
        MySqlCommand command3 = new MySqlCommand(info3, con);
            try
            {
                using (MySqlDataReader reader3 = command3.ExecuteReader())
                {
                    while (reader3.Read())
                    {
                        PlayerName = (reader3[0].ToString());
                        GoalCount = (reader3[1].ToString());
                         TeamName = (reader3[2].ToString());
                    }
}

            }
            catch (Exception ex)
            {
    Console.WriteLine(ex.ToString());
}
            finally { con.Close(); }
        

        con.Open();
            string info4 = "SELECT team, SUM(clean_sheet) AS clean_shhe FROM ( SELECT hometeam AS team,count(*) AS clean_sheet FROM matches where guest_goals=0 group by hometeam UNION ALL SELECT awayteam AS team,count(*) AS clean_sheet FROM matches where home_goals=0 GROUP BY awayteam ) AS clean_sheets group by team order by clean_shhe desc limit 1;";
        MySqlCommand command4 = new MySqlCommand(info4, con);
            try
            {
                using (MySqlDataReader reader4 = command4.ExecuteReader())
                {
                    while (reader4.Read())
                    {
                        TeamN = (reader4[0].ToString());
                        CleanSheet = (reader4[1].ToString());
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