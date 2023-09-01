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
    public partial class other_tables : Form
    {
        public other_tables()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void label_matches_Click(object sender, EventArgs e)
        {
            matches frm1 = new matches();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void label_players_Click(object sender, EventArgs e)
        {
            players frm1 = new players();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void label_teams_Click(object sender, EventArgs e)
        {
            teams frm1 = new teams();
            this.Hide();
            frm1.ShowDialog();
            this.Show();
        }

        private void other_tables_Load(object sender, EventArgs e)
        {

        }
    }
}
