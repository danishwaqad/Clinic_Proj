using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Clinic_Proj.Database_Access
{
    public class APIdb
    {
        DataTable dt = new DataTable();
        DB_Helper help = new DB_Helper();
        public DataTable GetPath()
        {
            try
            {
                string Query = @"SELECT * from VW_RootAPI";
                dt = help.Return_DataTable_Query(Query);
                return dt;
                //RtnJS = JsonConvert.SerializeObject(dt);
                //return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}