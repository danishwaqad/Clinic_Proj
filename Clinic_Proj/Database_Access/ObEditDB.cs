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
        //=============Get Consultancy and First Aid Data=============
        public string get_CF(OB_EditMode DM)
        {
            try
            {
                dt = new DataTable();
                Query = "Select * From VW_Today_Day_Closing_Balance where SiteID= '" + DM.SiteID + "' and DivisionID='" + DM.DivisionID + "' and DocNo='" + DM.DocNo + "' ";
                dt = help.Return_DataTable_Query(Query);
                RtnJS = JsonConvert.SerializeObject(dt);
                return RtnJS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Display doc Data Get By ID================
        public string get_recordid(OB_EditMode rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Sp_View_OB_Close_byID", "@DocNo,@DivisionID,@SiteID", rs.DocNo, rs.DivisionID, rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Display Document Data Get By ID If Consultancy Fa Session Or DocPayment Not Available================
        public string get_Narecordid(OB_EditMode rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("UD_OB_Header_byID", "@DocNo,@DivisionID,@SiteID", rs.DocNo, rs.DivisionID, rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Display Rs Note Data Get By ID================
        public string get_RsNoterecordid(OB_EditMode rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("Sp_View_OB_Detail_byID", "@DocNo,@DivisionID,@SiteID", rs.DocNo, rs.DivisionID, rs.SiteID);
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
                help.ExecuteParameterizedProcedure("UD_Update_OB_Detail", "@DocNo,@DocDate,@RsNote,@Qty,@Total,@Opening,@DivisionID,@SiteID,@LoginID,@Remarks", DM.DocNo, DM.DocDate, DM.RsNote, DM.Quantity, DM.Total,DM.Opening, DM.DivisionID, DM.SiteID, DM.LoginID, DM.LineRemarks);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public void Add_Closerecord(OB_EditMode DM)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Insert_New_OB_Close", "@DocNo,@DocDate,@StaffShift,@DivisionID,@SiteID,@LoginID", DM.DocNo, DM.DocDate,DM.StaffShift, DM.DivisionID, DM.SiteID, DM.LoginID);
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
                help.ExecuteParameterizedProcedure("UD_Update_New_OB_Close", "@DocNo,@DocDate,@TypeID,@TotalAmount,@StaffShift,@LoginID,@DivisionID,@SiteID", DM.DocNo, DM.DocDate, DM.TypeID, DM.TotalAmount, DM.StaffShift,DM.LoginID,DM.DivisionID,DM.SiteID);
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