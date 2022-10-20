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
    public class ObEditDB
    {
        string RtnJS;
        string Query;
        DataTable dt = new DataTable();
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();


        //=========Get Rs Note==========
        public string Get_RsNote_List()
        {
            try
            {
                Query = "SELECT * FROM VW_RSNo_OB_Detail";
                dt = help.Return_DataTable_Query(Query);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        //=============Display doc Data Get By ID================
        public string get_recordid(OB_EditMode rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Sp_VwDoc_CloseData_byID", "@DocNo,@DivisionID,@SiteID", rs.DocNo, rs.DivisionID, rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Display OB Look up Data===================
        public string get_DocrecordLokup(OB_EditMode rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("UD_Doc_Lookup", "@DivisionID,@SiteID", rs.DivisionID, rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Add_DCrecord(OB_EditMode DM)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Update_OB_Detail", "@DocNo,@DocDate,@RsNote,@Qty,@Total,@Opening,@DivisionID,@SiteID,@LoginID,@Remarks", DM.DocNo, DM.DocDate, DM.RsNote, DM.Quantity, DM.Total,DM.Opening, DM.DivisionID, DM.SiteID, DM.LoginID, DM.Remarks);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public void RptAdd_DCrecord(OB_EditMode DM)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Update_OB_Close", "@DocNo,@DocDate,@RsNote,@Qty,@Total,@Consultancy,@FirstAid,@Session,@LoginID,@DivisionID,@SiteID,@Remarks", DM.DocNo, DM.DocDate, DM.RsNote, DM.Quantity, DM.Total, DM.Consultancy, DM.FirstAid,DM.Session, DM.LoginID,DM.DivisionID,DM.SiteID,DM.Remarks);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        //============Delete record==================
        public void deletedata(OB_EditMode DM)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_OB", "@Code,@DivisionID,@SiteID", DM.DocNo, DM.DivisionID,DM.SiteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}