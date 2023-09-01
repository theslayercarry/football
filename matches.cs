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
    public partial class matches : Form
    {
        Database db = new Database();
        string myConnectionString = "Database=football;Data Source=127.0.0.1;User Id=root;Password=1337";
        public static int id_match;
        String m; int selectedRow;
        public matches()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void matches_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid_matches(dataGridView1);
            dataGridView1.ClearSelection();
        }


        private void CreateColumns()
        {
            dataGridView1.Columns.Add("idmatches", "id");
            dataGridView1.Columns.Add("score", "Результат встречи");
            dataGridView1.Columns.Add("date", "Дата");
            dataGridView1.Columns.Add("referee", "Главный судья");
            dataGridView1.Columns.Add("viewers", "Количество зрителей");
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 305;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 350;
            dataGridView1.Columns[4].Width = 220;

            this.dataGridView1.Columns[1].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

            this.dataGridView1.Columns[2].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

            this.dataGridView1.Columns[4].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void ReadSingleRow_matches(DataGridView dwg, IDataRecord record)
        {
            dwg.Rows.Add(record.GetString(0), record.GetString(1), record.GetDateTime(2), record.GetString(3), record.GetString(4));

        }

        private void RefreshDataGrid_matches(DataGridView dwg)
        {
            dwg.Rows.Clear();
            MySqlCommand command = new MySqlCommand("SELECT idmatches, CONCAT(t1.title, '  ', m.team1_score, ' : ', m.team2_score, '  ', t2.title) AS 'Результат встречи', date as 'Дата', concat(referees.name,\" \",referees.lastname) as 'Главный судья', number_of_viewers as 'Количество зрителей' FROM matches AS m\r\nJOIN teams AS t1 ON m.id_team1 = t1.idteams\r\nJOIN teams AS t2 ON m.id_team2 = t2.idteams\r\nJOIN referees on m.id_referee = referees.idreferees order by idmatches;", db.getConnection());
            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_matches(dwg, reader);
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
                id_match = Convert.ToInt32(i);
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            matches_add frm1 = new matches_add();
            this.Hide();
            frm1.ShowDialog();
            RefreshDataGrid_matches(dataGridView1);
            dataGridView1.ClearSelection();
            m = null;
            this.Show();
        }

        private void button_change_Click(object sender, EventArgs e)
        {
            if (m != null)
            {
                matches_change frm1 = new matches_change();
                this.Hide();
                frm1.ShowDialog();

                RefreshDataGrid_matches(dataGridView1);
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
                MySqlCommand command = new MySqlCommand("delete from matches where idmatches = @id_match", db.getConnection());
                command.Parameters.Add("@id_match", MySqlDbType.VarChar).Value = id_match;
                command.ExecuteNonQuery();

                MessageBox.Show("Запись успешно удалена.", "Удаление записи...");

                m = null;

                RefreshDataGrid_matches(dataGridView1);

                db.closeConnection();
                dataGridView1.ClearSelection();
            }
            else
                MessageBox.Show("Ни одна запись не выбрана.");
        }
    }
}
