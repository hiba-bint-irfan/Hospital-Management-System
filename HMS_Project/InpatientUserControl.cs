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
    public partial class InpatientUserControl : UserControl
    {
        public InpatientUserControl()
        {
            InitializeComponent();
            patientList();
            display();

        }


        public void display()
        {
            inpatient pat = new inpatient();
            dataGridViewINP.DataSource = pat.displayInPat();
        }
        public void roomList()
        {
            inpatient pat = new inpatient();
            DataTable dataTable = new DataTable();
            dataTable = pat.roomList(comboBoxRType.Text);
            comboBoxRNo.DataSource = dataTable;
            comboBoxRNo.ValueMember = "ID";
            comboBoxRNo.DisplayMember = "ID";
        }
        public void patientList()
        {
            inpatient pat = new inpatient();
            DataTable dataTable = new DataTable();
            dataTable = pat.patientList();
            comboBoxPatient.DataSource = dataTable;
            comboBoxPatient.DisplayMember = "PAT_NAME";
            comboBoxPatient.ValueMember = "ID";
        }

        private void buttonRoom_Click(object sender, EventArgs e)
        {
            FindRoom findRoom = new FindRoom();
            findRoom.Show();
        }

        private void comboBoxRType_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxRNo.Enabled = true;
            roomList();
        }

        private void buttonRoomInsert_Click(object sender, EventArgs e)
        {
            inpatient inpatient = new inpatient();
            inpatient.PatID = int.Parse(comboBoxPatient.SelectedValue.ToString());
            inpatient.RoomNo = comboBoxRNo.SelectedValue.ToString();
            inpatient.Admission = dateTimePickerDOA.Value.Date;
            inpatient.Discharge = dateTimePickerDOD.Value.Date;
            inpatient.TotalAmount = int.Parse(textBox1.Text);
            if (inpatient.ifinpatientalreadyexisted(inpatient.PatID, inpatient.Admission) == true)
            {
                inpatient.insertPAT(inpatient.Admission, inpatient.Discharge, inpatient.PatID, inpatient.RoomNo, inpatient.TotalAmount);
                
            }
            else
            {
                MessageBox.Show("Unable to Assign room because room already assignes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            display();

        }


        private void buttonRoomUpdate_Click(object sender, EventArgs e)
        {
            inpatient inpatient = new inpatient()
            {
                PatID = int.Parse(comboBoxPatient.SelectedValue.ToString()),
                InPatID = int.Parse(textBoxInpatientID.Text),
                RoomNo = comboBoxRNo.SelectedValue.ToString(),
                Admission = dateTimePickerDOA.Value.Date,
                Discharge = dateTimePickerDOD.Value.Date,
                TotalAmount = int.Parse(textBox1.Text),
            };

            inpatient.updatePAT(inpatient.InPatID,inpatient.Admission,inpatient.Discharge,inpatient.PatID,inpatient.RoomNo,inpatient.TotalAmount);
            display();


        }

        private void textBoxSearchVal_TextChanged(object sender, EventArgs e)
        {
            operation op = new operation();
            dataGridViewINP.DataSource = op.search("INPATIENTS", textBoxSearchVal.Text, comboBoxSearchBy.Text);
        }

        private void dataGridViewINP_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBoxInpatientID.Text = dataGridViewINP.Rows[e.RowIndex].Cells[0].Value.ToString();
            comboBoxPatient.SelectedValue = dataGridViewINP.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBoxPatient.SelectedText = dataGridViewINP.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBoxPhone.Text = dataGridViewINP.Rows[e.RowIndex].Cells[3].Value.ToString();
            dateTimePickerDOA.Value = Convert.ToDateTime(dataGridViewINP.Rows[e.RowIndex].Cells[4].Value);
            dateTimePickerDOD.Value = Convert.ToDateTime(dataGridViewINP.Rows[e.RowIndex].Cells[5].Value);
            comboBoxRNo.Text = dataGridViewINP.Rows[e.RowIndex].Cells[6].Value.ToString();
            comboBoxRType.Text = dataGridViewINP.Rows[e.RowIndex].Cells[7].Value.ToString();
            textBox1.Text = dataGridViewINP.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        private void buttonRoomDelete_Click(object sender, EventArgs e)
        {
            if (textBoxInpatientID.Text.Length != 0)
            {
                inpatient pat = new inpatient();
                int id = int.Parse(textBoxInpatientID.Text);
                pat.deletepat(id);
                display();
            }
            else
            {
                MessageBox.Show("Unable to delete Data, Select a row which you want to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            display();
        }

        private void dataGridViewINP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
          
        }

        private void comboBoxPatient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

  
        
    
}
