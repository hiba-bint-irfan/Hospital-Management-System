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
    public partial class employee_login : Form
    {
        public employee_login()
        {
            InitializeComponent();
            
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            Regex validateEmailRegex = new Regex("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");
            if (textBoxPass.Text.Length != 0 && textBoxUsername.Text.Length != 0)
            {
                //UserLogin userLogin = new UserLogin()
                //{
                //    Username = textBoxUsername.Text,
                //    Pass = textBoxPass.Text
                //};
                //userLogin.login(userLogin);
                //this.Close();


                if (validateEmailRegex.IsMatch(textBoxUsername.Text) == true)
                {
                    MessageBox.Show("Successfully Login");
                    Info.Role = "Employee";
                    DashBoard dashBoard = new DashBoard();
                    dashBoard.Show();
                    this.Close();

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

        private void employee_login_Load(object sender, EventArgs e)
        {

        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            doctor_login doc_Log = new doctor_login();
            doc_Log.Show();
            this.Close();
        }

        //private void employee_login_Load(object sender, EventArgs e)
        //{
        //    //DatabaseOps db = new DatabaseOps();
        //    //db.makeslotsavailable();

        //}


    }

    public class UserLogin
    {
        public string Username { get; set; }
        public string Pass { get; set; }

        public void login(UserLogin userLogin)
        {
            //DatabaseOps databaseOps = new DatabaseOps();
            //databaseOps.login(userLogin, "");
        }
    }
}
