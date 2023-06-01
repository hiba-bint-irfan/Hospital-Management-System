using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class doctor : connection
    {
        public override void log(string username, string pass)
        {
            storedProcedure = "sp_LogDoctor";
            base.log(username, pass);
        }
    }
}
