using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace HMS_Project
{
    public partial class PatientCRUD : UserControl
    {
        public PatientCRUD()
        {
            InitializeComponent();
            //doctorList();
            display();
        }
        int PatID;

        //public void doctorList()
        //{
        //    DatabaseOps databaseOps = new DatabaseOps();
        //    DataTable dataTable = new DataTable();
        //    dataTable = databaseOps.doctorList();
        //    comboBoxDOCID.DataSource = dataTable;
        //    comboBoxDOCID.ValueMember = "ID";
        //    comboBoxDOCID.DisplayMember = "DOC_NAME";
        //}

        public void display()
        {
            operation op = new operation();
            dataGridView1.DataSource = op.display("PATIENTS");
        }

        private void buttonPATInsert_Click(object sender, EventArgs e)
        {
            patient pat = new patient()
            {
                Name = textBoxPATName.Text,
                Gender = comboBoxPATGender.Text,
                Tel = textBoxPATTel.Text,
                CreatedBy = int.Parse(employeeid.Text),
                Date = dateTimePicker1.Value,
                Email = emailt.Text,
                Pass = "000",
                Address = textBoxPATAddress.Text,
            };

            pat.insertpatient(pat.Name, pat.Tel, pat.Email, pat.Gender, pat.Address, pat.CreatedBy, pat.Date);
            display();
        }

        private void buttonPATDelete_Click(object sender, EventArgs e)
        {
            if (textBoxPATID.Text.Length != 0)
            {
                patient pat = new patient();
                pat.deletepatient(PatID);
                MessageBox.Show("Delete Successfully", "DELETED", MessageBoxButtons.OK);
                display();
            }
            else
            {
                MessageBox.Show("Unable to delete Data, Select a row which you want to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            display();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PatID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBoxPATID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxPATName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            if (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "Male")
            {
                comboBoxPATGender.Text = "Male";
            }
            else
            {
                comboBoxPATGender.Text = "Female";
            }
            textBoxPATTel.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            emailt.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            employeeid.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[8].Value);
            textBoxPATAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void buttonPATUpdate_Click(object sender, EventArgs e)
        {
            patient pat = new patient()
            {
                ID = textBoxPATID.Text,
                Name = textBoxPATName.Text,
                Gender = comboBoxPATGender.Text,
                Tel = textBoxPATTel.Text,
                Date = dateTimePicker1.Value,
                CreatedBy = int.Parse(employeeid.Text),
                Email = emailt.Text,
                Address = textBoxPATAddress.Text,
            };
            pat.updatepatient(pat.ID, pat.Name, pat.Tel, pat.Email, pat.Gender, pat.Address, pat.CreatedBy, pat.Date);
            display();
        }

        private void textBoxSearchVal_TextChanged(object sender, EventArgs e)
        {
            operation op = new operation();
            dataGridView1.DataSource = op.search("PATIENTS", textBoxSearchVal.Text, comboBoxSearchBy.Text);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
