using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace Project_202.Pages.Admin
{
    public class AwardsModel : PageModel
    {
        [BindProperty]
        public string TeamAwardName { get; set; }
        [BindProperty]
        public string TeamName { get; set; }
        [BindProperty]
        public string PlayerAwardName { get; set; }
        [BindProperty]
        public string CoachAwardName { get; set; }
        [BindProperty]
        public string PlayerName { get; set; }
        [BindProperty]
        public string CoachName { get; set; }
        public void OnGet()
        {

        }

        public void OnPostTeamAward()
        {
            string constr = "server=localhost;uid=omar;pwd=amormero;database=try";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = constr;

            con.Open();
            string query = "update teamawards set tname = @TeamName where TAname = @TeamAwardName";
            MySqlCommand com = new MySqlCommand(query, con);
            com.Parameters.AddWithValue("@TeamName", TeamName);
            com.Parameters.AddWithValue("@TeamAwardName", TeamAwardName);
            try
            {
                com.ExecuteNonQuery();
                Console.WriteLine("team award data updated successfully");
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

        public void OnPostPlayerAward()
        {
            string constr = "server=localhost;uid=omar;pwd=amormero;database=try";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = constr;


            string query = "update PlayerAwards set pname = @PlayerName where PAName = @PlayerAwardName";

            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand(query, con);
                com.Parameters.AddWithValue("@PlayerName", PlayerName);
                com.Parameters.AddWithValue("@PlayerAwardName", PlayerAwardName);
                com.ExecuteNonQuery();
                Console.WriteLine("PLayer award data updated successfully");
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

        public void OnPostCoachAward()
        {
            string constr = "server=localhost;uid=omar;pwd=amormero;database=try";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = constr;

            string query = "update CoachAwards set cname = @CoachName where CAName = @CoachAwardName";

            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand(query, con);
                com.Parameters.AddWithValue("@CoachName", CoachName);
                com.Parameters.AddWithValue("@CoachAwardName", CoachAwardName);
                com.ExecuteNonQuery();
                Console.WriteLine("Coach award data updated successfully");
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
