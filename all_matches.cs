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
    public partial class all_matches : Form
    {
        Database db = new Database();
        string myConnectionString = "Database=football;Data Source=127.0.0.1;User Id=root;Password=1337";

        public static int id_match, id_team;
        int selectedRow;

        public all_matches()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void all_matches_Load(object sender, EventArgs e)
        {
            CreateColumns_matches();
            RefreshDataGrid_matches(dataGridView_matches);
            dataGridView_matches.ClearSelection();

            //////////////////////////////////////////////////////////////////

            CreateColumns_teams();
            RefreshDataGrid_teams(dataGridView_teams);
            dataGridView_teams.ClearSelection();

            id_match = -1;
            id_team = -1;
        }

        private void CreateColumns_matches()
        {
            dataGridView_matches.Columns.Add("idmatches", "id");
            dataGridView_matches.Columns.Add("match_info", "Счёт");
            dataGridView_matches.Columns.Add("date", "Дата");
            dataGridView_matches.Columns[0].Visible = false;
            dataGridView_matches.Columns[1].Width = 366;
            dataGridView_matches.Columns[2].Width = 366;

            this.dataGridView_matches.Columns[1].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

            this.dataGridView_matches.Columns[2].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;
        }

        private void ReadSingleRow_matches(DataGridView dwg, IDataRecord record)
        {
            dwg.Rows.Add(record.GetString(0), record.GetString(1), record.GetDateTime(2));

        }

        private void RefreshDataGrid_matches(DataGridView dwg)
        {
            dwg.Rows.Clear();
            MySqlCommand command = new MySqlCommand("SELECT idmatches, CONCAT(t1.title, '  ', m.team1_score, ' : ', m.team2_score, '  ', t2.title) AS match_info, date\r\nFROM matches AS m\r\nJOIN teams AS t1 ON m.id_team1 = t1.idteams\r\nJOIN teams AS t2 ON m.id_team2 = t2.idteams\r\norder by date\r\n", db.getConnection());
            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_matches(dwg, reader);
            }
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (id_match == -1)
            {
                MessageBox.Show("Ни один матч не выбран.");
            }
            else
            {
                about_match frm1 = new about_match();
                this.Hide();
                frm1.ShowDialog();
                this.Show();
            }
        }

        private void dataGridView_matches_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            String i;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_matches.Rows[selectedRow];

                i = row.Cells[0].Value.ToString();
                id_match = Convert.ToInt32(i);
            }
        }



        private void CreateColumns_teams()
        {
            dataGridView_teams.Columns.Add("idteams", "id");
            dataGridView_teams.Columns.Add("title", "Название");
            dataGridView_teams.Columns[1].Width = 215;
            dataGridView_teams.Columns[0].Visible = false;

        }

        private void ReadSingleRow_teams(DataGridView dwg, IDataRecord record)
        {
            dwg.Rows.Add(record.GetString(0), record.GetString(1));

        }

        private void dataGridView_teams_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            String i;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_teams.Rows[selectedRow];

                i = row.Cells[0].Value.ToString();
                id_team = Convert.ToInt32(i);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (id_team == -1)
            {
                MessageBox.Show("Ни одна команда не выбрана.");
            }
            else
            {
                about_team frm1 = new about_team();
                this.Hide();
                frm1.ShowDialog();
                this.Show();
            }
        }

        private void RefreshDataGrid_teams(DataGridView dwg)
        {
            dwg.Rows.Clear();
            MySqlCommand command = new MySqlCommand("select idteams, title from teams", db.getConnection());
            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_teams(dwg, reader);
            }
            reader.Close();
        }
    }
}
