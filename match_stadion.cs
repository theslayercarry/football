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
    public partial class match_stadion : Form
    {
        Database db = new Database();
        string myConnectionString = "Database=football;Data Source=127.0.0.1;User Id=root;Password=1337";

        String help;
        DateTime date;
        public match_stadion()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void match_stadion_Load(object sender, EventArgs e)
        {
            MySqlConnection team1_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_team1 = new MySqlCommand("select t1.title from matches\r\njoin teams t1 on matches.id_team1 = t1.idteams where idmatches = @id_match", team1_connection);
            command_team1.Parameters.Add("@id_match", MySqlDbType.VarChar).Value = all_matches.id_match;
            team1_connection.Open();

            help = command_team1.ExecuteScalar().ToString();
            label_team1.Text = help;
            team1_connection.Close();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection team2_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_team2 = new MySqlCommand("select t2.title from matches\r\njoin teams t2 on matches.id_team2 = t2.idteams where idmatches = @id_match", team2_connection);
            command_team2.Parameters.Add("@id_match", MySqlDbType.VarChar).Value = all_matches.id_match;
            team2_connection.Open();

            help = command_team2.ExecuteScalar().ToString();
            label_team2.Text = help;
            team2_connection.Close();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection score_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_score = new MySqlCommand("select concat(matches.team1_score, '  :  ', matches.team2_score) from matches\r\nJOIN teams AS t1 ON matches.id_team1 = t1.idteams\r\nJOIN teams AS t2 ON matches.id_team2 = t2.idteams\r\nwhere idmatches = @id_match", score_connection);
            command_score.Parameters.Add("@id_match", MySqlDbType.VarChar).Value = all_matches.id_match;
            score_connection.Open();

            help = command_score.ExecuteScalar().ToString();
            label_score.Text = help;
            score_connection.Close();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection date_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_date = new MySqlCommand("select date from matches \r\nwhere idmatches = @id_match", date_connection);
            command_date.Parameters.Add("@id_match", MySqlDbType.VarChar).Value = all_matches.id_match;
            date_connection.Open();

            help = command_date.ExecuteScalar().ToString();

            date = DateTime.Parse(help);
            date.GetDateTimeFormats('u');
            help = date.ToString("yyyy-MM-dd");

            label_date_match.Text = help;
            date_connection.Close();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection views_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_views = new MySqlCommand("select number_of_viewers from matches\r\nwhere idmatches = @id_match;", views_connection);
            command_views.Parameters.Add("@id_match", MySqlDbType.VarChar).Value = all_matches.id_match;
            views_connection.Open();

            help = command_views.ExecuteScalar().ToString();
            label_views.Text = help;
            views_connection.Close();
        }
    }
}
