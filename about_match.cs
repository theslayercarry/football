using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace football
{
    public partial class about_match : Form
    {
        Database db = new Database();
        string myConnectionString = "Database=football;Data Source=127.0.0.1;User Id=root;Password=1337";

        public static int id_team1, id_team2;
        String help;
        DateTime date;
        int selectedRow;
        public about_match()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void about_match_Load(object sender, EventArgs e)
        {
            MySqlConnection team1_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_team1 = new MySqlCommand("select t1.title from matches\r\njoin teams t1 on matches.id_team1 = t1.idteams where idmatches = @id_match", team1_connection);
            command_team1.Parameters.Add("@id_match", MySqlDbType.VarChar).Value = all_matches.id_match;
            team1_connection.Open();

            help = command_team1.ExecuteScalar().ToString();
            label_team1_graphic.Text = help;
            label_team1.Text = help;
            team1_connection.Close();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection team2_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_team2 = new MySqlCommand("select t2.title from matches\r\njoin teams t2 on matches.id_team2 = t2.idteams where idmatches = @id_match", team2_connection);
            command_team2.Parameters.Add("@id_match", MySqlDbType.VarChar).Value = all_matches.id_match;
            team2_connection.Open();

            help = command_team2.ExecuteScalar().ToString();
            label_team2_graphic.Text = help;
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

            MySqlConnection team1_id_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_team1_id = new MySqlCommand("select id_team1 from matches where idmatches = @id_match", team1_id_connection);
            command_team1_id.Parameters.Add("@id_match", MySqlDbType.VarChar).Value = all_matches.id_match;
            team1_id_connection.Open();

            help = command_team1_id.ExecuteScalar().ToString();
            id_team1 = Convert.ToInt32(help);
            team1_id_connection.Close();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection team2_id_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_team2_id = new MySqlCommand("select id_team2 from matches where idmatches = @id_match", team2_id_connection);
            command_team2_id.Parameters.Add("@id_match", MySqlDbType.VarChar).Value = all_matches.id_match;
            team2_id_connection.Open();

            help = command_team2_id.ExecuteScalar().ToString();
            id_team2 = Convert.ToInt32(help);
            team2_id_connection.Close();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection team1_coach_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_team1_coach = new MySqlCommand("select concat(coaches.name,\" \",coaches.lastname) from teams\r\njoin coaches on teams.id_coach = coaches.idcoaches where idteams = @id_team1", team1_coach_connection);
            command_team1_coach.Parameters.Add("@id_team1", MySqlDbType.VarChar).Value = id_team1;
            team1_coach_connection.Open();

            help = command_team1_coach.ExecuteScalar().ToString();
            label_team1_coach.Text = "Тренер: " + help;
            team1_coach_connection.Close();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection team2_coach_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_team2_coach = new MySqlCommand("select concat(coaches.name,\" \",coaches.lastname) from teams\r\njoin coaches on teams.id_coach = coaches.idcoaches where idteams = @id_team2", team2_coach_connection);
            command_team2_coach.Parameters.Add("@id_team2", MySqlDbType.VarChar).Value = id_team2;
            team2_coach_connection.Open();

            help = command_team2_coach.ExecuteScalar().ToString();
            label_team2_coach.Text = "Тренер: " + help;
            team2_coach_connection.Close();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            CreateColumns_team1();
            RefreshDataGrid_team1(dataGridView_team1);
            dataGridView_team1.ClearSelection();

            //////////////////////////////////////////////////////////////////

            CreateColumns_team2();
            RefreshDataGrid_team2(dataGridView_team2);
            dataGridView_team2.ClearSelection();

            //////////////////////////////////////////////////////////////////

            CreateColumns_goals();
            RefreshDataGrid_goals(dataGridView_goals);
            dataGridView_goals.ClearSelection();

            //////////////////////////////////////////////////////////////////

            CreateColumns_replaces();
            RefreshDataGrid_replaces(dataGridView_replaces);
            dataGridView_replaces.ClearSelection();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection referee_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_referee = new MySqlCommand("select concat(referees.name,\" \",referees.lastname) from matches\r\njoin referees on matches.id_referee = referees.idreferees\r\nwhere idmatches = @id_match;", referee_connection);
            command_referee.Parameters.Add("@id_match", MySqlDbType.VarChar).Value = all_matches.id_match;
            referee_connection.Open();

            help = command_referee.ExecuteScalar().ToString();
            label_referees.Text = help;
            referee_connection.Close();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            linkLabel_teams.BackColor = Color.OrangeRed;

            
            panel_replaces.Visible = false;
            panel_goals.Visible = false;
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CreateColumns_team1()
        {
            dataGridView_team1.Columns.Add("idplayers", "id");
            dataGridView_team1.Columns.Add("name", "Имя");
            dataGridView_team1.Columns.Add("position", "Позиция");
            dataGridView_team1.Columns[1].Width = 200;
            dataGridView_team1.Columns[2].Width = 125;
            dataGridView_team1.Columns[0].Visible = false;

            this.dataGridView_team1.Columns[1].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleLeft;

            this.dataGridView_team1.Columns[2].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

        }

        private void ReadSingleRow_team1(DataGridView dwg, IDataRecord record)
        {
            dwg.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2));

        }

        private void RefreshDataGrid_team1(DataGridView dwg)
        {
            dwg.Rows.Clear();
            MySqlCommand command = new MySqlCommand("SELECT idplayers, concat(name,\" \", lastname), positions.title FROM football.players\r\njoin positions on players.id_position = positions.idpositions\r\njoin players_to_teams on players_to_teams.id_player = players.idplayers\r\njoin teams on players_to_teams.id_team = teams.idteams\r\nwhere id_team = @id_team1\r\norder by total_matches desc\r\nlimit 16;", db.getConnection());
            command.Parameters.Add("@id_team1", MySqlDbType.VarChar).Value = id_team1;
            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_team1(dwg, reader);
            }
            reader.Close();
        }


        private void CreateColumns_team2()
        {
            dataGridView_team2.Columns.Add("idplayers", "id");
            dataGridView_team2.Columns.Add("name", "Имя");
            dataGridView_team2.Columns.Add("position", "Позиция");
            dataGridView_team2.Columns[1].Width = 200;
            dataGridView_team2.Columns[2].Width = 125;
            dataGridView_team2.Columns[0].Visible = false;

            this.dataGridView_team2.Columns[1].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleLeft;

            this.dataGridView_team2.Columns[2].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

        }

        private void ReadSingleRow_team2(DataGridView dwg, IDataRecord record)
        {
            dwg.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2));

        }

        private void linkLabel_about_match_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            match_stadion frm1 = new match_stadion();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void dataGridView_team1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void linkLabel_goals_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel_goals.BackColor = Color.OrangeRed;
            linkLabel_teams.BackColor = Color.Transparent;
            linkLabel_replaces.BackColor = Color.Transparent;
            panel_teams.Visible = false;
            panel_replaces.Visible = false;
            panel_goals.Visible = true;
        }

        private void linkLabel_replaces_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel_replaces.BackColor = Color.OrangeRed;
            linkLabel_goals.BackColor = Color.Transparent;
            linkLabel_teams.BackColor = Color.Transparent;
            panel_goals.Visible = false;
            panel_teams.Visible = false;
            panel_replaces.Visible = true;
        }

        private void RefreshDataGrid_team2(DataGridView dwg)
        {
            dwg.Rows.Clear();
            MySqlCommand command = new MySqlCommand("SELECT idplayers, concat(name,\" \", lastname), positions.title FROM football.players\r\njoin positions on players.id_position = positions.idpositions\r\njoin players_to_teams on players_to_teams.id_player = players.idplayers\r\njoin teams on players_to_teams.id_team = teams.idteams\r\nwhere id_team = @id_team2\r\norder by total_matches desc\r\nlimit 16;", db.getConnection());
            command.Parameters.Add("@id_team2", MySqlDbType.VarChar).Value = id_team2;
            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_team2(dwg, reader);
            }
            reader.Close();
        }




        private void CreateColumns_goals()
        {
            dataGridView_goals.Columns.Add("player", "игрок");
            dataGridView_goals.Columns.Add("score", "счёт");
            dataGridView_goals.Columns.Add("team", "команда");
            dataGridView_goals.Columns.Add("minute", "минута");
            dataGridView_goals.Columns[0].Width = 200;
            dataGridView_goals.Columns[1].Width = 100;
            dataGridView_goals.Columns[2].Width = 200;
            dataGridView_goals.Columns[3].Width = 100;

            this.dataGridView_goals.Columns[0].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleLeft;

        }

        private void ReadSingleRow_goals(DataGridView dwg, IDataRecord record)
        {
            dwg.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2), record.GetString(3));

        }

        private void linkLabel_teams_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel_teams.BackColor = Color.OrangeRed;
            linkLabel_goals.BackColor = Color.Transparent;
            linkLabel_replaces.BackColor = Color.Transparent;
            panel_teams.Visible = true;
            panel_goals.Visible = false;
            panel_replaces.Visible = false;
        }

        private void RefreshDataGrid_goals(DataGridView dwg)
        {
            dwg.Rows.Clear();
            MySqlCommand command = new MySqlCommand("CALL goals(@id_match);", db.getConnection());
            command.Parameters.Add("@id_match", MySqlDbType.VarChar).Value = all_matches.id_match;

            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_goals(dwg, reader);
            }
            reader.Close();


        }


        private void CreateColumns_replaces()
        {
            dataGridView_replaces.Columns.Add("players", "замена");
            dataGridView_replaces.Columns.Add("team", "команда");
            dataGridView_replaces.Columns.Add("minute", "минута");
            dataGridView_replaces.Columns[0].Width = 350;
            dataGridView_replaces.Columns[1].Width = 200;
            dataGridView_replaces.Columns[2].Width = 50;

            this.dataGridView_replaces.Columns[0].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleLeft;

        }

        private void ReadSingleRow_replaces(DataGridView dwg, IDataRecord record)
        {
            dwg.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2));

        }

        private void dataGridView_team1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            String i;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_team1.Rows[selectedRow];

                i = row.Cells[0].Value.ToString();
                main.id_player = Convert.ToInt32(i);
            }

            about_player frm1 = new about_player();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void dataGridView_team2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            String i;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_team2.Rows[selectedRow];

                i = row.Cells[0].Value.ToString();
                main.id_player = Convert.ToInt32(i);
            }

            about_player frm1 = new about_player();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void RefreshDataGrid_replaces(DataGridView dwg)
        {
            dwg.Rows.Clear();
            MySqlCommand command = new MySqlCommand("SELECT CONCAT(p1.name, ' ', p1.lastname, ' --> ', p2.name, ' ', p2.lastname) AS players, teams.title as team, concat(replaces.minute, \"'\") as minute\r\nFROM replaces\r\nJOIN players AS p1 ON replaces.id_old_player = p1.idplayers\r\nJOIN players AS p2 ON replaces.id_new_player = p2.idplayers\r\njoin teams on replaces.id_team = teams.idteams\r\nwhere id_match = @id_match\r\norder by replaces.minute;", db.getConnection());
            command.Parameters.Add("@id_match", MySqlDbType.VarChar).Value = all_matches.id_match;

            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_replaces(dwg, reader);
            }
            reader.Close();


        }
    }
}
