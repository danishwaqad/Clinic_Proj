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
    public class CompDiscDB
    {
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();

        //==========All Companies Discount Data Insert===================
        public void Add_record(CompanyDiscMod rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Update_CompanyDisc_Setup", "@Discount3,@Discount4,@IsAllow,@LoginID", rs.Discount3,rs.Discount4,rs.IsAllow,rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //===========Display All Companies Data by lookup=============
        public DataSet get_record()
        {
            try
            {
                ds = help.ReturnDataSetProcedure("UD_Discount_get");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //==============All Companies Discount Data Update============
        public void update_record(CompanyDiscMod rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Update_CompanyDisc_Setup", "@Discount3,@Discount4,@IsAllow,@LoginID", rs.Discount3, rs.Discount4, rs.IsAllow,rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Delete All Companies Discount==============
        public void deletedata(CompanyDiscMod rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_CompanyDiscount", "@ID", rs.CompanyID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}