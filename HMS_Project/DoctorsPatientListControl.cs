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
    public partial class DoctorsPatientListControl : UserControl
    {

        public string ID { get; set; }

        public DoctorsPatientListControl(string id)
        {
            InitializeComponent();
            ID = id;
            display();
        }

        public void display()
        {
            doctor d = new doctor();
            dataGridViewINP.DataSource = d.doctosPatient(ID);
        }

        private void DoctorsPatientListControl_Load(object sender, EventArgs e)
        {
            display();
        }
        private void dataGridViewINP_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void buttonPATDelete_Click(object sender, EventArgs e)
        {
          
        }

        private void textBoxSearchValue_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
