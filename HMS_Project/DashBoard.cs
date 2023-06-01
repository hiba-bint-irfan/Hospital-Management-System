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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        public string ID { get; set; }
        public string Departmental_ID { get; set; }
        employee_login l = new employee_login();
        private void DashBoard_Load(object sender, EventArgs e)
        {

            
            if (Info.Role=="Employee")
            {
                AdminHomeControl homeControl = new AdminHomeControl();
                controlClass.ShowControl(homeControl, Content);
                buttonSettings.Hide();
            }
            else
            {
                DoctorHomeUserControl doctorHomeUserControl = new DoctorHomeUserControl(ID, Departmental_ID);
                controlClass.ShowControl(doctorHomeUserControl, Content);
                buttonBed.Visible = false;
                //buttonDoctor.Visible = false;
            }
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            if (Info.Role=="Employee")
            {
                AdminHomeControl homeControl = new AdminHomeControl();
                controlClass.ShowControl(homeControl, Content);
            }
            else
            {
                DoctorHomeUserControl doctorHomeUserControl = new DoctorHomeUserControl(ID, Departmental_ID);
                controlClass.ShowControl(doctorHomeUserControl, Content);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonCovid_Click(object sender, EventArgs e)
        {
            InpatientUserControl inpatientUser = new InpatientUserControl();
            controlClass.ShowControl(inpatientUser, Content);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Content.Controls[0].SendToBack();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            employee_login login = new employee_login();
            this.Close();
            login.Show();
        }

        private void buttonDoctor_Click(object sender, EventArgs e)
        {
            if (Info.Role =="Employee")
            {
                CRUDDoctor cRUDDoctor = new CRUDDoctor();
                controlClass.ShowControl(cRUDDoctor, Content);
            }
            else
            {
                Docappointment doctorsAppointmentUserControl = new Docappointment(Convert.ToInt32((ID)));
                controlClass.ShowControl(doctorsAppointmentUserControl, Content);
            }
        }

        private void buttonBilling_Click(object sender, EventArgs e)
        {
            //BillingUserControl billingUserControl = new BillingUserControl();
            //ControlClass.ShowControl(billingUserControl, Content);
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            SettingUserControl settingUserControl = new SettingUserControl(ID);
            controlClass.ShowControl(settingUserControl, Content);
        }

        private void buttonPatient_Click_1(object sender, EventArgs e)
        {
            if (Info.Role =="Employee")
            {
                InpatientUserControl inpatientUserControl = new InpatientUserControl();
                controlClass.ShowControl(inpatientUserControl, Content);
            }
            else
            {
                DoctorsPatientListControl doctorsPatientListControl = new DoctorsPatientListControl(ID);
                controlClass.ShowControl(doctorsPatientListControl, Content);
            }
        }

        private void buttonBed_Click(object sender, EventArgs e)
        {
            FindRoom room = new FindRoom();
            controlClass.ShowControl(room, Content);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoctorsAppointmentUserControl appointmentUserControl = new DoctorsAppointmentUserControl();
            appointmentUserControl.Show();
        }


        private void panelHead_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SideBar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
