using System;
using System.Threading;
using System.Windows.Forms;

namespace HMS_Project
{
    static class Program
    {
        private static Mutex mutex = new Mutex(true, "HMS_Project_Mutex");

        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new doctor_login());
                mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("Another instance of the application is already running.");
            }
        }
    }
}

