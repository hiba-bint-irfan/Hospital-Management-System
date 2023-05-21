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
    public partial class DoctorsPatientListControl : UserControl
    {

        public string ID { get; set; }

        public DoctorsPatientListControl(string id)
        {
            InitializeComponent();
            ID = id;
        }

        private void dataGridViewINP_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBoxInpatientID.Text = dataGridViewINP.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxPatientName.Text = dataGridViewINP.Rows[e.RowIndex].Cells[2].Value.ToString();
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
