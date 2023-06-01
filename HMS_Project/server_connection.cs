using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace HMS_Project
{
    public partial class server_con : Form
    {
        public server_con()
        {
            InitializeComponent();
        }

        private void server_con_Load(object sender, EventArgs e)
        {

            connection con = new connection();
            con.check();
            servername_txtbx.Text = con.servername;
            database_txtbx.Text = con.database;
            username_txtbx.Text = con.serverusername;
            server_pass_txtbx.Text = con.serverpass;
        }

        private void connect_Click(object sender, EventArgs e)
        {
            if (servername_txtbx.Text.Length != 0 && database_txtbx.Text.Length != 0 && username_txtbx.Text.Length != 0 && server_pass_txtbx.Text.Length != 0)
            {
                connection con = new connection();
                con.connect(servername_txtbx.Text, database_txtbx.Text, username_txtbx.Text, server_pass_txtbx.Text);
                employee_login emp = new employee_login();
                this.Hide();
                emp.Show();
                
            }
            else
            {
                textboxError.Visible = true;
                connect.BackColor = Color.FromArgb(textboxError.ForeColor.ToArgb());
            }
        }
    }
}
