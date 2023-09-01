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
    public partial class players_change : Form
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
                        "6.Введите количество отданных пасов.\r\n", "Несоответствие форме изменения записи");
            }
            else
            {
                matches = Int32.Parse(textBox_matches.Text);
                goals = Int32.Parse(textBox_total_goals.Text);
                passes = Int32.Parse(textBox_passes.Text);
                goals_plus_passes = goals + passes;
                MySqlCommand cmd = new MySqlCommand("update players set `name` = @name, lastname = @lastname, date_of_birth = @date_of_birth, id_country_nationality = @id_country_nationality, id_position = @id_position, total_matches = @total_matches, `total_goals(scored/missed)` = @total_goals_scored_missed, passes = @passes, `goals+passes` = @goals_passes where idplayers = @id_player;", db.getConnection());
                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBox_name.Text;
                cmd.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = textBox_lastname.Text;
                cmd.Parameters.Add("@date_of_birth", MySqlDbType.VarChar).Value = textBox_birthday.Text;
                cmd.Parameters.Add("@id_country_nationality", MySqlDbType.VarChar).Value = comboBox_country.SelectedValue;
                cmd.Parameters.Add("@id_position", MySqlDbType.VarChar).Value = comboBox_position.SelectedValue;
                cmd.Parameters.Add("@total_matches", MySqlDbType.VarChar).Value = matches;
                cmd.Parameters.Add("@total_goals_scored_missed", MySqlDbType.VarChar).Value = goals;
                cmd.Parameters.Add("@passes", MySqlDbType.VarChar).Value = passes;
                cmd.Parameters.Add("@goals_passes", MySqlDbType.VarChar).Value = goals_plus_passes;
                cmd.Parameters.Add("@id_player", MySqlDbType.VarChar).Value = players.id_player;

                db.openConnection();
                if (textBox_name.Text == "" || textBox_lastname.Text == "" || textBox_matches.Text == "" || textBox_total_goals.Text == "" || textBox_passes.Text == "" || textBox_birthday.Text == "")
                {
                    MessageBox.Show("1.Введите имя игрока.\r\n" +
                        "2.Введите фамилию игрока.\r\n" +
                        "3.Введите дату рождения игрока.\r\n" +
                        "4.Введите количество сыгранных матчей.\r\n" +
                        "5.Введите количество забитых/пропущенных мячей.\r\n" +
                        "6.Введите количество отданных пасов.\r\n", "Несоответствие форме изменения записи");
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

        int id_country, id_position, matches, goals, passes, goals_plus_passes;
        public players_change()
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

        private void players_change_Load(object sender, EventArgs e)
        {
            MySqlConnection name_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_name = new MySqlCommand("select name from players where idplayers = @id_player;", name_connection);
            command_name.Parameters.Add("@id_player", MySqlDbType.VarChar).Value = players.id_player;
            name_connection.Open();

            name = command_name.ExecuteScalar().ToString();
            name_connection.Close();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection lastname_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_lastname = new MySqlCommand("select lastname from players where idplayers = @id_player;", lastname_connection);
            command_lastname.Parameters.Add("@id_player", MySqlDbType.VarChar).Value = players.id_player;
            lastname_connection.Open();

            lastname = command_lastname.ExecuteScalar().ToString();
            lastname_connection.Close();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection date_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_date = new MySqlCommand("select date_of_birth from players where idplayers = @id_player;", date_connection);
            command_date.Parameters.Add("@id_player", MySqlDbType.VarChar).Value = players.id_player;
            date_connection.Open();

            birthday = command_date.ExecuteScalar().ToString();

            date = DateTime.Parse(birthday);
            date.GetDateTimeFormats('u');
            birthday = date.ToString("yyyy-MM-dd");

            date_connection.Close();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection country_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_country = new MySqlCommand("select id_country_nationality from players where idplayers = @id_player;", country_connection);
            command_country.Parameters.Add("@id_player", MySqlDbType.VarChar).Value = players.id_player;
            country_connection.Open();

            help = command_country.ExecuteScalar().ToString();
            id_country = Int32.Parse(help);
            country_connection.Close();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection positions_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_positions = new MySqlCommand("select id_position from players where idplayers = @id_player;", positions_connection);
            command_positions.Parameters.Add("@id_player", MySqlDbType.VarChar).Value = players.id_player;
            positions_connection.Open();

            help = command_positions.ExecuteScalar().ToString();
            id_position = Int32.Parse(help);
            positions_connection.Close();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection matches_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_matches = new MySqlCommand("select total_matches from players where idplayers = @id_player;", matches_connection);
            command_matches.Parameters.Add("@id_player", MySqlDbType.VarChar).Value = players.id_player;
            matches_connection.Open();

            help = command_matches.ExecuteScalar().ToString();
            matches = Int32.Parse(help);
            matches_connection.Close();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection goals_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_goals = new MySqlCommand("select `total_goals(scored/missed)` from players where idplayers = @id_player;", goals_connection);
            command_goals.Parameters.Add("@id_player", MySqlDbType.VarChar).Value = players.id_player;
            goals_connection.Open();

            help = command_goals.ExecuteScalar().ToString();
            goals = Int32.Parse(help);
            goals_connection.Close();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            MySqlConnection passes_connection = new MySqlConnection(myConnectionString);
            MySqlCommand command_passes = new MySqlCommand("select passes from players where idplayers = @id_player;", passes_connection);
            command_passes.Parameters.Add("@id_player", MySqlDbType.VarChar).Value = players.id_player;
            passes_connection.Open();

            help = command_passes.ExecuteScalar().ToString();
            passes = Int32.Parse(help);
            passes_connection.Close();

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            textBox_name.Text = name;
            textBox_lastname.Text = lastname;
            textBox_matches.Text = matches.ToString();
            textBox_passes.Text = passes.ToString();
            textBox_total_goals.Text = goals.ToString();
            comboBox_country.SelectedValue = id_country;
            comboBox_position.SelectedValue = id_position;
            textBox_birthday.Text = birthday;

            label_id.Text = players.id_player.ToString();
        }
    }
}
