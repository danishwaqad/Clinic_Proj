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
    public class Divdb
    {

        DB_Helper help = new DB_Helper();
        //============Insert Division Data===================
        public void Add_record(register rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Division", "@ID,@Name,@Address,@Tel,@Mobile1,@Mobile2,@City,@Country,@Remarks,@Status,@LoginID", rs.DivisionCode, rs.DivisionName, rs.Address, rs.Tel, rs.Mobile1, rs.Mobile2, rs.City, rs.Country, rs.Remarks, rs.InActive, rs.LoginID);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //===============Display all Division DT record==============
        public DataSet get_record()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnDataSetProcedure("Sp_Division_get");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===============Update Division=====================
        public void update_record(register rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Division", "@ID,@Name,@Address,@Tel,@Mobile1,@Mobile2,@City,@Country,@Remarks,@Status,@LoginID", rs.DivisionCode, rs.DivisionName, rs.Address, rs.Tel, rs.Mobile1, rs.Mobile2, rs.City, rs.Country, rs.Remarks, rs.InActive, rs.LoginID);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        //==================Get Record By iD==================
        public string get_recordbyid(register rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Sp_Division_byid", "@ID", rs.DivisionCode);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //============Delete Division record==================
        public void deletedata(register rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_Division", "@Code", rs.DivisionCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}