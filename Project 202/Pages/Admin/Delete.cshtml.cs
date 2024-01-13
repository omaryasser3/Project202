using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace Project_202.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public string Gameweek { get; set; }
        [BindProperty]
        public string MatchHomeTeam { get; set; }
        [BindProperty]
        public string MatchAwayTeam { get; set; }
        [BindProperty]
        public string Minute { get; set; }
        [BindProperty]
        public string GoalHomeTeam { get; set; }
        [BindProperty]
        public string GoalAwayTeam { get; set; }
        public void OnGet()
        {

        }

        public void OnPostMatch()
        {
            string constr = "server=localhost;uid=omar;pwd=amormero;database=try";;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = constr;

            con.Open();
            string query = "DELETE FROM matches WHERE Game_Week = @Gameweek AND hometeam = @MatchHomeTeam AND awayteam = @MatchAwayTeam";
            MySqlCommand com = new MySqlCommand(query, con);
            com.Parameters.AddWithValue("@Gameweek", Gameweek);
            com.Parameters.AddWithValue("@MatchHomeTeam", MatchHomeTeam);
            com.Parameters.AddWithValue("@MatchAwayTeam", MatchAwayTeam);
            try
            {
                com.ExecuteNonQuery();
                Console.WriteLine("Match deleted successfully");
            }
            catch (SqlException ex)
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
            string query = "DELETE FROM goals WHERE minute = @Minute AND hometeam = @GoalHomeTeam AND awayteam = @GoalAwayTeam";
            MySqlCommand com = new MySqlCommand(query, con);
            com.Parameters.AddWithValue("@Minute", Minute);
            com.Parameters.AddWithValue("@GoalHomeTeam", GoalHomeTeam);
            com.Parameters.AddWithValue("@GoalAwayTeam", GoalAwayTeam);
            try
            {
                com.ExecuteNonQuery();
                Console.WriteLine("Goal deleted successfully");
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
        public IActionResult OnPostReturn() {
            return RedirectToPage("/Admin/Admin");
        }
    }
}
