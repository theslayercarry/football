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
    public partial class players_add : Form
    {
        Database db = new Database();
        string myConnectionString = "Database=football;Data Source=127.0.0.1;User Id=root;Password=1337";
        String help, name, lastname, birthday;
        DateTime date;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_matches.Text == "" || textBox_total_goals.Text == "" || textBox_passes.Text == "")
            {
                MessageBox.Show("1.Введите имя игрока.\r\n" +
                        "2.Введите фамилию игрока.\r\n" +
                        "3.Введите дату рождения игрока.\r\n" +
                        "4.Введите количество сыгранных матчей.\r\n" +
                        "5.Введите количество забитых/пропущенных мячей.\r\n" +
                        "6.Введите количество отданных пасов.\r\n", "Несоответствие форме добавления записи");
            }
            else
            {
                matches = Int32.Parse(textBox_matches.Text);
                goals = Int32.Parse(textBox_total_goals.Text);
                passes = Int32.Parse(textBox_passes.Text);
                goals_plus_passes = goals + passes;
                MySqlCommand cmd = new MySqlCommand("insert into players (name, lastname, date_of_birth, id_country_nationality, id_position, total_matches, `total_goals(scored/missed)`, passes, `goals+passes`) values\r\n(@name, @lastname, @date_of_birth, @id_country_nationality, @id_position, @total_matches, @total_goals_scored_missed, @passes, @goals_passes);", db.getConnection());
                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBox_name.Text;
                cmd.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = textBox_lastname.Text;
                cmd.Parameters.Add("@date_of_birth", MySqlDbType.VarChar).Value = maskedTextBox_birthday.Text;
                cmd.Parameters.Add("@id_country_nationality", MySqlDbType.VarChar).Value = comboBox_country.SelectedValue;
                cmd.Parameters.Add("@id_position", MySqlDbType.VarChar).Value = comboBox_position.SelectedValue;
                cmd.Parameters.Add("@total_matches", MySqlDbType.VarChar).Value = matches;
                cmd.Parameters.Add("@total_goals_scored_missed", MySqlDbType.VarChar).Value = goals;
                cmd.Parameters.Add("@passes", MySqlDbType.VarChar).Value = passes;
                cmd.Parameters.Add("@goals_passes", MySqlDbType.VarChar).Value = goals_plus_passes;

                db.openConnection();
                if (textBox_name.Text == "" || textBox_lastname.Text == "" || textBox_matches.Text == "" || textBox_total_goals.Text == "" || textBox_passes.Text == "" || maskedTextBox_birthday.MaskCompleted == false)
                {
                    MessageBox.Show("1.Введите имя игрока.\r\n" +
                        "2.Введите фамилию игрока.\r\n" +
                        "3.Введите дату рождения игрока.\r\n" +
                        "4.Введите количество сыгранных матчей.\r\n" +
                        "5.Введите количество забитых/пропущенных мячей.\r\n" +
                        "6.Введите количество отданных пасов.\r\n", "Несоответствие форме добавления записи");
                }
                else if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Игрок '" + textBox_name.Text + " " + textBox_lastname.Text + "' успешно добавлен.", "Добавление игрока...");

                    db.closeConnection();

                }
                else
                {
                    MessageBox.Show("Произошла ошибка при добавлении игрока.", "Ошибка при добавлении...");
                }
            }
        }

        int id_country, id_position, matches, goals, passes, goals_plus_passes;
        public players_add()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            DataTable countries = new DataTable();
            MySqlConnection connection_team1 = new MySqlConnection(myConnectionString);
            {
                MySqlCommand command = new MySqlCommand("select idcountries, name from countries;", connection_team1);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(countries);
            }
            comboBox_country.DataSource = countries;
            comboBox_country.DisplayMember = "name";
            comboBox_country.ValueMember = "idcountries";


            DataTable positions = new DataTable();
            MySqlConnection connection_team2 = new MySqlConnection(myConnectionString);
            {
                MySqlCommand command = new MySqlCommand("select idpositions, title from positions;", connection_team2);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(positions);
            }
            comboBox_position.DataSource = positions;
            comboBox_position.DisplayMember = "title";
            comboBox_position.ValueMember = "idpositions";


            comboBox_position.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_country.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void players_add_Load(object sender, EventArgs e)
        {
            textBox_matches.Text = "0";
            textBox_total_goals.Text = "0";
            textBox_passes.Text = "0";

            maskedTextBox_birthday.Mask = "0000-00-00";
            maskedTextBox_birthday.ValidatingType = typeof(DateTime);
        }
    }
}
