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
    public class EmployeeRegDB
    {
        DB_Helper help = new DB_Helper();
        DataSet ds = new DataSet();

        //==========Employee Data Insert===================
        public void Add_record(EmployeeRegMode rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Employee_Setup", "@EmpID,@Title,@FirstName,@MidName,@LastName,@GuardianName,@ReferBy,@CNICIssueDate,@CNICExpiryDate,@FamilyNumber,@CNICIdentity,@EmpCNIC,@Gender,@DOB,@EmpTel1,@EmpTel2,@EmpAddress,@EmpCity,@EmpCountry,@EmpRemarks,@CompanyID,@CompanyName,@EmpCompanyID,@EmpDepartment,@EmpDesignation,@EmpPayroll,@EmpType" +
                ",@InActive,@Remarks,@LoginID", rs.EmpID,rs.Title,rs.FirstName,rs.MidName,rs.LastName,rs.Guardian,rs.ReferBy,rs.CNICIssue,rs.CNICExp,rs.FamilyNo,rs.CNICIdentity,rs.EmpCNIC,rs.Gender, rs.DOB,rs.EmpTel1,rs.EmpTel2,rs.EmpAddress,rs.EmpCity,rs.EmpCountry,rs.EmpRemarks,rs.CompanyID,rs.CompanyName,rs.EmpCompanyID,rs.EmpDepartment,rs.EmpDesignation,rs.EmpPayroll,rs.EmpType,rs.InActive,rs.Remarks,rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //===========Display All Employees Data by lookup=============
        public DataSet get_record()
        {
            try
            {
                ds = help.ReturnDataSetProcedure("UD_Employee_get");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //===================Auto Get Employee ID============================
        public DataSet Generate_Employee_ID()
        {
            try
            {
                ds = help.ReturnDataSetProcedure("UD_Generate_Employee_ID");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==============Employee Data Update============
        public void update_record(EmployeeRegMode rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Add_Employee_Setup", "@EmpID,@Title,@FirstName,@MidName,@LastName,@GuardianName,@ReferBy,@CNICIssueDate,@CNICExpiryDate,@FamilyNumber,@CNICIdentity,@EmpCNIC,@Gender,@DOB,@EmpTel1,@EmpTel2,@EmpAddress,@EmpCity,@EmpCountry,@EmpRemarks,@CompanyID,@CompanyName,@EmpCompanyID,@EmpDepartment,@EmpDesignation,@EmpPayroll,@EmpType" +
                ",@InActive,@Remarks,@LoginID", rs.EmpID, rs.Title, rs.FirstName, rs.MidName, rs.LastName, rs.Guardian, rs.ReferBy, rs.CNICIssue, rs.CNICExp, rs.FamilyNo, rs.CNICIdentity, rs.EmpCNIC, rs.Gender, rs.DOB, rs.EmpTel1, rs.EmpTel2, rs.EmpAddress, rs.EmpCity, rs.EmpCountry, rs.EmpRemarks, rs.CompanyID, rs.CompanyName, rs.EmpCompanyID, rs.EmpDepartment, rs.EmpDesignation, rs.EmpPayroll, rs.EmpType, rs.InActive, rs.Remarks, rs.LoginID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Employee Search Data By ID=================
        public string get_searchbyid(EmployeeRegMode rs)
        {
            try
            {
                ds = help.ReturnParameterizedDataSetProcedure("UD_EmployeeSearch_get", "@SearchEmp", rs.SearchEmployee);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============Employee Get Data By ID=================
        public string get_recordbyid(EmployeeRegMode rs)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = help.ReturnParameterizedDataSetProcedure("UD_Emp_byid", "@ID", rs.EmpID);
                return (JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //===========Delete Employee==============
        public void deletedata(EmployeeRegMode rs)
        {
            try
            {
                help.ExecuteParameterizedProcedure("UD_Delete_Employee", "@Code", rs.EmpID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}