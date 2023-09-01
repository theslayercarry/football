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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace football
{
    public partial class matches_change : Form
    {
        Database db = new Database();
        string myConnectionString = "Database=football;Data Source=127.0.0.1;User Id=root;Password=1337";
        String help, match_date;
        int id_team1, id_team2, id_referee, team1_score, team2_score, viewers;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_team1_score.Text == "" || textBox_team2_score.Text == "" || textBox_viewers.Text == "")
            {
                MessageBox.Show("1.Введите результат встречи команд.\r\n" +
                        "2.Введите количество зрителей у данного матча.\r\n" + "" +
                        "3.Введите дату проведения матча.\r\n", "Несоответствие форме изменения записи");
            }
            else if ((int)comboBox_team1.SelectedValue == (int)comboBox_team2.SelectedValue)
            {
                MessageBox.Show("Ошибка при изменении данных.");
            }
            else
            {
                team1_score = Int32.Parse(textBox_team1_score.Text);
                team2_score = Int32.Parse(textBox_team2_score.Text);
                viewers = Int32.Parse(textBox_viewers.Text);
                MySqlCommand cmd = new MySqlCommand("update matches set id_team1 = @id_team1, id_team2 = @id_team2, id_referee = @id_referee, team1_score = @team1_score, team2_score = @team2_score, date = @date, number_of_viewers = @number_of_viewers where idmatches = @id_match;", db.getConnection());
                cmd.Parameters.Add("@id_team1", MySqlDbType.VarChar).Value = comboBox_team1.SelectedValue;
                cmd.Parameters.Add("@id_team2", MySqlDbType.VarChar).Value = comboBox_team2.SelectedValue;
                cmd.Parameters.Add("@id_referee", MySqlDbType.VarChar).Value = comboBox_referee.SelectedValue;
                cmd.Parameters.Add("@team1_score", MySqlDbType.VarChar).Value = team1_score;
                cmd.Parameters.Add("@team2_score", MySqlDbType.VarChar).Value = team2_score;
                cmd.Parameters.Add("@date", MySqlDbType.VarChar).Value = textBox_date.Text;
                cmd.Parameters.Add("@number_of_viewers", MySqlDbType.VarChar).Value = viewers;
                cmd.Parameters.Add("@id_match", MySqlDbType.VarChar).Value = matches.id_match;

                db.openConnection();
                if (textBox_team1_score.Text == "" || textBox_team2_score.Text == "" || textBox_viewers.Text == "" || textBox_date.Text == "")
                {
                    MessageBox.Show("1.Введите результат встречи команд.\r\n" +
                        "2.Введите количество зрителей у данного матча.\r\n" + "" +
                        "3.Введите дату проведения матча.\r\n", "Несоответствие форме изменения записи");
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
        }

        DateTime date;
        public matches_change()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;


            DataTable team1 = new DataTable();
            MySqlConnection connection_team1 = new MySqlConnection(myConnectionString);
            {
                MySqlCommand command = new MySqlCommand("select idteams, title from teams;", connection_team1);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(team1);
            }
            comboBox_team1.DataSource = team1;
            comboBox_team1.DisplayMember = "title";
            comboBox_team1.ValueMember = "idteams";


            DataTable team2 = new DataTable();
            MySqlConnection connection_team2 = new MySqlConnection(myConnectionString);
            {
                MySqlCommand command = new MySqlCommand("select idteams, title from teams;", connection_team2);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(team2);
            }
            comboBox_team2.DataSource = team2;
            comboBox_team2.DisplayMember = "title";
            comboBox_team2.ValueMember = "idteams";


            DataTable referee = new DataTable();
            MySqlConnection connection_referee = new MySqlConnection(myConnectionString);
            {
                MySqlCommand command = new MySqlCommand("select idreferees, concat(referees.name,\" \",referees.lastname) as referee from referees;", connection_referee);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(referee);
            }
            comboBox_referee.DataSource = referee;
            comboBox_referee.DisplayMember = "referee";
            comboBox_referee.ValueMember = "idreferees";


            comboBox_team1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_team2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_referee.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void matches_change_Load(object sender, EventArgs e)
        {
            label_id.Text = matches.id_match.ToString();

            MySqlConnection team1_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_team1 = new MySqlCommand("select id_team1 from matches where idmatches = @id_match;", team1_connection);
            command_team1.Parameters.Add("@id_match", MySqlDbType.VarChar).Value = matches.id_match;
            team1_connection.Open();

            help = command_team1.ExecuteScalar().ToString();
            id_team1 = Int32.Parse(help);
            team1_connection.Close();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection team2_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_team2 = new MySqlCommand("select id_team2 from matches where idmatches = @id_match;", team2_connection);
            command_team2.Parameters.Add("@id_match", MySqlDbType.VarChar).Value = matches.id_match;
            team2_connection.Open();

            help = command_team2.ExecuteScalar().ToString();
            id_team2 = Int32.Parse(help);
            team2_connection.Close();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection team1_score_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_team1_score = new MySqlCommand("select team1_score from matches where idmatches = @id_match;", team1_score_connection);
            command_team1_score.Parameters.Add("@id_match", MySqlDbType.VarChar).Value = matches.id_match;
            team1_score_connection.Open();

            help = command_team1_score.ExecuteScalar().ToString();
            team1_score = Int32.Parse(help);
            team1_score_connection.Close();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection team2_score_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_team2_score = new MySqlCommand("select team2_score from matches where idmatches = @id_match;", team2_score_connection);
            command_team2_score.Parameters.Add("@id_match", MySqlDbType.VarChar).Value = matches.id_match;
            team2_score_connection.Open();

            help = command_team2_score.ExecuteScalar().ToString();
            team2_score = Int32.Parse(help);
            team2_score_connection.Close();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection referee_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_referee = new MySqlCommand("select id_referee from matches where idmatches = @id_match;", referee_connection);
            command_referee.Parameters.Add("@id_match", MySqlDbType.VarChar).Value = matches.id_match;
            referee_connection.Open();

            help = command_referee.ExecuteScalar().ToString();
            id_referee = Int32.Parse(help);
            referee_connection.Close();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection date_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_date = new MySqlCommand("select date from matches where idmatches = @id_match;", date_connection);
            command_date.Parameters.Add("@id_match", MySqlDbType.VarChar).Value = matches.id_match;
            date_connection.Open();

            match_date = command_date.ExecuteScalar().ToString();
            date_connection.Close();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection viewers_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_viewers = new MySqlCommand("select number_of_viewers from matches where idmatches = @id_match;", viewers_connection);
            command_viewers.Parameters.Add("@id_match", MySqlDbType.VarChar).Value = matches.id_match;
            viewers_connection.Open();

            help = command_viewers.ExecuteScalar().ToString();
            viewers = Int32.Parse(help);
            viewers_connection.Close();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            textBox_team1_score.Text = team1_score.ToString();
            textBox_team2_score.Text = team2_score.ToString();
            comboBox_team1.SelectedValue = id_team1;
            comboBox_team2.SelectedValue = id_team2;
            comboBox_referee.SelectedValue = id_referee;
            textBox_viewers.Text = viewers.ToString();

            date = DateTime.Parse(match_date);
            date.GetDateTimeFormats('u');
            match_date = date.ToString("yyyy-MM-dd");

            textBox_date.Text = match_date;
        }
    }
}
