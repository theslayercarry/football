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
    public partial class teams_change : Form
    {
        Database db = new Database();
        string myConnectionString = "Database=football;Data Source=127.0.0.1;User Id=root;Password=1337";
        String help, team;
        int id_coach;
        public teams_change()
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

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("update teams set title = @title, id_coach = @id_coach where idteams = @id_team;", db.getConnection());
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = textBox_team.Text;
            cmd.Parameters.Add("@id_coach", MySqlDbType.VarChar).Value = comboBox_coach.SelectedValue;
            cmd.Parameters.Add("@id_team", MySqlDbType.VarChar).Value = teams.id_team;

            db.openConnection();
            if (textBox_team.Text == "")
            {
                MessageBox.Show("1.Введите название команды.\r\n", "Несоответствие форме изменения записи");
            }
            else if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Данные успешно изменены.", "Изменение данных...");

                db.closeConnection();

            }
            else
            {
                MessageBox.Show("Ошибка при изменении данных.");
            }
        }

        private void teams_change_Load(object sender, EventArgs e)
        {
            MySqlConnection team_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_team = new MySqlCommand("select title from teams where idteams = @id_team;", team_connection);
            command_team.Parameters.Add("@id_team", MySqlDbType.VarChar).Value = teams.id_team;
            team_connection.Open();

            team = command_team.ExecuteScalar().ToString();
            team_connection.Close();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection coach_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_coach = new MySqlCommand("select id_coach from teams where idteams = @id_team;", coach_connection);
            command_coach.Parameters.Add("@id_team", MySqlDbType.VarChar).Value = teams.id_team;
            coach_connection.Open();

            help = command_coach.ExecuteScalar().ToString();
            id_coach = Int32.Parse(help);
            coach_connection.Close();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            textBox_team.Text = team;
            comboBox_coach.SelectedValue = id_coach;

            label_id.Text = teams.id_team.ToString();
        }
    }
}
