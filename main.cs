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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace football
{
    public partial class main : Form
    {
        Database db = new Database();
        string myConnectionString = "Database=football;Data Source=127.0.0.1;User Id=root;Password=1337";

        public static int id_player;
        int selectedRow;
        public main()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void main_Load(object sender, EventArgs e)
        {

            CreateColumns_matches();
            RefreshDataGrid_matches(dataGridView_matches);
            dataGridView_matches.ClearSelection();

            //////////////////////////////////////////////////////////////////

            CreateColumns_best_players();
            RefreshDataGrid_best_players(dataGridView_best_players);
            dataGridView_best_players.ClearSelection();

            id_player = -1;
        }

        private void CreateColumns_matches()
        {
            dataGridView_matches.Columns.Add("match_info", "Счёт");
            dataGridView_matches.Columns.Add("date", "Дата");
            dataGridView_matches.Columns[0].Width = 419;
            dataGridView_matches.Columns[1].Visible = false;

        }

        private void ReadSingleRow_matches(DataGridView dwg, IDataRecord record)
        {
            dwg.Rows.Add(record.GetString(0), record.GetDateTime(1));

        }

        private void RefreshDataGrid_matches(DataGridView dwg)
        {
            dwg.Rows.Clear();
            MySqlCommand command = new MySqlCommand("SELECT CONCAT(t1.title, '  ', m.team1_score, ' : ', m.team2_score, '  ', t2.title) AS match_info, date\r\nFROM matches AS m\r\nJOIN teams AS t1 ON m.id_team1 = t1.idteams\r\nJOIN teams AS t2 ON m.id_team2 = t2.idteams\r\norder by date\r\nlimit 4", db.getConnection());
            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_matches(dwg, reader);
            }
            reader.Close();
        }




        private void CreateColumns_best_players()
        {
            dataGridView_best_players.Columns.Add("idplayers", "id");
            dataGridView_best_players.Columns.Add("name", "Имя");
            dataGridView_best_players.Columns.Add("goals", "Голы");
            dataGridView_best_players.Columns[1].Width = 215;
            dataGridView_best_players.Columns[0].Visible = false;
            dataGridView_best_players.Columns[2].Visible = false;

        }

        private void ReadSingleRow_best_players(DataGridView dwg, IDataRecord record)
        {
            dwg.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2));

        }

        private void RefreshDataGrid_best_players(DataGridView dwg)
        {
            dwg.Rows.Clear();
            MySqlCommand command = new MySqlCommand("SELECT idplayers, concat(name,' ',lastname) as name, `goals+passes` as goals\r\nFROM players\r\nORDER BY `goals+passes` DESC\r\nLIMIT 5;", db.getConnection());
            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_best_players(dwg, reader);
            }
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            all_matches frm1 = new all_matches();
            this.Hide();
            frm1.ShowDialog();

            id_player = -1;
            dataGridView_best_players.ClearSelection();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (id_player == -1)
            {
                MessageBox.Show("Ни один игрок не выбран.");
            }
            else
            {
                about_player frm1 = new about_player();
                this.Hide();
                frm1.ShowDialog();
                this.Show();
            }
        }

        private void dataGridView_best_players_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            String i;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_best_players.Rows[selectedRow];

                i = row.Cells[0].Value.ToString();
                id_player = Convert.ToInt32(i);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            other_tables frm1 = new other_tables();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }
    }
}
