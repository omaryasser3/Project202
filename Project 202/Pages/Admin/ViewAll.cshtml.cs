using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using MySql.Data.MySqlClient;

namespace Project_202.Pages.Admin
{
    public class ViewAllModel : PageModel
    {
        public int teamsCount { get; set; }
        public List<TeamData> Teams { get; set; } = new List<TeamData>();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public class TeamData
        {
            public string TeamName { get; set; }
            public decimal Wins { get; set; }
            public decimal Losses { get; set; }
            public decimal Draws { get; set; }
            public decimal GoalsFor { get; set; }
            public decimal GoalsAgainst { get; set; }
            public decimal MatchesPlayed { get; set; }
            public decimal GoalsDifference { get; set; }
            public decimal Points { get; set; }
        }

        public void OnGet()
        {
            string connectionString = "server=localhost;uid=omar;pwd=amormero;database=try";;
            MySqlConnection connection = new MySqlConnection(connectionString);

            string query = "SELECT team_name, wins, losses, draws, matches_played, goals_for, goals_against, goals_difference, points " +
                           "FROM teams_results WHERE team_name LIKE @SearchTerm ORDER BY points DESC";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@SearchTerm", "%" + SearchTerm + "%");

            try
            {
                connection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var teamData = new TeamData
                        {
                            TeamName = reader["team_name"].ToString(),
                            Wins = (decimal)reader["wins"],
                            Losses = (decimal)reader["losses"],
                            Draws = (decimal)reader["draws"],
                            MatchesPlayed = (Int64)reader["matches_played"],
                            GoalsFor = (decimal)reader["goals_for"],
                            GoalsAgainst = (decimal)reader["goals_against"],
                            GoalsDifference = (decimal)reader["goals_difference"],
                            Points = (decimal)reader["points"]
                        };

                        Teams.Add(teamData);
                    }

                    teamsCount = Teams.Count;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
        }
    }
}