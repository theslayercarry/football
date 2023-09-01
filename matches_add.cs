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
    public partial class matches_add : Form
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
                        "3.Введите дату проведения матча.\r\n", "Несоответствие форме добавления записи");
            }
            else if ((int)comboBox_team1.SelectedValue == (int)comboBox_team2.SelectedValue)
            {
                MessageBox.Show("Произошла ошибка при добавлении матча.");
            }
            else
            {
                team1_score = Int32.Parse(textBox_team1_score.Text);
                team2_score = Int32.Parse(textBox_team2_score.Text);
                viewers = Int32.Parse(textBox_viewers.Text);
                MySqlCommand cmd = new MySqlCommand("insert into matches (id_team1, id_team2, id_referee, team1_score, team2_score, date, number_of_viewers) values\r\n(@id_team1, @id_team2, @id_referee, @team1_score, @team2_score, @date, @number_of_viewers);", db.getConnection());
                cmd.Parameters.Add("@id_team1", MySqlDbType.VarChar).Value = comboBox_team1.SelectedValue;
                cmd.Parameters.Add("@id_team2", MySqlDbType.VarChar).Value = comboBox_team2.SelectedValue;
                cmd.Parameters.Add("@id_referee", MySqlDbType.VarChar).Value = comboBox_referee.SelectedValue;
                cmd.Parameters.Add("@team1_score", MySqlDbType.VarChar).Value = team1_score;
                cmd.Parameters.Add("@team2_score", MySqlDbType.VarChar).Value = team2_score;
                cmd.Parameters.Add("@date", MySqlDbType.VarChar).Value = maskedTextBox_date.Text;
                cmd.Parameters.Add("@number_of_viewers", MySqlDbType.VarChar).Value = viewers;

                db.openConnection();
                if (textBox_team1_score.Text == "" || textBox_team2_score.Text == "" || textBox_viewers.Text == "" || maskedTextBox_date.MaskCompleted == false)
                {
                    MessageBox.Show("1.Введите результат встречи команд.\r\n" +
                        "2.Введите количество зрителей у данного матча.\r\n" + "" +
                        "3.Введите дату проведения матча.\r\n", "Несоответствие форме добавления записи");
                }
                else if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Матч '" + comboBox_team1.Text + " - " + comboBox_team2.Text + "' успешно добавлен.", "Добавление матча...");

                    db.closeConnection();

                }
                else
                {
                    MessageBox.Show("Произошла ошибка при добавлении матча.", "Ошибка при добавлении...");
                }
            }
                
        }

        DateTime date;
        public matches_add()
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

            textBox_team1_score.Text = "0";
            textBox_team2_score.Text = "0";
        }

        private void matches_add_Load(object sender, EventArgs e)
        {
            textBox_team1_score.Text = "0";
            textBox_team2_score.Text = "0";
            textBox_viewers.Text = "0";

            maskedTextBox_date.Mask = "0000-00-00";
            maskedTextBox_date.ValidatingType = typeof(DateTime);
        }
    }
}
