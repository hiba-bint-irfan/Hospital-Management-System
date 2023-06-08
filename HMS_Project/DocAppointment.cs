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
    public partial class Docappointment : UserControl
    {
        int ID;
        public Docappointment(int ID)
        {
            InitializeComponent();
            this.ID = ID;
            doctor d = new doctor();
            dataGridViewINP.DataSource = d.GetAppointmentofDoctor(this.ID);

        }

        private void comboBoxSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            doctor d = new doctor();
            dataGridViewINP.DataSource = d.GetAppointmentofDoctor(this.ID);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewINP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBoxSearchBy_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if(comboBoxSearchBy.SelectedItem.ToString()== "Current Appointments")
            {
                
            }

            else 
            {

               
            }
           
        }
    }
}
