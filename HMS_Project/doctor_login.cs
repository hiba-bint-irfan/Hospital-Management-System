using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BLL;

namespace HMS_Project
{
    public partial class doctor_login : Form
    {
        public doctor_login()
        {
            InitializeComponent();
        }
        employee_login l = new employee_login();
        private void button1_Click(object sender, EventArgs e)
        {
            Regex validateEmailRegex = new Regex("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");

            if (textBoxPass.Text.Length != 0 && textBoxUsername.Text.Length != 0)
            {
                if (validateEmailRegex.IsMatch(textBoxUsername.Text) == true)
                {
                    doctor doc = new doctor();
                    doc.log(textBoxUsername.Text, textBoxPass.Text);

                    if (doc.log_check == true)
                    {
                        MessageBox.Show("Successfully Login");
                        Info.Role = "Doctor";
                        DashBoard dashBoard = new DashBoard();
                        dashBoard.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Email and pass.....");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Email.....");
                }
            }
            else
            {
                textboxError.Visible = true;
                button1.BackColor = Color.FromArgb(textboxError.ForeColor.ToArgb());
            }



        }


        private void doctor_login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            employee_login emp_log = new employee_login();
            emp_log.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
