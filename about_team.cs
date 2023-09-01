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
using System.Xml.Linq;

namespace football
{
    public partial class about_team : Form
    {
        Database db = new Database();
        string myConnectionString = "Database=football;Data Source=127.0.0.1;User Id=root;Password=1337";
        String team_title, coach;
        int selectedRow;
        public about_team()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            label6.BackColor = Color.OrangeRed;
            label1.BackColor = Color.Transparent;
            dataGridView_matches.Visible = false;
            dataGridView_squad.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.BackColor = Color.OrangeRed;
            label6.BackColor = Color.Transparent;
            dataGridView_matches.Visible = true;
            dataGridView_squad.Visible = false;
        }

        private void about_team_Load(object sender, EventArgs e)
        {
            MySqlConnection team_title_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_team_title = new MySqlCommand("select title from teams where idteams = @id_team;", team_title_connection);
            command_team_title.Parameters.Add("@id_team", MySqlDbType.VarChar).Value = all_matches.id_team;
            team_title_connection.Open();

            team_title = command_team_title.ExecuteScalar().ToString();
            label_title.Text = team_title;
            team_title_connection.Close();

            label6.BackColor = Color.OrangeRed;

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection coach_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_coach = new MySqlCommand("select concat(coaches.name,\" \",coaches.lastname) from teams\r\njoin coaches on teams.id_coach = coaches.idcoaches\r\nwhere idteams = @id_team;", coach_connection);
            command_coach.Parameters.Add("@id_team", MySqlDbType.VarChar).Value = all_matches.id_team;
            coach_connection.Open();

            coach = command_coach.ExecuteScalar().ToString();
            label_coach.Text = coach;
            coach_connection.Close();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            pictureBox_anglia.Visible = false;
            pictureBox_argentina.Visible = false;
            pictureBox_belgia.Visible = false;
            pictureBox_default.Visible = false;
            pictureBox_france.Visible = false;
            pictureBox_germany.Visible = false;
            pictureBox_kosta_rico.Visible = false;
            pictureBox_marocco.Visible = false;
            pictureBox_mexica.Visible = false;
            pictureBox_portugalia.Visible = false;
            pictureBox_switzerland.Visible = false;


            if (all_matches.id_team == 1)
            {
                pictureBox_portugalia.Visible = true;
            }
            else if (all_matches.id_team == 2)
            {
                pictureBox_argentina.Visible = true;
            }
            else if (all_matches.id_team == 3)
            {
                pictureBox_marocco.Visible = true;
            }
            else if (all_matches.id_team == 4)
            {
                pictureBox_france.Visible = true;
            }
            else if (all_matches.id_team == 5)
            {
                pictureBox_germany.Visible = true;
            }
            else if (all_matches.id_team == 6)
            {
                pictureBox_kosta_rico.Visible = true;
            }
            else if (all_matches.id_team == 7)
            {
                pictureBox_anglia.Visible = true;
            }
            else if (all_matches.id_team == 8)
            {
                pictureBox_belgia.Visible = true;
            }
            else if (all_matches.id_team == 9)
            {
                pictureBox_mexica.Visible = true;
            }
            else if (all_matches.id_team == 10)
            {
                pictureBox_switzerland.Visible = true;
            }
            else
            {
                pictureBox_default.Visible = true;
            }

            CreateColumns_squad();
            RefreshDataGrid_squad(dataGridView_squad);
            dataGridView_squad.ClearSelection();

            //////////////////////////////////////////////////////////////////

            CreateColumns_matches();
            RefreshDataGrid_matches(dataGridView_matches);
            dataGridView_matches.ClearSelection();

            //////////////////////////////////////////////////////////////////

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CreateColumns_squad()
        {
            dataGridView_squad.Columns.Add("idplayers", "id");
            dataGridView_squad.Columns.Add("name", "Игрок");
            dataGridView_squad.Columns.Add("position", "Амплуа");
            dataGridView_squad.Columns.Add("date_of_birth", "ДР");
            dataGridView_squad.Columns[1].Width = 309;
            dataGridView_squad.Columns[2].Width = 200;
            dataGridView_squad.Columns[3].Width = 210;
            dataGridView_squad.Columns[0].Visible = false;

            this.dataGridView_squad.Columns[1].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleLeft;

            this.dataGridView_squad.Columns[2].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

            this.dataGridView_squad.Columns[3].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;

        }

        private void ReadSingleRow_squad(DataGridView dwg, IDataRecord record)
        {
            dwg.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2), record.GetDateTime(3));

        }

        private void RefreshDataGrid_squad(DataGridView dwg)
        {
            dwg.Rows.Clear();
            MySqlCommand command = new MySqlCommand("select idplayers, concat(players.name,\" \",players.lastname) as `name`, positions.title as position, date_of_birth from players\r\njoin players_to_teams on players_to_teams.id_player = players.idplayers\r\njoin teams on players_to_teams.id_team = teams.idteams\r\njoin positions on players.id_position = positions.idpositions\r\nwhere id_team = @id_team\r\norder by id_position desc;", db.getConnection());
            command.Parameters.Add("@id_team", MySqlDbType.VarChar).Value = all_matches.id_team;
            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_squad(dwg, reader);
            }
            reader.Close();
        }



        private void CreateColumns_matches()
        {
            dataGridView_matches.Columns.Add("idmatches", "id");
            dataGridView_matches.Columns.Add("date", "Счёт");
            dataGridView_matches.Columns.Add("match", "Дата");
            dataGridView_matches.Columns.Add("score", "Дата");
            dataGridView_matches.Columns[1].Width = 309;
            dataGridView_matches.Columns[2].Width = 200;
            dataGridView_matches.Columns[3].Width = 210;
            dataGridView_matches.Columns[0].Visible = false;

            this.dataGridView_matches.Columns[1].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleLeft;

            this.dataGridView_matches.Columns[2].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleLeft;

            this.dataGridView_matches.Columns[2].DefaultCellStyle.Alignment =
                   DataGridViewContentAlignment.MiddleCenter;
        }

        private void ReadSingleRow_matches(DataGridView dwg, IDataRecord record)
        {
            dwg.Rows.Add(record.GetString(0), record.GetDateTime(1), record.GetString(2), record.GetString(3));

        }

        private void dataGridView_matches_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            String i;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_matches.Rows[selectedRow];

                i = row.Cells[0].Value.ToString();
                all_matches.id_match = Convert.ToInt32(i);
            }

            about_match frm1 = new about_match();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void dataGridView_squad_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            String i;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_squad.Rows[selectedRow];

                i = row.Cells[0].Value.ToString();
                main.id_player = Convert.ToInt32(i);
            }

            about_player frm1 = new about_player();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void RefreshDataGrid_matches(DataGridView dwg)
        {
            dwg.Rows.Clear();
            MySqlCommand command = new MySqlCommand("select idmatches, date, concat(t1.title,\" - \",t2.title) as `match`, concat(team1_score,\":\",team2_score) as score from matches\r\njoin teams t1 on matches.id_team1 = t1.idteams\r\njoin teams t2 on matches.id_team2 = t2.idteams\r\nwhere id_team1 = @id_team or id_team2 = @id_team;", db.getConnection());
            command.Parameters.Add("@id_team", MySqlDbType.VarChar).Value = all_matches.id_team;
            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_matches(dwg, reader);
            }
            reader.Close();
        }
    }
}
