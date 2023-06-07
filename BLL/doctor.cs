using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using System.Windows.Forms;

namespace BLL
{
    public class doctor : connection
    {
        public override void log(string username, string pass)
        {
            storedProcedure = "sp_LogDoctor";
            base.log(username, pass);
        }

        public void insertDoc(string _pName, string _Department, string _Tel, string _Email, string _pass, string _gender, string _Address, string _Designation, int _PricePerAppointment)
        {
            operation op = new operation();
            int Deptid = op.GetIDbyName("Department", _Department, "DepartmentName", "ID");
            int Desgid = op.GetIDbyName("DoctorRoles", _Designation, "Rolename", "ID");
            DAL.Database dalObj = new DAL.Database();
            dalObj.OpenConnection();
            dalObj.LoadSpParameters("sp_InsertDoctor", _pName, Deptid, _Tel, _Email, _pass, _gender, _Address, Desgid, _PricePerAppointment);
            dalObj.ExecuteQuery();
            dalObj.UnLoadSpParameters();
            dalObj.CloseConnection();

        }
        public void deleteDoc(int _id)
        {
            DAL.Database dalObj = new DAL.Database();
            dalObj.OpenConnection();
            dalObj.LoadSpParameters("sp_DeleteDoctor", _id);
            dalObj.ExecuteQuery();
            dalObj.UnLoadSpParameters();
            dalObj.CloseConnection();

        }
        public void updateDoc(string Id, string _pName, string _Department, string _Tel, string _Email, string _pass, string _gender, string _Address, string _Designation, int _PricePerAppointment)
        {
            operation op = new operation();
            int Deptid = op.GetIDbyName("Department", _Department, "DepartmentName", "ID");
            int Desgid = op.GetIDbyName("DoctorRoles", _Designation, "Rolename", "ID");
            DAL.Database dalObj = new DAL.Database();
            dalObj.OpenConnection();
            dalObj.LoadSpParameters("sp_UpdateDoctor", Id, _pName, Deptid, _Tel, _Email, _pass, _gender, _Address, Desgid, _PricePerAppointment);
            dalObj.ExecuteQuery();
            dalObj.UnLoadSpParameters();
            dalObj.CloseConnection();

        }

        public DataTable SelectDoc()
        {
            DAL.Database dalObj = new DAL.Database();
            dalObj.OpenConnection();
            dalObj.LoadSpParameters("sp_GetDoctors");
            dalObj.ExecuteQuery();
            DataTable data = dalObj.GetDataTable();
            dalObj.UnLoadSpParameters();
            dalObj.CloseConnection();

            return data;
        }

        

       

        
    }
}
