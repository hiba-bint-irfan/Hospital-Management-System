using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS_Project
{
    public partial class CrudEmployee : UserControl
    {
        public CrudEmployee()
        {
            InitializeComponent();
            display();
            
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            //Employee doctor = new Employee()
            //{
            //    Name = textBoxName.Text,
            //    Gender = comboBoxGender.Text,
            //    Designation = rolecbx.SelectedItem.ToString(),
            //    Department = depcbx.SelectedItem.ToString(),
            //    Pass = password.Text,
            //    Email = textBoxEmail.Text,
            //    Address = textBoxAddress.Text,
            //    Tel = textBoxTel.Text
            //};
            //DatabaseOps insertemp= new DatabaseOps();
            //insertemp.insert(doctor);
            //display();
        }

        public void display()
        {
            //DatabaseOps insertRoom = new DatabaseOps();
            //dataGridView1.DataSource = insertRoom.display("ROOM");
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            //Employee doctor = new Employee()
            //{
                //ID = textBoxid.Text,
            //    Name = textBoxName.Text,
            //    Gender = comboBoxGender.Text,
            //    Designation = rolecbx.SelectedItem.ToString(),
            //    Pass = password.Text,
            //    Department = depcbx.SelectedItem.ToString(),
            //    Email = textBoxEmail.Text,
            //    Address = textBoxAddress.Text,
            //    Tel = textBoxTel.Text
            //};
            //DatabaseOps updateDoc = new DatabaseOps();
            //updateDoc.update(doctor);
            //display();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (textBoxid.Text.Length != 0)
            {
                //DatabaseOps databaseOps = new DatabaseOps();
                //databaseOps.delete("EMPLOYEE", textBoxid.Text);
                //display();
            }
            else
            {
                MessageBox.Show("Unable to delete Data, Select a row which you want to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDisplay_Click(object sender, EventArgs e)
        {
            //display();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {


        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBoxid.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "Male")
            {
                comboBoxGender.Text = "Male";
            }
            else
            {
                comboBoxGender.Text = "Female";
            }
            password.Text= dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            depcbx.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBoxTel.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBoxEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            
            textBoxAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            rolecbx.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();

        }

        private void Content_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
