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
    public partial class teams_add : Form
    {
        Database db = new Database();
        string myConnectionString = "Database=football;Data Source=127.0.0.1;User Id=root;Password=1337";
        public teams_add()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;


            DataTable coaches = new DataTable();
            MySqlConnection connection_coaches = new MySqlConnection(myConnectionString);
            {
                MySqlCommand command = new MySqlCommand("select idcoaches, concat(name,\" \",lastname) as coach from coaches;", connection_coaches);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(coaches);
            }
            comboBox_coach.DataSource = coaches;
            comboBox_coach.DisplayMember = "coach";
            comboBox_coach.ValueMember = "idcoaches";

            comboBox_coach.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void teams_add_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("insert into teams (title, id_coach) values\r\n(@title, @id_coach);", db.getConnection());
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = textBox_team.Text;
            cmd.Parameters.Add("@id_coach", MySqlDbType.VarChar).Value = comboBox_coach.SelectedValue;

            db.openConnection();
            if (textBox_team.Text == "")
            {
                MessageBox.Show("1.Введите название команды.", "Несоответствие форме добавления записи");
            }
            else if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Команда '" + textBox_team.Text + "' успешно добавлена.", "Добавление команды...");

                db.closeConnection();

            }
            else
            {
                MessageBox.Show("Произошла ошибка при добавлении команды.", "Ошибка при добавлении...");
            }
        }
    }
}
