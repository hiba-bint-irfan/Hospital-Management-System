using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS_Project
{
    public partial class InpatientUserControl : UserControl
    {
        public InpatientUserControl()
        {
            InitializeComponent();

        }


    

        private void buttonRoom_Click(object sender, EventArgs e)
        {
            FindRoom findRoom = new FindRoom();
            findRoom.Show();
        }

        private void comboBoxRType_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxRNo.Enabled = true;
            //roomList();
        }

        private void buttonRoomInsert_Click(object sender, EventArgs e)
        {
            

        }


        private void buttonRoomUpdate_Click(object sender, EventArgs e)
        {
           
          
        }

        private void textBoxSearchVal_TextChanged(object sender, EventArgs e)
        {
   
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
    }

  
        
    
}
