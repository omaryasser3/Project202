using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace Project_202.Pages.Admin
{
    public class InsertModel : PageModel
    {
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
        public string PlayerName { get; set; }
        [BindProperty]
        public string GoalGameweek { get; set; }
        [BindProperty]
        public string GoalHomeTeam { get; set; }
        [BindProperty]
        public string GoalAwayTeam { get; set; }
        [BindProperty]
        public String KickOff{get; set;}
        public void OnGet()
        {

        }

        public void OnPostMatch()
        {
            string constr = "server=localhost;uid=omar;pwd=amormero;database=try";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = constr;
            con.Open();

            string query = "INSERT INTO matches VALUES( @gameweek,@Kickoff,@HomeGoals, @AwayGoals, @stadium, @HomeTeam, @AwayTeam, @referee, @commentator,@sponsor)";
            MySqlCommand com = new MySqlCommand(query, con);
            com.Parameters.AddWithValue("@sponsor", sponsor);
            com.Parameters.AddWithValue("@Kickoff", KickOff);
            com.Parameters.AddWithValue("@gameweek", gameweek);
            com.Parameters.AddWithValue("@HomeGoals", HomeGoals);
            com.Parameters.AddWithValue("@AwayGoals", AwayGoals);
            com.Parameters.AddWithValue("@stadium", stadium);
            com.Parameters.AddWithValue("@HomeTeam", HomeTeam);
            com.Parameters.AddWithValue("@AwayTeam", AwayTeam);
            com.Parameters.AddWithValue("@referee", referee);
            com.Parameters.AddWithValue("@commentator", commentator);
            try
            {
                com.ExecuteNonQuery();
                Console.WriteLine("Match added successfully.");
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

            string query = "insert into goals values(@minute, @GoalGameweek, @PlayerName, @GoalHomeTeam, @GoalAwayTeam)";

            MySqlCommand com = new MySqlCommand(query, con);
            com.Parameters.AddWithValue("@minute", minute);
            com.Parameters.AddWithValue("@GoalGameweek", GoalGameweek);
            com.Parameters.AddWithValue("@PlayerName", PlayerName);
            com.Parameters.AddWithValue("@GoalHomeTeam", GoalHomeTeam);
            com.Parameters.AddWithValue("@GoalAwayTeam", GoalAwayTeam);
            try
            {
                com.ExecuteNonQuery();
                Console.WriteLine("Goal added successfully.");
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
