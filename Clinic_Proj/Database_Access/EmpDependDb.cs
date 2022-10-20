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
    public class EmpDependDb
    {
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();

        //==========Employee Dependant Data Insert===================
        public void Add_record(EmpDependMode rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Emp_Dependent", "@EmpID,@EmpName,@Title,@FirstName,@MidName,@LastName,@GuardianName,@ReferBy,@CNICIssueDate,@CNICExpiryDate,@FamilyNumber,@CNICIdentity,@Gender,@CNIC,@Tel1,@Tel2,@Address,@City,@Country,@DOB,@Relation,@InActive,@Remarks,@LoginID", rs.EmployeeID, rs.EmpName, rs.Title, rs.FirstName, rs.MidName, rs.LastName, rs.Guardian, rs.ReferBy, rs.CNICIssue, rs.CNICExp, rs.FamilyNo, rs.CNICIdentity, rs.Gender,rs.CNIC,rs.Tel1,rs.Tel2,rs.Address,rs.City,rs.Country,rs.DOB,rs.Relation,rs.InActive,rs.Remarks,rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //===========Display All Employee Data by lookup=============
        public DataSet get_record()
        {
            try
            {
                ds = help.ReturnDataSetProcedure("UD_EmployeeDepend_get");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //==============Employee Dependant Data Update============
        public void update_record(EmpDependMode rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Emp_Dependent", "@EmpID,@EmpName,@Title,@FirstName,@MidName,@LastName,@GuardianName,@ReferBy,@CNICIssueDate,@CNICExpiryDate,@FamilyNumber,@CNICIdentity,@Gender,@CNIC,@Tel1,@Tel2,@Address,@City,@Country,@DOB,@Relation,@InActive,@Remarks,@LoginID", rs.EmployeeID, rs.EmpName, rs.Title, rs.FirstName, rs.MidName, rs.LastName, rs.Guardian, rs.ReferBy, rs.CNICIssue, rs.CNICExp, rs.FamilyNo, rs.CNICIdentity, rs.Gender, rs.CNIC, rs.Tel1, rs.Tel2, rs.Address, rs.City, rs.Country, rs.DOB, rs.Relation, rs.InActive, rs.Remarks, rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Employee Depend Get Data By ID=================
        public string get_recordbyid(EmpDependMode rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("UD_Employee_byid", "@ID", rs.EmployeeID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=================Display View All Employee Dependant Data===================
        public string get_Viewrecord(EmpDependMode rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("Vw_Patient_EmpDep_get", "@EmpID", rs.EmployeeID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=================Display View All Employee Dependant Data for Edit===================
        public string get_EditViewrecord(EmpDependMode rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("UD_Patient_EmpDep_get", "@ID", rs.ID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===========Delete Company Discount==============
        public void deletedata(EmpDependMode rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_EmplDepend", "@Code", rs.ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}