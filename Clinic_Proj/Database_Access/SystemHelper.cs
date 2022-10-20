using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Net;
namespace Clinic_Proj.Database_Access
{
    public static class SystemHelper
    {
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static string Name { get; set; }
        public static string CNIC { get; set; }
        public static string SiteID { get; set; }
        public static string DivisionID { get; set; }
        public static string IPAddress { get; set; }
        public static string HostName { get; set; }

        public static string dbID { get; set; }
        public static string dbPass { get; set; }
        public static string ReportPath { get; set; }

        public static string LoginType { get; set; }

        public static string DoctorID { get; set; }

        public static DataTable Business_Setting()
        {
            try
            {
                DataTable dt = new DataTable();
                string Query = "SELECT * FROM VW_Business_Setting WHERE SiteID = '" + SystemHelper.Get_SiteID_Session() + "'";
                DB_Helper help = new DB_Helper();
                dt = help.Return_DataTable_Query(Query);
                return dt;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static string Get_User_Session()
        {
            try
            {
                return HttpContext.Current.Session["UserID"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string Get_UserType_Session()
        {
            try
            {
                return HttpContext.Current.Session["UserType"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string Get_SiteID_Session()
        {
            try
            {
                return HttpContext.Current.Session["SiteID"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string Get_SiteName_Session()
        {
            try
            {
                return HttpContext.Current.Session["SiteName"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string Get_DivisionID_Session()
        {
            try
            {
                return HttpContext.Current.Session["DivisionID"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string Get_DoctorID_Session()
        {
            try
            {
                return HttpContext.Current.Session["DoctorID"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string Get_CNIC_Session()
        {
            try
            {
                return HttpContext.Current.Session["CNIC"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string Get_Token_Session()
        {
            try
            {
                return HttpContext.Current.Session["TokenNo"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string Get_TokenTyp_Session()
        {
            try
            {
                return HttpContext.Current.Session["TokenType"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string Get_Panal_CNIC_Session()
        {
            try
            {
                return HttpContext.Current.Session["PanalCNIC"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}