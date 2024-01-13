using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;


namespace Project_202.Pages.Fan
{
    public class AfterSelectModel : PageModel
    {
       
            [BindProperty(SupportsGet = true)] public string teamm { get; set; }
            [BindProperty(SupportsGet = true)] public Int64 usercount { get; set; }
            [BindProperty(SupportsGet = true)] public List<string> name { get; set; }
            [BindProperty(SupportsGet = true)] public List<string> nationality { get; set; }
            [BindProperty(SupportsGet = true)] public List<string> teamname { get; set; }
            [BindProperty(SupportsGet = true)] public List<string> age { get; set; }
            [BindProperty(SupportsGet = true)] public List<string> pos { get; set; }

            public void OnGet()
            {
                string constr = "server=localhost;uid=omar;pwd=amormero;database=try";;
            MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                string info = $"select * from player where team='{teamm}'";
                string querystring = $"select count(*) from player where team='{teamm}'";
                MySqlCommand countcommand = new MySqlCommand(querystring, con);
                MySqlCommand command = new MySqlCommand(info, con);
                usercount = (Int64)countcommand.ExecuteScalar();
                try
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            name.Add(reader[0].ToString());
                            teamname.Add(reader[1].ToString());
                            pos.Add(reader[2].ToString());
                            age.Add(reader[3].ToString());
                            nationality.Add(reader[4].ToString());

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


