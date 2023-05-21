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
    public partial class DoctorsAppointmentUserControl : UserControl
    {
        public DoctorsAppointmentUserControl()
        {
            InitializeComponent();
           dateTimePicker1.Value = DateTime.Today;

        }

        public string ID { get; set; }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
