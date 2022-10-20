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
    public class CalenderDB
    {
        string RtnJS;
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string Query;
        //================Add Calender Events=========================
        public void AddCalender_record(CalenderMode rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Calender_Event", "@title,@start,@end,@cat", rs.title, rs.start, rs.end, rs.className);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Display Calender Data=================
        public DataSet get_Cal_record()
        {
            try
            {
                ds = help.ReturnDataSetProcedure("Vw_Calender_Record");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}