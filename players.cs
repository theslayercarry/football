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
    public partial class players : Form
    {
        Database db = new Database();
        string myConnectionString = "Database=football;Data Source=127.0.0.1;User Id=root;Password=1337";
        public static int id_player;
        String m; int selectedRow;
        public players()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void players_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid_players(dataGridView1);
            dataGridView1.ClearSelection();
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("idplayers", "id");
            dataGridView1.Columns.Add("player", "Игрок");
            dataGridView1.Columns.Add("date_of_birth", "Дата рождения");
            dataGridView1.Columns.Add("countrie", "Гражданство");
            dataGridView1.Columns.Add("position", "Позиция");
            dataGridView1.Columns.Add("total_matches", "Матчей (всего)");
            dataGridView1.Columns.Add("total_goals(scored/missed)", "Голы (забито/пропущено)");
            dataGridView1.Columns.Add("passes", "Пасы");
            dataGridView1.Columns.Add("goals+passes", "Гол+пас");

            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 225;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 160;
            dataGridView1.Columns[4].Width = 140;
            dataGridView1.Columns[5].Width = 155;
            dataGridView1.Columns[6].Width = 180;
            dataGridView1.Columns[7].Width = 80;
            dataGridView1.Columns[8].Width = 80;

            this.dataGridView1.Columns[1].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleLeft;

            this.dataGridView1.Columns[2].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleLeft;

            this.dataGridView1.Columns[3].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

            this.dataGridView1.Columns[4].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

            this.dataGridView1.Columns[5].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

            this.dataGridView1.Columns[6].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

            this.dataGridView1.Columns[7].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

            this.dataGridView1.Columns[8].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void ReadSingleRow_players(DataGridView dwg, IDataRecord record)
        {
            dwg.Rows.Add(record.GetString(0), record.GetString(1), record.GetDateTime(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetString(7), record.GetString(8));

        }

        private void RefreshDataGrid_players(DataGridView dwg)
        {
            dwg.Rows.Clear();
            MySqlCommand command = new MySqlCommand("select idplayers, concat(players.name,\" \",players.lastname) as 'Игрок', date_of_birth as 'Дата рождения', countries.name as 'Гражданство', positions.title as 'Позиция', total_matches as 'Матчей (всего)', `total_goals(scored/missed)` as 'Голы (забито/пропущено)', passes as 'Пасы', `goals+passes` as 'Гол+пас' from players\r\njoin countries on players.id_country_nationality = countries.idcountries\r\njoin positions on players.id_position = positions.idpositions\r\norder by idplayers;", db.getConnection());
            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_players(dwg, reader);
            }
            reader.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            String i;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                i = row.Cells[0].Value.ToString();
                m = i;
                id_player = Convert.ToInt32(i);
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            players_add frm1 = new players_add();
            this.Hide();
            frm1.ShowDialog();
            RefreshDataGrid_players(dataGridView1);
            dataGridView1.ClearSelection();
            m = null;
            this.Show();
        }

        private void button_change_Click(object sender, EventArgs e)
        {
            if (m != null)
            {
                players_change frm1 = new players_change();
                this.Hide();
                frm1.ShowDialog();

                RefreshDataGrid_players(dataGridView1);
                dataGridView1.ClearSelection();

                this.Show();
                m = null;
            }
            else
                MessageBox.Show("Ни одна запись не выбрана.");
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (m != null)
            {
                db.openConnection();
                MySqlCommand command = new MySqlCommand("delete from players where idplayers = @id_player", db.getConnection());
                command.Parameters.Add("@id_player", MySqlDbType.VarChar).Value = id_player;
                command.ExecuteNonQuery();

                MessageBox.Show("Запись успешно удалена.", "Удаление записи...");

                m = null;

                RefreshDataGrid_players(dataGridView1);

                db.closeConnection();
                dataGridView1.ClearSelection();
            }
            else
                MessageBox.Show("Ни одна запись не выбрана.");
        }
    }
}
