using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace Project_202.Pages.Admin
{
    public class UpdateModel : PageModel
    {
        [BindProperty] public string PlayerNamee { get; set; }
        [BindProperty] public string PlayerAge { get; set; }
        [BindProperty] public string PlayerPosition { get; set; }
        [BindProperty] public string PlayerNationality { get; set; }
        [BindProperty] public string PlayerTeam { get; set; }

        [BindProperty]
        public string sponsor { get; set; }
        [BindProperty]
        public string gameweek { get; set; }
        [BindProperty]
        public string HomeGoals { get; set; }
        [BindProperty]
        public string AwayGoals { get; set; }
        [BindProperty]
        public string stadium { get; set; }
        [BindProperty]
        public string HomeTeam { get; set; }
        [BindProperty]
        public string AwayTeam { get; set; }
        [BindProperty]
        public string referee { get; set; }
        [BindProperty]
        public string commentator { get; set; }
        [BindProperty]
        public string minute { get; set; }
        [BindProperty]
        public string GoalPlayerName { get; set; }
        [BindProperty]
        public string GoalGameweek { get; set; }
        [BindProperty]
        public string GoalHomeTeam { get; set; }
        [BindProperty]
        public string GoalAwayTeam { get; set; }
        [BindProperty]
        public string newminute { get; set; }

        public void OnGet()
        {

        }


        public void OnPostPlayer()
        {
            string constr = "server=localhost;uid=omar;pwd=amormero;database=try";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = constr;
            con.Open();
            string query = "update player set  age = @PlayerAge, position = @PlayerPosition, nationality = @PlayerNationality, team = @PlayerTeam where PlayerName = @PlayerNamee";

            MySqlCommand com = new MySqlCommand(query, con);
            com.Parameters.AddWithValue("@PlayerAge", PlayerAge);
            com.Parameters.AddWithValue("@PlayerPosition", PlayerPosition);
            com.Parameters.AddWithValue("@PlayerNationality", PlayerNationality);
            com.Parameters.AddWithValue("@PlayerTeam", PlayerTeam);
            com.Parameters.AddWithValue("@PlayerNamee", PlayerNamee);

            try
            {
                com.ExecuteNonQuery();
                Console.WriteLine("Player updated successfully");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public void OnPostMatch()
        {
            string constr = "server=localhost;uid=omar;pwd=amormero;database=try";;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = constr;
            con.Open();
            string query = "update matches set Sponsor = @sponsor, home_goals = @HomeGoals, guest_goals = @AwayGoals, ref = @referee, com = @commentator" +
                           ", stadiumname = @stadium where Game_Week = @gameweek AND hometeam = @HomeTeam AND awayteam = @AwayTeam";

            MySqlCommand com = new MySqlCommand(query, con);
            com.Parameters.AddWithValue("@sponsor", sponsor);
            com.Parameters.AddWithValue("@HomeGoals", HomeGoals);
            com.Parameters.AddWithValue("@AwayGoals", AwayGoals);
            com.Parameters.AddWithValue("@referee", referee);
            com.Parameters.AddWithValue("@commentator", commentator);
            com.Parameters.AddWithValue("@stadium", stadium);
            com.Parameters.AddWithValue("@gameweek", gameweek);
            com.Parameters.AddWithValue("@HomeTeam", HomeTeam);
            com.Parameters.AddWithValue("@AwayTeam", AwayTeam);

            try
            {
                com.ExecuteNonQuery();
                Console.WriteLine("Match updated successfully");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public void OnPostGoal()
        {
            string constr = "server=localhost;uid=omar;pwd=amormero;database=try";;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = constr;
            con.Open();
            string query = "update goals set minute = @newminute, gameWeek = @GoalGameweek, playername = @GoalPlayerName " +
                           "where minute = @minute AND hometeam = @GoalHomeTeam AND awayteam = @GoalAwayTeam";

            MySqlCommand com = new MySqlCommand(query, con);
            com.Parameters.AddWithValue("@newminute", newminute);
            com.Parameters.AddWithValue("@GoalGameweek", GoalGameweek);
            com.Parameters.AddWithValue("@GoalPlayerName", GoalPlayerName);
            com.Parameters.AddWithValue("@minute", minute);
            com.Parameters.AddWithValue("@GoalHomeTeam", GoalHomeTeam);
            com.Parameters.AddWithValue("@GoalAwayTeam", GoalAwayTeam);

            try
            {
                com.ExecuteNonQuery();
                Console.WriteLine("Goal updated successfully");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }
        public IActionResult OnPostReturn()
        {
            return RedirectToPage("/Admin/Admin");
        }

    }
}
