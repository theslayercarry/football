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
    public partial class teams : Form
    {
        Database db = new Database();
        string myConnectionString = "Database=football;Data Source=127.0.0.1;User Id=root;Password=1337";
        public static int id_team;
        String m; int selectedRow;
        public teams()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void teams_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid_teams(dataGridView1);
            dataGridView1.ClearSelection();
        }


        private void CreateColumns()
        {
            dataGridView1.Columns.Add("idteams", "id");
            dataGridView1.Columns.Add("team", "Команда");
            dataGridView1.Columns.Add("coach", "Тренер");
            dataGridView1.Columns[0].Width = 210;
            dataGridView1.Columns[1].Width = 180;
            dataGridView1.Columns[2].Width = 255;
        }

        private void ReadSingleRow_teams(DataGridView dwg, IDataRecord record)
        {
            dwg.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2));

        }

        private void RefreshDataGrid_teams(DataGridView dwg)
        {
            dwg.Rows.Clear();
            MySqlCommand command = new MySqlCommand("select idteams, title as 'Команда', concat(coaches.name,\" \",coaches.lastname) as 'Тренер' from teams\r\njoin coaches on teams.id_coach = coaches.idcoaches order by idteams;", db.getConnection());
            db.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_teams(dwg, reader);
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
                id_team = Convert.ToInt32(i);
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            teams_add frm1 = new teams_add();
            this.Hide();
            frm1.ShowDialog();
            RefreshDataGrid_teams(dataGridView1);
            dataGridView1.ClearSelection();
            m = null;
            this.Show();
        }

        private void button_change_Click(object sender, EventArgs e)
        {
            if (m != null)
            {
                teams_change frm1 = new teams_change();
                this.Hide();
                frm1.ShowDialog();

                RefreshDataGrid_teams(dataGridView1);
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
                MySqlCommand command = new MySqlCommand("delete from teams where idteams = @id_team", db.getConnection());
                command.Parameters.Add("@id_team", MySqlDbType.VarChar).Value = id_team;
                command.ExecuteNonQuery();

                MessageBox.Show("Запись успешно удалена.", "Удаление записи...");

                m = null;

                RefreshDataGrid_teams(dataGridView1);

                db.closeConnection();
                dataGridView1.ClearSelection();
            }
            else
                MessageBox.Show("Ни одна запись не выбрана.");
        }
    }
}
