using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Clinic_Proj.Models;
using Newtonsoft.Json;

namespace Clinic_Proj.Database_Access
{
    public class CnicDetailDb
    {
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        //Display Follow History Record record
        public string GetCNICRecord()
        {
            try
            {
                dt = help.Return_DataTable_Query("SELECT * FROM Vw_CNIC_Detail");
                string Rtn = JsonConvert.SerializeObject(dt);
                return Rtn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}