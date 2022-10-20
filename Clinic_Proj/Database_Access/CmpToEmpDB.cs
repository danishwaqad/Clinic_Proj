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
    public class CmpToEmpDB
    {
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string Query;
        string RtnJS;
        //Display Company 
        public DataSet get_Comprecord()
        {
            try
            {
                ds = help.ReturnDataSetProcedure("UD_Get_AllCompanies");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Display Company To Employee Record
        public string get_EmpData(CmpToEmpMode rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("UD_Get_AllEmployees", "@CompanyID", rs.CompanyID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Display Employee Dependent Record
        public string get_EmpDepData(CmpToEmpMode rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("UD_Get_AllDependentEmployees", "@EmpID", rs.EmployeeID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}