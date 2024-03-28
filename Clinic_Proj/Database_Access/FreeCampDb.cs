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
    public class FreeCampDb
    {
        string Query;
        string RtnJS;
        DataTable dt = new DataTable();
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        //=============Diagnose Data Insert=================
        public void Add_Free_Camp_record(FreeCampMode rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_FreeCampEnt_Setup", "@DoctorID,@DrName,@Status,@DisType,@DisAprov,@Discount,@DivisionID,@SiteID,@LoginID", rs.DoctorID, rs.DrName, rs.Status,rs.DisType,rs.DisAprov,rs.Discount,rs.DivisionID, rs.SiteCode,rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Delete Free Camp=============
        public void delete_FreeCmpdata(FreeCampMode rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_FreeCamp", "@Code", rs.ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Display Free Camp Record record
        public string get_FreeCmprecord()
        {
            try
            {
                Query = "SELECT * FROM Vw_Free_FreeCmp_Detail";
                dt = new DataTable();
                dt = help.Return_DataTable_Query(Query);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
                //return dt;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
    }
}