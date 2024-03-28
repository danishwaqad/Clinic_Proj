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
    public class ReportsDb
    {
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        //==============Get Charges Total By ID For Clinic============
        public string get_ChargesClinic(ReportsModel rs)
        {
            try
            {
                string RtnJS;
                DataTable dt = new DataTable();
                dt = help.ReturnParameterizedDataTableProcedure("UD_Manage_Report_Total_Balance", "@SiteFrom,@SiteTo,@Doctor,@DateFrom,@DateTo,@LoginID", rs.SiteFrom, rs.SiteTo,rs.DoctorNam,rs.DateFrom, rs.DateTo,rs.LoginID);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        //==============Get Charges Total By ID For Session============
        public string get_ChargesSession(ReportsModel rs)
        {
            try
            {
                string RtnJS;
                DataTable dt = new DataTable();
                dt = help.ReturnParameterizedDataTableProcedure("UD_Session_Report_Total_Balance", "@SiteFrom,@SiteTo,@Doctor,@DateFrom,@DateTo,@LoginID", rs.SiteFrom, rs.SiteTo, rs.DoctorNam, rs.DateFrom, rs.DateTo, rs.LoginID);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        //==============Get Charges Total By ID For First Aid============
        public string get_ChargesFirstAid(ReportsModel rs)
        {
            try
            {
                string RtnJS;
                DataTable dt = new DataTable();
                dt = help.ReturnParameterizedDataTableProcedure("UD_Management_FirstAid_Total_SUM", "@SiteFrom,@SiteTo,@DateFrom,@DateTo,@Doctor,@LoginID ", rs.SiteFrom, rs.SiteTo, rs.DateFrom, rs.DateTo,rs.DoctorNam,rs.LoginID);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        //==============Get Charges Total By ID For Monthly============
        public string get_ChargesMonthly(ReportsModel rs)
        {
            try
            {
                string RtnJS;
                DataTable dt = new DataTable();
                dt = help.ReturnParameterizedDataTableProcedure("UD_Management_Monthly_Total_SUM", "@SiteFrom,@SiteTo,@DateFrom,@DateTo,@Doctor,@LoginID ", rs.SiteFrom, rs.SiteTo, rs.DateFrom, rs.DateTo, rs.DoctorNam, rs.LoginID);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        //Display Clinic all View data
        public string ViewClinicData(ReportsModel rs)
        {
            try
            {
                string RtnJS;
                DataTable dt = new DataTable();
                dt = help.ReturnParameterizedDataTableProcedure("UD_ClinicRpt_ForManagement", "@SiteFrom,@SiteTo,@Doctor,@DateFrom,@DateTo,@LoginID", rs.SiteFrom, rs.SiteTo,rs.DoctorNam, rs.DateFrom, rs.DateTo,rs.LoginID);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        //Display Session all View data
        public string ViewSessionData(ReportsModel rs)
        {
            try
            {
                string RtnJS;
                DataTable dt = new DataTable();
                dt = help.ReturnParameterizedDataTableProcedure("UD_SessionRpt_ForManagement", "@SiteFrom,@SiteTo,@Doctor,@DateFrom,@DateTo,@LoginID", rs.SiteFrom, rs.SiteTo, rs.DoctorNam, rs.DateFrom, rs.DateTo, rs.LoginID);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        //Display First Aid all View data
        public string ViewFirstAidData(ReportsModel rs)
        {
            try
            {
                string RtnJS;
                DataTable dt = new DataTable();
                dt = help.ReturnParameterizedDataTableProcedure("UD_Profit_Summary_FirstAid_ForManagement", "@SiteFrom,@SiteTo,@DateFrom,@DateTo,@Doctor,@LoginID", rs.SiteFrom, rs.SiteTo, rs.DateFrom, rs.DateTo,rs.DoctorNam,rs.LoginID);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        //Display Monthly all View data 
        public string ViewMonthlyData(ReportsModel rs)
        {
            try
            {
                string RtnJS;
                DataTable dt = new DataTable();
                dt = help.ReturnParameterizedDataTableProcedure("UD_rpt_Doctor_Revenue_Sharing", "@SiteFrom,@SiteTo,@DateFrom,@DateTo,@DrFrom,@DrTo", rs.SiteFrom, rs.SiteTo, rs.DateFrom, rs.DateTo, rs.DoctorNam, rs.DoctorNam);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
    }
}