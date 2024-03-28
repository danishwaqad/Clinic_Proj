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
    public class GraphDb
    {
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        //===================View Graph==========================
        public string get_Graphrecord(GraphMode rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("UD_Get_Site_Sale_ForGraph", "@SiteID", rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===================View Daily Graph==========================
        public string get_DailyGraphrecord(GraphMode rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Today_Sale_For_DashboardGraph", "@SiteID", rs.SiteID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public GraphMode Get_Site_Sale_Graph_Today_Clinic()
        {
            try
            {
                string Query;
                GraphMode response = new GraphMode();
                var categories = new List<string>();
                var series_data = new List<GraphMode.Clinic_Series_Data>();

                help.DatabaseName = "CCPL_HMS";
                Query = "SELECT SiteCode FROM VW_Site_Active_List_ForDashboard";
                DataTable dt_Sites = help.Return_DataTable_Query(Query);

                for (int i = 0; i < dt_Sites.Rows.Count; i++)
                {
                    categories.Add(dt_Sites.Rows[i]["SiteCode"].ToString());
                }

                Query = "SELECT Distinct Designation FROM VW_Today_ByDoctor_Category_ForGraph";
                DataTable dt_Designation = help.Return_DataTable_Query(Query);

                response.categories = categories;

                for (int j = 0; j < dt_Designation.Rows.Count; j++)
                {
                    var data = new List<decimal>();
                    for (int k = 0; k < categories.Count; k++)
                    {
                        Query = "SELECT TotalPatient, TotalPaid FROM VW_Today_ByDoctor_Category_ForGraph where siteid = '" + categories[k] + "' and Designation = '" + dt_Designation.Rows[j]["Designation"].ToString() + "' ";
                        DataTable dt_data = help.Return_DataTable_Query(Query);

                        if (dt_data.Rows.Count > 0)
                        {
                            data.Add(Convert.ToDecimal(dt_data.Rows[0]["TotalPatient"]));
                            //data.Add(Convert.ToDecimal(dt_data.Rows[0]["TotalPaid"]));
                        }
                        else
                        {
                            data.Add(0);
                        }
                    }

                    series_data.Add(new GraphMode.Clinic_Series_Data
                    {
                        name = dt_Designation.Rows[j]["Designation"].ToString(),
                        data = data
                    });
                }

                response.data = series_data;
                return response;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        //=============Display Class Data By LookUp=================
        public void get_Closedrecord(GraphMode rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Patient_AutoClose_Token", "@SiteID", rs.SiteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}