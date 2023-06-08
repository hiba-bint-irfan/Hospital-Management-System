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
    public partial class DoctorsAppointmentUserControl : UserControl
    {
        public DoctorsAppointmentUserControl()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Today;
            display();

        }

        public string ID { get; set; }

        public void display()
        {
            appointment op = new appointment();
            dataGridViewINP.DataSource = op.doctorAppointment();
        }

        public void patientList()
        {

            appointment databaseOps = new appointment();
            DataTable dataTable = new DataTable();
            dataTable = databaseOps.patientList();
            comboBoxpatient.DataSource = dataTable;
            comboBoxpatient.DisplayMember = "PAT_NAME";
            comboBoxpatient.ValueMember = "ID";
        }

        public void DoctorList()
        {

            appointment databaseOps = new appointment();
            comboBoxDoctor.DataSource = databaseOps.doctorList(); ;
            comboBoxDoctor.DisplayMember = "DOC_NAME";
            comboBoxDoctor.ValueMember = "ID";
        }

        public void TimeSlotlist()
        {
            //comboBoxslots.Items.Clear();    
            appointment op = new appointment();
            comboBoxslots.DataSource = op.timeslotlist(Convert.ToInt32(comboBoxDoctor.SelectedValue.ToString())); ;
            comboBoxslots.DisplayMember = "slotdec";
            comboBoxslots.ValueMember = "id";
        }

        private void DoctorsAppointmentUserControl_Load(object sender, EventArgs e)
        {
            display();
            patientList();
            DoctorList();
        }

        private void dataGridViewINP_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            comboBoxDoctor.Text = "";
            comboBoxpatient.Text = "";
            comboBoxslots.Text = "";
            textBoxAppointmentID.Text = dataGridViewINP.Rows[e.RowIndex].Cells[0].Value.ToString();
            comboBoxDoctor.Text = dataGridViewINP.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBoxpatient.Text = dataGridViewINP.Rows[e.RowIndex].Cells[2].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridViewINP.Rows[e.RowIndex].Cells[3].Value.ToString());
            comboBoxslots.Text = "";
            comboBoxslots.Text = dataGridViewINP.Rows[e.RowIndex].Cells[4].Value.ToString();



        }

        private void buttonCancelAppointment_Click(object sender, EventArgs e)
        {
            if (textBoxAppointmentID.Text.Length != 0)
            {

                appointment op = new appointment();

                int oldslotid = op.gettimeslotidfromappointment(textBoxAppointmentID.Text);
                op.updatetimeslotavailability(oldslotid, 1);
                op.deleteappoint(textBoxAppointmentID.Text);
                display();
            }
            else
            {
                MessageBox.Show("Unable to Cancel Appointment, Select a row which you want to Cancel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonReschedule_Click(object sender, EventArgs e)
        {
            appointment appointment = new appointment();
            appointment.AppointmentID = textBoxAppointmentID.Text;
            appointment.AppointmentDate = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            appointment.TimeslotID = Convert.ToInt32(comboBoxslots.SelectedValue.ToString());
            appointment.DoctorID = Convert.ToInt32(comboBoxDoctor.SelectedValue.ToString());
            appointment.PatientID = Convert.ToInt32(comboBoxpatient.SelectedValue.ToString());
            appointment update = new appointment();
            int oldslotid = update.gettimeslotidfromappointment(appointment.AppointmentID);
            update.updatetimeslotavailability(oldslotid, 1);
            update.updateappoint(appointment.AppointmentID, appointment.AppointmentDate, appointment.TimeslotID, appointment.PatientID, appointment.DoctorID);
            update.updatetimeslotavailability(appointment.TimeslotID, 0);
            display();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBoxDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxDoctor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TimeSlotlist();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            appointment appointment = new appointment();
            appointment.AppointmentDate = dateTimePicker1.Value;
            appointment.TimeslotID = Convert.ToInt32(comboBoxslots.SelectedValue.ToString());
            appointment.DoctorID = Convert.ToInt32(comboBoxDoctor.SelectedValue.ToString());
            appointment.PatientID = Convert.ToInt32(comboBoxpatient.SelectedValue.ToString());
            appointment insert = new appointment();
            insert.insertappoint(appointment.AppointmentDate, appointment.TimeslotID, appointment.PatientID, appointment.DoctorID);
            insert.updatetimeslotavailability(appointment.TimeslotID, 0);
            display();

        }
    }
}
