using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Xml;
using BLL;

namespace HMS_Project
{
    public partial class CRUDDoctor : UserControl
    {
        public CRUDDoctor()
        {
            InitializeComponent();
            display();
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker2.Format = DateTimePickerFormat.Time;
            dateTimePicker2.ShowUpDown = true;

        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {

            DoctorInfo doctor = new DoctorInfo()
            {
                Name = textBoxName.Text,
                Gender = comboBoxGender.Text,
                Designation = rolecbx.SelectedItem.ToString(),
                Department = depcbx.SelectedItem.ToString(),
                Email = textBoxEmail.Text,
                Password = textBoxPass.Text,
                Address = textBoxAddress.Text,
                Tel = textBoxTel.Text,
                starttime = dateTimePicker1.Value,
                endtime = dateTimePicker2.Value,
                PricePerAppointment = int.Parse(priceperappointment.Text),
            };
            doctor insertDoc = new doctor();
            insertDoc.insertDoc(doctor.Name, doctor.Department, doctor.Tel, doctor.Email, doctor.Password, doctor.Gender, doctor.Address, doctor.Designation, doctor.PricePerAppointment);
            display();
            //doctor.addEmployee(doctor);
        }

        private void buttonDisplay_Click(object sender, EventArgs e)
        {
            display();
            doctor d = new doctor();
            DataTable data = d.SelectDoc();
            dataGridView1.DataSource = data;
        }
        int DoctorID;
        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            display();
            DoctorID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBoxid.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            depcbx.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBoxTel.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBoxEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString() == "Male")
            {
                comboBoxGender.Text = "Male";
            }
            else
            {
                comboBoxGender.Text = "Female";
            }
            textBoxAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            rolecbx.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            priceperappointment.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();


        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            DoctorInfo doctor = new DoctorInfo()
            {
                ID = textBoxid.Text,
                Name = textBoxName.Text,
                Gender = comboBoxGender.Text,
                Designation = rolecbx.SelectedItem.ToString(),
                Department = depcbx.SelectedItem.ToString(),
                Email = textBoxEmail.Text,
                Address = textBoxAddress.Text,
                Password = textBoxPass.Text,
                Tel = textBoxTel.Text,
                starttime = dateTimePicker1.Value,
                endtime = dateTimePicker2.Value,
                PricePerAppointment = int.Parse(priceperappointment.Text),
            };
            doctor updateDoc = new doctor();
            //updateDoc.DeleteTimeSlots(DoctorID);
            updateDoc.updateDoc(doctor.ID, doctor.Name, doctor.Department, doctor.Tel, doctor.Email, doctor.Password, doctor.Gender, doctor.Address, doctor.Designation, doctor.PricePerAppointment);
            display();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (textBoxid.Text.Length != 0)
            {

                //databaseOps.DeleteTimeSlots(DoctorID);


                doctor d = new doctor();
                d.deleteDoc(DoctorID);
                MessageBox.Show("Delete Successfully", "DELETED", MessageBoxButtons.OK);
                display();

            }
            else
            {
                MessageBox.Show("Unable to delete Data, Select a row which you want to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void display()
        {
            doctor d = new doctor();
            operation op = new operation();
            dataGridView1.DataSource = op.display("DOCTORS");
            op.Showincbx(depcbx, "Department", "DepartmentName");
            op.Showincbx(rolecbx, "DoctorRoles", "Rolename");


        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            operation op = new operation();
            dataGridView1.DataSource = op.search("DOCTORS", textBoxSearch.Text, comboBoxSearchBy.Text);
        }

        private void Content_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
