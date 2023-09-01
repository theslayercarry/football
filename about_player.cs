using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace football
{
    public partial class about_player : Form
    {
        Database db = new Database();
        string myConnectionString = "Database=football;Data Source=127.0.0.1;User Id=root;Password=1337";

        String help, name, team, country, position, birthday, age_string, postscript, all_matches, matches_replace, goals, penalty_goals, passes, goals_passes;
        double age_double;
        DateTime date;
        public about_player()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void about_player_Load(object sender, EventArgs e)
        {
            MySqlConnection name_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_name = new MySqlCommand("select concat(name,\" \", lastname) from players where idplayers = @id_player;", name_connection);
            command_name.Parameters.Add("@id_player", MySqlDbType.VarChar).Value = main.id_player;
            name_connection.Open();

            name = command_name.ExecuteScalar().ToString();
            label_name.Text = name;
            name_connection.Close();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection team_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_team = new MySqlCommand("select teams.title from players_to_teams\r\njoin teams on players_to_teams.id_team = teams.idteams where id_player = @id_player", team_connection);
            command_team.Parameters.Add("@id_player", MySqlDbType.VarChar).Value = main.id_player;
            team_connection.Open();

            team = command_team.ExecuteScalar().ToString();
            label_team.Text = team;
            team_connection.Close();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection position_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_position = new MySqlCommand("select positions.title from players\r\njoin positions on players.id_position = positions.idpositions\r\nwhere idplayers = @id_player;", position_connection);
            command_position.Parameters.Add("@id_player", MySqlDbType.VarChar).Value = main.id_player;
            position_connection.Open();

            position = command_position.ExecuteScalar().ToString();
            if(position == "Вратарь")
            {
                label8.Text = "Голы(пропущено)";
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
            }
            label_position.Text = position;
            position_connection.Close();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection country_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_country = new MySqlCommand("select countries.name from players\r\njoin countries on players.id_country_nationality = countries.idcountries\r\nwhere idplayers = @id_player;", country_connection);
            command_country.Parameters.Add("@id_player", MySqlDbType.VarChar).Value = main.id_player;
            country_connection.Open();

            country = command_country.ExecuteScalar().ToString();
            label_country.Text = country;
            country_connection.Close();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection birthday_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_birthday = new MySqlCommand("select date_of_birth from players\r\nwhere idplayers = @id_player;", birthday_connection);
            command_birthday.Parameters.Add("@id_player", MySqlDbType.VarChar).Value = main.id_player;
            birthday_connection.Open();

            birthday = command_birthday.ExecuteScalar().ToString();

            date = DateTime.Parse(birthday);
            date.GetDateTimeFormats('u');
            birthday = date.ToString("yyyy-MM-dd");
            label_birthday.Text = birthday;


            age_double = Math.Abs(Math.Round((date - DateTime.Now).TotalDays / 365.25));

            age_string = age_double.ToString();

            if (age_string[1] == '2' || age_string[1] == '3' || age_string[1] == '4')
            {
                postscript = "года";
            }
            else
                postscript = "лет";

            label_years.Text = age_string + " " + postscript;

            birthday_connection.Close();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            pictureBox_bruno_fern.Visible = false;
            pictureBox_harry_kane.Visible = false;
            pictureBox_julian_alv.Visible = false;
            pictureBox_mbappe.Visible = false;
            pictureBox_messi.Visible = false;
            pictureBox_default.Visible = false;

            if (main.id_player == 54)
            {
                pictureBox_messi.Visible = true;
            }
            else if (main.id_player == 106)
            {
                pictureBox_mbappe.Visible = true;
            }
            else if (main.id_player == 20)
            {
                pictureBox_bruno_fern.Visible = true;
            }
            else if (main.id_player == 156)
            {
                pictureBox_harry_kane.Visible = true;
            }
            else if (main.id_player == 47)
            {
                pictureBox_julian_alv.Visible = true;
            }
            else
            {
                pictureBox_default.Visible = true;
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection all_matches_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_all_matches = new MySqlCommand("select total_matches from players \r\nwhere idplayers = @id_player;", all_matches_connection);
            command_all_matches.Parameters.Add("@id_player", MySqlDbType.VarChar).Value = main.id_player;
            all_matches_connection.Open();

            all_matches = command_all_matches.ExecuteScalar().ToString();
            label_all_matches.Text = all_matches;
            all_matches_connection.Close();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection matches_replace_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_matches_replace_ = new MySqlCommand("select count(*) from replaces\r\nwhere id_old_player = @id_player;", matches_replace_connection);
            command_matches_replace_.Parameters.Add("@id_player", MySqlDbType.VarChar).Value = main.id_player;
            matches_replace_connection.Open();

            matches_replace = command_matches_replace_.ExecuteScalar().ToString();
            if (matches_replace == "0")
            {
                label_matches_replaces.Text = "";
            }
            else
            {
                label_matches_replaces.Text = matches_replace;
            }
            matches_replace_connection.Close();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection goals_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_goals = new MySqlCommand("select `total_goals(scored/missed)` from players \r\nwhere idplayers = @id_player;", goals_connection);
            command_goals.Parameters.Add("@id_player", MySqlDbType.VarChar).Value = main.id_player;
            goals_connection.Open();

            goals = command_goals.ExecuteScalar().ToString();
            if (goals == "0")
            {
                label_goals.Text = "";
            }
            else
            {
                label_goals.Text = goals;
            }
            goals_connection.Close();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection passes_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_passes = new MySqlCommand("select passes from players\r\nwhere idplayers = @id_player;", passes_connection);
            command_passes.Parameters.Add("@id_player", MySqlDbType.VarChar).Value = main.id_player;
            passes_connection.Open();

            passes = command_passes.ExecuteScalar().ToString();
            if (passes == "0")
            {
                label_passes.Text = "";
            }
            else
            {
                label_passes.Text = passes;
            }
            passes_connection.Close();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection goals_passes_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_goals_passes = new MySqlCommand("select `goals+passes` from players \r\nwhere idplayers = @id_player;", goals_passes_connection);
            command_goals_passes.Parameters.Add("@id_player", MySqlDbType.VarChar).Value = main.id_player;
            goals_passes_connection.Open();

            goals_passes = command_goals_passes.ExecuteScalar().ToString();
            if (goals_passes == "0")
            {
                label_goals_passes.Text = "";
            }
            else
            {
                label_goals_passes.Text = goals_passes;
            }
            goals_passes_connection.Close();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection penalty_goals_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_penalty_goals = new MySqlCommand("select count(penalty_goal) from goals \r\nwhere id_player = @id_player;", penalty_goals_connection);
            command_penalty_goals.Parameters.Add("@id_player", MySqlDbType.VarChar).Value = main.id_player;
            penalty_goals_connection.Open();

            penalty_goals = command_penalty_goals.ExecuteScalar().ToString();
            if (penalty_goals == "0")
            {
                label_penalty_goals.Text = "";
            }
            else
            {
                label_penalty_goals.Text = penalty_goals;
            }
            penalty_goals_connection.Close();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }
    }
}
