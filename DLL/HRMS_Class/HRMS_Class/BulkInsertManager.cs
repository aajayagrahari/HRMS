using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using HRMS_Connection;
using ErrorHandler;

namespace HRMS_Class
{

    public class BulkInsertManager
    {
        const string EmployeeMasterTable = "BulkInsert";
        ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();
        EmployeeMasterDetailsManager objEmployeeMasterDetailsManager = new EmployeeMasterDetailsManager();
        EmployeeJobDetailsManager objEmployeeJobDetailsManager = new EmployeeJobDetailsManager();
        EmployeeQualificationDetailsManager objEmployeeQualificationDetailsManager = new EmployeeQualificationDetailsManager();
        EmployeeEarningDetailsManager objEmployeeEarningDetailsManager = new EmployeeEarningDetailsManager();
        EmployeeDeductionDetailsManager objEmployeeDeductionDetailsManager = new EmployeeDeductionDetailsManager();
        EmployeeLeaveDetailsManager objEmployeeLeaveDetailsManager = new EmployeeLeaveDetailsManager();
        EmployeeLeftDetailsManager objEmployeeLeftDetailsManager = new EmployeeLeftDetailsManager();
        EmployeeOtherDetailsManager objEmployeeOtherDetailsManager = new EmployeeOtherDetailsManager();

        DataSet dsExcel = new DataSet();

        DataSet dsExcel4Job = new DataSet();
        DataSet dsExcel4Qualification = new DataSet();
        DataSet dsExcel4Earning = new DataSet();
        DataSet dsExcel4Deduction = new DataSet();
        DataSet dsExcel4Leave = new DataSet();
        DataSet dsExcel4Left = new DataSet();
        DataSet dsExcel4Other = new DataSet();

        DataTable dtExcel = null;
        DataTable dtExcel4Job = null;
        DataTable dtExcel4Qualification = null;
        DataTable dtExcel4Earning = null;
        DataTable dtExcel4Deduction = null;
        DataTable dtExcel4Leave = null;
        DataTable dtExcel4Left = null;
        DataTable dtExcel4Other = null;


        public ICollection<ErrorHandlerClass> BulkInsert4Employee(string argExcelPath, string argQuery, string strTableName, string argFileExt, string argUserName)
        {
            DataTable dtExcel = null;
            DataTable dtExcel4Job = null;
            DataTable dtExcel4Qualification = null;
            DataTable dtExcel4Earning = null;
            DataTable dtExcel4Deduction = null;
            DataTable dtExcel4Leave = null;
            DataTable dtExcel4Left = null;
            DataTable dtExcel4Other = null;

            EmployeeMasterDetails ObjEmployeeMasterDetails = null;
            string xConnStr = "";
            string strSheetName = "";
            string strQuery4Master = "";
            string strQuery4Job = "";
            string strQuery4Qualification = "";
            string strQuery4Earning = "";
            string strQuery4Deduction = "";
            string strQuery4Leave = "";
            string strQuery4Left = "";
            string strQuery4Other = "";
            string strDataSource = "";
            DataSet dsExcel = new DataSet();
            DataTable dtTableSchema = new DataTable();
            //OleDbConnection objXConn = null;
            //OleDbDataAdapter objDataAdapter = new OleDbDataAdapter();

            OleDbConnectionStringBuilder connectionStringBuilder = new OleDbConnectionStringBuilder();
            String strExtendedProperties = String.Empty;

            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();

            //if (argFileExt.ToString() == ".xls")
            //{
            //    xConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;" +
            //    "Data Source=" + argExcelPath.Trim() + ";" +
            //    "Extended Properties=Excel 8.0";
            //    connectionStringBuilder.DataSource = argExcelPath;
            //    connectionStringBuilder.Add("Mode", "Read");
            //}
            //else
            //{
            //    xConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;" +
            //    "Data Source=" + argExcelPath.Trim() + ";" +
            //    "Extended Properties=Excel 12.0";
            //    connectionStringBuilder.DataSource = argExcelPath;
            //    connectionStringBuilder.Add("Mode", "Read");
            //}

            if (argFileExt.Equals(".xls"))//for 97-03 Excel file
            {
                connectionStringBuilder.Provider = "Microsoft.Jet.OLEDB.4.0";
                strExtendedProperties = argExcelPath.Trim() + ";" + "Excel 8.0;HDR=Yes;IMEX=1";//HDR=ColumnHeader,IMEX=InterMixed
            }
            else if (argFileExt.Equals(".xlsx"))  //for 2007 Excel file
            {
                connectionStringBuilder.Provider = "Microsoft.ACE.OLEDB.12.0";
                strExtendedProperties = argExcelPath.Trim() + ";" + "Excel 12.0;HDR=Yes;IMEX=1";
            }


            try
            {
                //objXConn = new OleDbConnection(xConnStr);
                //objXConn.Open();

                //dtTableSchema = objXConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                //if (argFileExt.ToString() == ".xls")
                //{
                //    strSheetName = Convert.ToString(dtTableSchema.Rows[0]["TABLE_NAME"]);
                //}
                //else
                //{
                //    strSheetName = Convert.ToString(dtTableSchema.Rows[0]["TABLE_NAME"]);

                //    if (strSheetName.IndexOf(@"_xlnm#_FilterDatabase") >= 0)
                //    {
                //        strSheetName = Convert.ToString(dtTableSchema.Rows[1]["TABLE_NAME"]);
                //    }
                //}
                //argQuery = argQuery + " [" + strSheetName + "]";
                //OleDbCommand objCommand = new OleDbCommand(argQuery, objXConn);
                //objDataAdapter.SelectCommand = objCommand;
                //objDataAdapter.Fill(dsExcel);
                //dtExcel = dsExcel.Tables[0];

                /*****************************************/

                connectionStringBuilder.Add("Extended Properties", strExtendedProperties);
                using (OleDbConnection objConn = new OleDbConnection(connectionStringBuilder.ToString()))
                {
                    objConn.Open();
                    DataTable dtSheet = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    //List<string> listSheet = new List<string>();
                    foreach (DataRow drSheet in dtSheet.Rows)
                    {
                        if (drSheet["TABLE_NAME"].ToString().Contains("$"))//checks whether row contains '_xlnm#_FilterDatabase' or sheet name(i.e. sheet name always ends with $ sign)
                        {
                            //listSheet.Add(drSheet["TABLE_NAME"].ToString());
                            strSheetName = drSheet["TABLE_NAME"].ToString();

                            if (strSheetName == "EmployeeMaster")
                            {
                                argQuery = argQuery + " [" + strSheetName + "]";

                                OleDbCommand objCmdSelect = new OleDbCommand(argQuery, objConn);
                                OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
                                objAdapter1.SelectCommand = objCmdSelect;
                                DataSet objDataset1 = new DataSet();
                                objAdapter1.Fill(dtExcel);
                            }
                            else if (strSheetName == "EmployeeJob")
                            {
                                argQuery = argQuery + " [" + strSheetName + "]";

                                OleDbCommand objCmdSelect = new OleDbCommand(argQuery, objConn);
                                OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
                                objAdapter1.SelectCommand = objCmdSelect;
                                objAdapter1.Fill(dtExcel4Job);
                            }
                            else if (strSheetName == "EmployeeQualification")
                            {
                                argQuery = argQuery + " [" + strSheetName + "]";

                                OleDbCommand objCmdSelect = new OleDbCommand(argQuery, objConn);
                                OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
                                objAdapter1.SelectCommand = objCmdSelect;
                                objAdapter1.Fill(dtExcel4Qualification);
                            }
                            else if (strSheetName == "EmployeeEarning")
                            {
                                argQuery = argQuery + " [" + strSheetName + "]";

                                OleDbCommand objCmdSelect = new OleDbCommand(argQuery, objConn);
                                OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
                                objAdapter1.SelectCommand = objCmdSelect;
                                objAdapter1.Fill(dtExcel4Earning);
                            }
                            else if (strSheetName == "EmployeeDeduction")
                            {
                                argQuery = argQuery + " [" + strSheetName + "]";

                                OleDbCommand objCmdSelect = new OleDbCommand(argQuery, objConn);
                                OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
                                objAdapter1.SelectCommand = objCmdSelect;
                                objAdapter1.Fill(dtExcel4Deduction);
                            }
                            else if (strSheetName == "EmployeeLeave")
                            {
                                argQuery = argQuery + " [" + strSheetName + "]";

                                OleDbCommand objCmdSelect = new OleDbCommand(argQuery, objConn);
                                OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
                                objAdapter1.SelectCommand = objCmdSelect;
                                objAdapter1.Fill(dtExcel4Leave);
                            }
                            else if (strSheetName == "EmployeeLeft")
                            {
                                argQuery = argQuery + " [" + strSheetName + "]";

                                OleDbCommand objCmdSelect = new OleDbCommand(argQuery, objConn);
                                OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
                                objAdapter1.SelectCommand = objCmdSelect;
                                objAdapter1.Fill(dtExcel4Left);
                            }
                            else if (strSheetName == "EmployeeOther")
                            {
                                argQuery = argQuery + " [" + strSheetName + "]";

                                OleDbCommand objCmdSelect = new OleDbCommand(argQuery, objConn);
                                OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
                                objAdapter1.SelectCommand = objCmdSelect;
                                objAdapter1.Fill(dtExcel4Other);
                            }
                        }
                    }
                }




                //const string extendedProperties = "Excel 12.0;IMEX=1;HDR=YES";
                //connectionStringBuilder.Add("Extended Properties", extendedProperties);



                //using (OleDbConnection objConn = new OleDbConnection(connectionStringBuilder.ConnectionString))
                //{
                //    objConn.Open();

                //    Microsoft.Office.Interop.Excel.Application xlsApp = new Microsoft.Office.Interop.Excel.Application();
                //    Microsoft.Office.Interop.Excel.Workbook wb = xlsApp.Workbooks.Open(argExcelPath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);

                //    Microsoft.Office.Interop.Excel.Sheets sheets = wb.Worksheets;

                //    for (int i = 1; i <= wb.Worksheets.Count; i++)
                //    {

                //        strSheetName = Convert.ToString(wb.Sheets[i].Name.ToString());
                //        //MessageBox.Show(wb.Sheets[i].Name.ToString());

                //    }
                //    //Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)sheets.get_Item(1);
                //}

                //dtExcel = dsExcel.Tables[0];

                ///*****************************************/
                //DataAccess da = new DataAccess();
                //da.Open_Connection();
                //da.BEGIN_TRANSACTION();

                //try
                //{
                //    foreach (DataRow drExcel in dtExcel.Rows)
                //    {
                //        ObjEmployeeMasterDetails = new EmployeeMasterDetails();
                //        ObjEmployeeMasterDetails.EmployeeId = Convert.ToString(drExcel["EmployeeId"]).Trim();
                //        ObjEmployeeMasterDetails.PCardNo = Convert.ToString(drExcel["PCardNo"]).Trim();
                //        ObjEmployeeMasterDetails.EmployeeType = Convert.ToString(drExcel["EmployeeTypeId"]).Trim();
                //        ObjEmployeeMasterDetails.FirstName = Convert.ToString(drExcel["FirstName"]).Trim();
                //        ObjEmployeeMasterDetails.MiddleName = Convert.ToString(drExcel["MiddleName"]).Trim();
                //        ObjEmployeeMasterDetails.LastName = Convert.ToString(drExcel["LastName"]).Trim();
                //        ObjEmployeeMasterDetails.FatherName = Convert.ToString(drExcel["FatherName"]).Trim();
                //        ObjEmployeeMasterDetails.Designation = Convert.ToString(drExcel["Designation"]).Trim();
                //        ObjEmployeeMasterDetails.Unit = Convert.ToString(drExcel["Unit"]).Trim();
                //        ObjEmployeeMasterDetails.SubUnit = Convert.ToString(drExcel["SubUnit"]);
                //        ObjEmployeeMasterDetails.Department = Convert.ToString(drExcel["Department"]).Trim();
                //        ObjEmployeeMasterDetails.PFNo = Convert.ToString(drExcel["PFNo"]).Trim();
                //        ObjEmployeeMasterDetails.ESINo = Convert.ToString(drExcel["ESINo"]).Trim();
                //        ObjEmployeeMasterDetails.AliasName = Convert.ToString(drExcel["AliasName"]).Trim();
                //        ObjEmployeeMasterDetails.NickName = Convert.ToString(drExcel["NickName"]).Trim();
                //        ObjEmployeeMasterDetails.LocalAddress = Convert.ToString(drExcel["LocalAddress"]).Trim();
                //        ObjEmployeeMasterDetails.City = Convert.ToString(drExcel["City"]).Trim();
                //        ObjEmployeeMasterDetails.ZipCode = Convert.ToString(drExcel["ZipCode"]);
                //        ObjEmployeeMasterDetails.Country = Convert.ToString(drExcel["Country"]).Trim();
                //        ObjEmployeeMasterDetails.State = Convert.ToString(drExcel["State"]).Trim();
                //        ObjEmployeeMasterDetails.ContactNo = Convert.ToString(drExcel["ContactNo"]).Trim();
                //        ObjEmployeeMasterDetails.EmailId = Convert.ToString(drExcel["EmailId"]).Trim();
                //        ObjEmployeeMasterDetails.ParamAddress = Convert.ToString(drExcel["ParamAddress"]).Trim();
                //        ObjEmployeeMasterDetails.ParamCity = Convert.ToString(drExcel["ParamCity"]).Trim();
                //        ObjEmployeeMasterDetails.ParamZipCode = Convert.ToString(drExcel["ParamZipCode"]).Trim();
                //        ObjEmployeeMasterDetails.ParamCountry = Convert.ToString(drExcel["ParamCountry"]);
                //        ObjEmployeeMasterDetails.ParamState = Convert.ToString(drExcel["ParamState"]).Trim();
                //        ObjEmployeeMasterDetails.PlaceOfBirth = Convert.ToString(drExcel["PlaceOfBirth"]).Trim();
                //        ObjEmployeeMasterDetails.RationCardNo = Convert.ToString(drExcel["RationCardNo"]).Trim();
                //        ObjEmployeeMasterDetails.VoterId = Convert.ToString(drExcel["VoterId"]).Trim();
                //        ObjEmployeeMasterDetails.PassportNo = Convert.ToString(drExcel["PassportNo"]).Trim();
                //        ObjEmployeeMasterDetails.PANNo = Convert.ToString(drExcel["PANCardNo"]).Trim();
                //        ObjEmployeeMasterDetails.BankName = Convert.ToString(drExcel["BankDetail"]).Trim();
                //        ObjEmployeeMasterDetails.AccountNo = Convert.ToString(drExcel["BankAccountNo"]).Trim();
                //        ObjEmployeeMasterDetails.AccountHolderName = Convert.ToString(drExcel["AccountHolderName"]).Trim();
                //        ObjEmployeeMasterDetails.Branch = Convert.ToString(drExcel["Branch"]).Trim();
                //        ObjEmployeeMasterDetails.DLNo = Convert.ToString(drExcel["DLNo"]).Trim();
                //        ObjEmployeeMasterDetails.ValidUpTo = Convert.ToString(drExcel["ValidUpTo"]).Trim();
                //        ObjEmployeeMasterDetails.IdentityMarks = Convert.ToString(drExcel["IdentityMarks"]);
                //        ObjEmployeeMasterDetails.Religion = Convert.ToString(drExcel["Religion"]).Trim();
                //        ObjEmployeeMasterDetails.Nationality = Convert.ToString(drExcel["Nationality"]).Trim();
                //        ObjEmployeeMasterDetails.DateOfBirth = Convert.ToString(drExcel["DateOfBirth"]).Trim();
                //        ObjEmployeeMasterDetails.RetirementDate = Convert.ToString(drExcel["RetirementDate"]).Trim();
                //        ObjEmployeeMasterDetails.Gender = Convert.ToString(drExcel["Gender"]).Trim();
                //        if (Convert.ToString(drExcel["Height"]).Trim() != "")
                //        {
                //            ObjEmployeeMasterDetails.Height = Convert.ToDouble(drExcel["Height"]);
                //        }
                //        else
                //        {
                //            ObjEmployeeMasterDetails.Height = 0.0;
                //        }
                //        ObjEmployeeMasterDetails.BloodGroup = Convert.ToString(drExcel["BloodGroup"]).Trim();
                //        ObjEmployeeMasterDetails.MaritalStatus = Convert.ToString(drExcel["MaritalStatus"]);
                //        ObjEmployeeMasterDetails.Date = Convert.ToString(drExcel["Date"]).Trim();
                //        ObjEmployeeMasterDetails.LoginId = Convert.ToString(drExcel["LoginId"]).Trim();
                //        ObjEmployeeMasterDetails.Password = Convert.ToString(drExcel["Password"]).Trim();
                //        ObjEmployeeMasterDetails.EmployeePic = Convert.ToString(drExcel["EmployeePic"]).Trim();
                //        ObjEmployeeMasterDetails.CityType = Convert.ToString(drExcel["CityType"]).Trim();

                //        ObjEmployeeMasterDetails.CreatedBy = Convert.ToString(drExcel["CreatedBy"]).Trim();
                //        ObjEmployeeMasterDetails.ModifiedBy = Convert.ToString(drExcel["ModifiedBy"]).Trim();
                //        ObjEmployeeMasterDetails.IsDeleted = Convert.ToInt32(drExcel["IsDeleted"]);

                //        objEmployeeMasterDetailsManager.SaveEmployeeMaster(ObjEmployeeMasterDetails, ref da, ref lstErr);

                //        foreach (ErrorHandlerClass objerr in lstErr)
                //        {
                //            if (objerr.Type == "E")
                //            {
                //                da.ROLLBACK_TRANSACTION();
                //                break;
                //            }
                //        }
                //    }
                //    da.COMMIT_TRANSACTION();
                //}
                //catch (Exception ex)
                //{
                //    if (da != null)
                //    {
                //        da.ROLLBACK_TRANSACTION();
                //    }
                //    objErrorHandlerClass.Type = ErrorConstant.strAboartType;
                //    objErrorHandlerClass.MsgId = 0;
                //    objErrorHandlerClass.Module = ErrorConstant.strInsertModule;
                //    objErrorHandlerClass.ModulePart = ErrorConstant.strMasterModule;
                //    objErrorHandlerClass.Message = ex.Message.ToString();
                //    objErrorHandlerClass.RowNo = 0;
                //    objErrorHandlerClass.FieldName = "";
                //    objErrorHandlerClass.LogCode = "";
                //    lstErr.Add(objErrorHandlerClass);
                //}
                //finally
                //{
                //    if (da != null)
                //    {
                //        da.Close_Connection();
                //        da = null;
                //    }
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //objXConn.Close();
            }
            return lstErr;
        }

        public ICollection<ErrorHandlerClass> BulkInsert4Employee1(string argExcelPath, string argQuery, string strTableName, string argFileExt, string argUserName)
        {
            DataAccess da = new DataAccess();
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            string xConnStr = "";
            string strSheetName = "";
            string strQuery4Master = "";
            string strQuery4Job = "";
            string strQuery4Qualification = "";
            string strQuery4Earning = "";
            string strQuery4Deduction = "";
            string strQuery4Leave = "";
            string strQuery4Left = "";
            string strQuery4Other = "";


            DataTable dtTableSchema = new DataTable();
            OleDbConnection objXConn = null;
            OleDbDataAdapter objDataAdapter = new OleDbDataAdapter();

            try
            {
                if (argFileExt.ToString() == ".xls")
                {
                    xConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                    "Data Source=" + argExcelPath.Trim() + ";" +
                    "Extended Properties=Excel 8.0";
                }
                else
                {
                    xConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                    "Data Source=" + argExcelPath.Trim() + ";" +
                    "Extended Properties=Excel 12.0";
                }

                objXConn = new OleDbConnection(xConnStr);
                objXConn.Open();
                DataTable xlTable = new DataTable();
                xlTable = objXConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                string sheetName;

                for (int lngStart = 0; lngStart < xlTable.Rows.Count; lngStart++)
                {
                    sheetName = xlTable.Rows[lngStart][2].ToString().Replace("'", "");
                    if (sheetName.EndsWith("$"))
                    {
                        //strExcelSheetNames += sheetName.Substring(0, sheetName.Length - 1);

                        strSheetName = sheetName.Substring(0, sheetName.Length - 1) + "$";

                        if (strSheetName == "EmployeeMaster$")
                        {
                            strQuery4Master = argQuery + " [" + strSheetName + "]";

                            OleDbCommand objCommand = new OleDbCommand(strQuery4Master, objXConn);
                            objDataAdapter.SelectCommand = objCommand;
                            objDataAdapter.Fill(dsExcel);
                            dtExcel = dsExcel.Tables[0];
                        }
                        else if (strSheetName == "EmployeeJob$")
                        {
                            strQuery4Job = argQuery + " [" + strSheetName + "]";

                            OleDbCommand objCommand = new OleDbCommand(strQuery4Job, objXConn);
                            objDataAdapter.SelectCommand = objCommand;
                            objDataAdapter.Fill(dsExcel4Job);
                            dtExcel4Job = dsExcel4Job.Tables[0];
                        }
                        else if (strSheetName == "EmployeeQualification$")
                        {
                            strQuery4Qualification = argQuery + " [" + strSheetName + "]";

                            OleDbCommand objCommand = new OleDbCommand(strQuery4Qualification, objXConn);
                            objDataAdapter.SelectCommand = objCommand;
                            objDataAdapter.Fill(dsExcel4Qualification);
                            dtExcel4Qualification = dsExcel4Qualification.Tables[0];
                        }
                        else if (strSheetName == "EmployeeEarning$")
                        {
                            strQuery4Earning = argQuery + " [" + strSheetName + "]";

                            OleDbCommand objCommand = new OleDbCommand(strQuery4Earning, objXConn);
                            objDataAdapter.SelectCommand = objCommand;
                            objDataAdapter.Fill(dsExcel4Earning);
                            dtExcel4Earning = dsExcel4Earning.Tables[0];
                        }
                        else if (strSheetName == "EmployeeDeduction$")
                        {
                            
                            strQuery4Deduction = argQuery + " [" + strSheetName + "]";

                            OleDbCommand objCommand = new OleDbCommand(strQuery4Deduction, objXConn);
                            objDataAdapter.SelectCommand = objCommand;
                            objDataAdapter.Fill(dsExcel4Deduction);
                            dtExcel4Deduction = dsExcel4Deduction.Tables[0];
                        }
                        else if (strSheetName == "EmployeeLeave$")
                        {
                            strQuery4Leave = argQuery + " [" + strSheetName + "]";

                            OleDbCommand objCommand = new OleDbCommand(strQuery4Leave, objXConn);
                            objDataAdapter.SelectCommand = objCommand;
                            objDataAdapter.Fill(dsExcel4Leave);
                            dtExcel4Leave = dsExcel4Leave.Tables[0];
                        }
                        else if (strSheetName == "EmployeeLeft$")
                        {
                            strQuery4Left = argQuery + " [" + strSheetName + "]";

                            OleDbCommand objCommand = new OleDbCommand(strQuery4Left, objXConn);
                            objDataAdapter.SelectCommand = objCommand;
                            objDataAdapter.Fill(dsExcel4Left);
                            dtExcel4Left = dsExcel4Left.Tables[0];
                        }
                        else if (strSheetName == "EmployeeOther$")
                        {
                            strQuery4Other = argQuery + " [" + strSheetName + "]";

                            OleDbCommand objCommand = new OleDbCommand(strQuery4Other, objXConn);
                            objDataAdapter.SelectCommand = objCommand;
                            objDataAdapter.Fill(dsExcel4Other);
                            dtExcel4Other = dsExcel4Other.Tables[0];
                        }
                    }
                }

                //foreach (ErrorHandlerClass err in objEmployeeMasterDetailsManager.SaveEmployeeMaster(setObjectInfor4Employee(),setObjectInfor4Job(),SetObjectInfo4Qualification(),SetObjectInfo4Earnings(),SetObjectInfo4Deductions(),SetObjectInfo4Leaves(),setObjectInfor4Left(),setObjectInfor4Other()))
                //{
                //    objEmployeeMasterDetailsManager.SaveEmployeeMaster(ObjEmployeeMasterDetails, ref da, ref lstErr);

                objEmployeeMasterDetailsManager.SaveEmployeeMaster(setObjectInfor4Employee(), setObjectInfor4Job(), SetObjectInfo4Qualification(), SetObjectInfo4Earnings(), SetObjectInfo4Deductions(), SetObjectInfo4Leaves(), setObjectInfor4Left(), setObjectInfor4Other());
                //}

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objXConn.Close();
                objXConn.Dispose();
            }
            return lstErr;
        }

        public ICollection<ErrorHandlerClass> BulkInsert4EmployeeMaster(string argExcelPath, string argQuery, string strTableName, string argFileExt, string argUserName)
        {
            DataTable dtExcel = null;
            EmployeeMasterDetails ObjEmployeeMasterDetails = null;
            string xConnStr = "";
            string strSheetName = "";
            DataSet dsExcel = new DataSet();
            DataTable dtTableSchema = new DataTable();
            OleDbConnection objXConn = null;
            OleDbDataAdapter objDataAdapter = new OleDbDataAdapter();
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();

            if (argFileExt.ToString() == ".xls")
            {
                xConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                "Data Source=" + argExcelPath.Trim() + ";" +
                "Extended Properties=Excel 8.0";
            }
            else
            {
                xConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=" + argExcelPath.Trim() + ";" +
                "Extended Properties=Excel 12.0";
            }

            try
            {
                objXConn = new OleDbConnection(xConnStr);
                objXConn.Open();

                dtTableSchema = objXConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (argFileExt.ToString() == ".xls")
                {
                    strSheetName = Convert.ToString(dtTableSchema.Rows[0]["TABLE_NAME"]);
                }
                else
                {
                    strSheetName = Convert.ToString(dtTableSchema.Rows[0]["TABLE_NAME"]);

                    if (strSheetName.IndexOf(@"_xlnm#_FilterDatabase") >= 0)
                    {
                        strSheetName = Convert.ToString(dtTableSchema.Rows[1]["TABLE_NAME"]);
                    }
                }
                argQuery = argQuery + " [" + strSheetName + "]";
                OleDbCommand objCommand = new OleDbCommand(argQuery, objXConn);
                objDataAdapter.SelectCommand = objCommand;
                objDataAdapter.Fill(dsExcel);
                dtExcel = dsExcel.Tables[0];

                /*****************************************/
                DataAccess da = new DataAccess();
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                try
                {
                    foreach (DataRow drExcel in dtExcel.Rows)
                    {
                        ObjEmployeeMasterDetails = new EmployeeMasterDetails();
                        ObjEmployeeMasterDetails.EmployeeId = Convert.ToString(drExcel["EmployeeId"]).Trim();
                        ObjEmployeeMasterDetails.PCardNo = Convert.ToString(drExcel["PCardNo"]).Trim();
                        ObjEmployeeMasterDetails.EmployeeType = Convert.ToString(drExcel["EmployeeTypeId"]).Trim();
                        ObjEmployeeMasterDetails.FirstName = Convert.ToString(drExcel["FirstName"]).Trim();
                        ObjEmployeeMasterDetails.MiddleName = Convert.ToString(drExcel["MiddleName"]).Trim();
                        ObjEmployeeMasterDetails.LastName = Convert.ToString(drExcel["LastName"]).Trim();
                        ObjEmployeeMasterDetails.FatherName = Convert.ToString(drExcel["FatherName"]).Trim();
                        ObjEmployeeMasterDetails.Designation = Convert.ToString(drExcel["Designation"]).Trim();
                        ObjEmployeeMasterDetails.Unit = Convert.ToString(drExcel["Unit"]).Trim();
                        ObjEmployeeMasterDetails.SubUnit = Convert.ToString(drExcel["SubUnit"]);
                        ObjEmployeeMasterDetails.Department = Convert.ToString(drExcel["Department"]).Trim();
                        ObjEmployeeMasterDetails.PFNo = Convert.ToString(drExcel["PFNo"]).Trim();
                        ObjEmployeeMasterDetails.ESINo = Convert.ToString(drExcel["ESINo"]).Trim();
                        ObjEmployeeMasterDetails.AliasName = Convert.ToString(drExcel["AliasName"]).Trim();
                        ObjEmployeeMasterDetails.NickName = Convert.ToString(drExcel["NickName"]).Trim();
                        ObjEmployeeMasterDetails.LocalAddress = Convert.ToString(drExcel["LocalAddress"]).Trim();
                        ObjEmployeeMasterDetails.City = Convert.ToString(drExcel["City"]).Trim();
                        ObjEmployeeMasterDetails.ZipCode = Convert.ToString(drExcel["ZipCode"]);
                        ObjEmployeeMasterDetails.Country = Convert.ToString(drExcel["Country"]).Trim();
                        ObjEmployeeMasterDetails.State = Convert.ToString(drExcel["State"]).Trim();
                        ObjEmployeeMasterDetails.ContactNo = Convert.ToString(drExcel["ContactNo"]).Trim();
                        ObjEmployeeMasterDetails.EmailId = Convert.ToString(drExcel["EmailId"]).Trim();
                        ObjEmployeeMasterDetails.ParamAddress = Convert.ToString(drExcel["ParamAddress"]).Trim();
                        ObjEmployeeMasterDetails.ParamCity = Convert.ToString(drExcel["ParamCity"]).Trim();
                        ObjEmployeeMasterDetails.ParamZipCode = Convert.ToString(drExcel["ParamZipCode"]).Trim();
                        ObjEmployeeMasterDetails.ParamCountry = Convert.ToString(drExcel["ParamCountry"]);
                        ObjEmployeeMasterDetails.ParamState = Convert.ToString(drExcel["ParamState"]).Trim();
                        ObjEmployeeMasterDetails.PlaceOfBirth = Convert.ToString(drExcel["PlaceOfBirth"]).Trim();
                        ObjEmployeeMasterDetails.RationCardNo = Convert.ToString(drExcel["RationCardNo"]).Trim();
                        ObjEmployeeMasterDetails.VoterId = Convert.ToString(drExcel["VoterId"]).Trim();
                        ObjEmployeeMasterDetails.PassportNo = Convert.ToString(drExcel["PassportNo"]).Trim();
                        ObjEmployeeMasterDetails.PANNo = Convert.ToString(drExcel["PANCardNo"]).Trim();
                        ObjEmployeeMasterDetails.BankName = Convert.ToString(drExcel["BankDetail"]).Trim();
                        ObjEmployeeMasterDetails.AccountNo = Convert.ToString(drExcel["BankAccountNo"]).Trim();
                        ObjEmployeeMasterDetails.AccountHolderName = Convert.ToString(drExcel["AccountHolderName"]).Trim();
                        ObjEmployeeMasterDetails.Branch = Convert.ToString(drExcel["Branch"]).Trim();
                        ObjEmployeeMasterDetails.DLNo = Convert.ToString(drExcel["DLNo"]).Trim();
                        ObjEmployeeMasterDetails.ValidUpTo = Convert.ToString(drExcel["ValidUpTo"]).Trim();
                        ObjEmployeeMasterDetails.IdentityMarks = Convert.ToString(drExcel["IdentityMarks"]);
                        ObjEmployeeMasterDetails.Religion = Convert.ToString(drExcel["Religion"]).Trim();
                        ObjEmployeeMasterDetails.Nationality = Convert.ToString(drExcel["Nationality"]).Trim();
                        ObjEmployeeMasterDetails.DateOfBirth = Convert.ToString(drExcel["DateOfBirth"]).Trim();
                        ObjEmployeeMasterDetails.RetirementDate = Convert.ToString(drExcel["RetirementDate"]).Trim();
                        ObjEmployeeMasterDetails.Gender = Convert.ToString(drExcel["Gender"]).Trim();
                        if (Convert.ToString(drExcel["Height"]).Trim() != "")
                        {
                            ObjEmployeeMasterDetails.Height = Convert.ToDouble(drExcel["Height"]);
                        }
                        else
                        {
                            ObjEmployeeMasterDetails.Height = 0.0;
                        }
                        ObjEmployeeMasterDetails.BloodGroup = Convert.ToString(drExcel["BloodGroup"]).Trim();
                        ObjEmployeeMasterDetails.MaritalStatus = Convert.ToString(drExcel["MaritalStatus"]);
                        ObjEmployeeMasterDetails.Date = Convert.ToString(drExcel["Date"]).Trim();
                        ObjEmployeeMasterDetails.LoginId = Convert.ToString(drExcel["LoginId"]).Trim();
                        ObjEmployeeMasterDetails.Password = Convert.ToString(drExcel["Password"]).Trim();
                        ObjEmployeeMasterDetails.EmployeePic = Convert.ToString(drExcel["EmployeePic"]).Trim();
                        ObjEmployeeMasterDetails.CityType = Convert.ToString(drExcel["CityType"]).Trim();

                        ObjEmployeeMasterDetails.CreatedBy = Convert.ToString(drExcel["CreatedBy"]).Trim();
                        ObjEmployeeMasterDetails.ModifiedBy = Convert.ToString(drExcel["ModifiedBy"]).Trim();
                        ObjEmployeeMasterDetails.IsDeleted = Convert.ToInt32(drExcel["IsDeleted"]);

                        objEmployeeMasterDetailsManager.SaveEmployeeMaster(ObjEmployeeMasterDetails, ref da, ref lstErr);

                        foreach (ErrorHandlerClass objerr in lstErr)
                        {
                            if (objerr.Type == "E")
                            {
                                da.ROLLBACK_TRANSACTION();
                                break;
                            }
                        }
                    }
                    da.COMMIT_TRANSACTION();
                }
                catch (Exception ex)
                {
                    if (da != null)
                    {
                        da.ROLLBACK_TRANSACTION();
                    }
                    objErrorHandlerClass.Type = ErrorConstant.strAboartType;
                    objErrorHandlerClass.MsgId = 0;
                    objErrorHandlerClass.Module = ErrorConstant.strInsertModule;
                    objErrorHandlerClass.ModulePart = ErrorConstant.strMasterModule;
                    objErrorHandlerClass.Message = ex.Message.ToString();
                    objErrorHandlerClass.RowNo = 0;
                    objErrorHandlerClass.FieldName = "";
                    objErrorHandlerClass.LogCode = "";
                    lstErr.Add(objErrorHandlerClass);
                }
                finally
                {
                    if (da != null)
                    {
                        da.Close_Connection();
                        da = null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objXConn.Close();
            }
            return lstErr;
        }

        public ICollection<ErrorHandlerClass> BulkInsert4EmployeeJobDetails(string argExcelPath, string argQuery, string strTableName, string argFileExt, string argUserName)
        {
            DataTable dtExcel = null;
            EmployeeJobDetails ObjEmployeeJobDetails = null;
            string xConnStr = "";
            string strSheetName = "";
            DataSet dsExcel = new DataSet();
            DataTable dtTableSchema = new DataTable();
            OleDbConnection objXConn = null;
            OleDbDataAdapter objDataAdapter = new OleDbDataAdapter();
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();

            if (argFileExt.ToString() == ".xls")
            {
                xConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                "Data Source=" + argExcelPath.Trim() + ";" +
                "Extended Properties=Excel 8.0";
            }
            else
            {
                xConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=" + argExcelPath.Trim() + ";" +
                "Extended Properties=Excel 12.0";
            }

            try
            {
                objXConn = new OleDbConnection(xConnStr);
                objXConn.Open();

                dtTableSchema = objXConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (argFileExt.ToString() == ".xls")
                {
                    strSheetName = Convert.ToString(dtTableSchema.Rows[0]["TABLE_NAME"]);
                }
                else
                {
                    strSheetName = Convert.ToString(dtTableSchema.Rows[0]["TABLE_NAME"]);

                    if (strSheetName.IndexOf(@"_xlnm#_FilterDatabase") >= 0)
                    {
                        strSheetName = Convert.ToString(dtTableSchema.Rows[1]["TABLE_NAME"]);
                    }
                }
                argQuery = argQuery + " [" + strSheetName + "]";
                OleDbCommand objCommand = new OleDbCommand(argQuery, objXConn);
                objDataAdapter.SelectCommand = objCommand;
                objDataAdapter.Fill(dsExcel);
                dtExcel = dsExcel.Tables[0];

                /*****************************************/
                DataAccess da = new DataAccess();
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                try
                {
                    foreach (DataRow drExcel in dtExcel.Rows)
                    {
                        ObjEmployeeJobDetails = new EmployeeJobDetails();
                        ObjEmployeeJobDetails.EmployeeJobId = Convert.ToInt32(drExcel["EmployeeJobId"]);
                        ObjEmployeeJobDetails.EmployeeId = Convert.ToString(drExcel["EmployeeId"]).Trim();

                        ObjEmployeeJobDetails.ApplicationDate = Convert.ToString(drExcel["ApplicationDate"]);
                        ObjEmployeeJobDetails.InterviewDate = Convert.ToString(drExcel["InterviewDate"]);
                        ObjEmployeeJobDetails.JoiningDate = Convert.ToString(drExcel["JoiningDate"]);
                        ObjEmployeeJobDetails.ConfirmationDate = Convert.ToString(drExcel["ConfirmationDate"]);
                        ObjEmployeeJobDetails.AppointmentLetterIssueDate = Convert.ToString(drExcel["AppointmentLetterIssueDate"]);
                        ObjEmployeeJobDetails.SalartyStopAfter = Convert.ToString(drExcel["SalartyStopAfter"]);
                        ObjEmployeeJobDetails.ContractStartDate = Convert.ToString(drExcel["ContractStartDate"]);
                        ObjEmployeeJobDetails.ContractEndDate = Convert.ToString(drExcel["ContractEndDate"]);
                        ObjEmployeeJobDetails.DateOfTransfer = Convert.ToString(drExcel["DateOfTransfer"]);
                        ObjEmployeeJobDetails.PFStartDate = Convert.ToString(drExcel["PFStartDate"]);
                        ObjEmployeeJobDetails.EPSStartDate = Convert.ToString(drExcel["EPSStartDate"]);
                        ObjEmployeeJobDetails.ESISStartDate = Convert.ToString(drExcel["ESISStartDate"]);
                        ObjEmployeeJobDetails.Category = Convert.ToString(drExcel["Category"]).Trim();
                        ObjEmployeeJobDetails.Grade = Convert.ToString(drExcel["Grade"]).Trim();
                        ObjEmployeeJobDetails.Lavel = Convert.ToString(drExcel["Lavel"]).Trim();
                        ObjEmployeeJobDetails.Location = Convert.ToString(drExcel["Location"]).Trim();
                        ObjEmployeeJobDetails.Status = Convert.ToString(drExcel["Status"]).Trim();
                        ObjEmployeeJobDetails.AdharCardNo = Convert.ToString(drExcel["AdharCardNo"]).Trim();
                        ObjEmployeeJobDetails.PSNo = Convert.ToString(drExcel["PSNo"]).Trim();
                        ObjEmployeeJobDetails.ESIDispensary = Convert.ToString(drExcel["ESIDispensary"]).Trim();
                        ObjEmployeeJobDetails.PlacementBy = Convert.ToString(drExcel["PlacementBy"]).Trim();
                        ObjEmployeeJobDetails.BossReportTo = Convert.ToString(drExcel["BossReportTo"]).Trim();

                        ObjEmployeeJobDetails.CreatedBy = Convert.ToString(drExcel["CreatedBy"]).Trim();
                        ObjEmployeeJobDetails.ModifiedBy = Convert.ToString(drExcel["ModifiedBy"]).Trim();
                        ObjEmployeeJobDetails.ModifiedDate = Convert.ToDateTime(drExcel["CreatedDate"]);
                        ObjEmployeeJobDetails.ModifiedDate = Convert.ToDateTime(drExcel["ModifiedDate"]);
                        ObjEmployeeJobDetails.IsDeleted = Convert.ToInt32(drExcel["IsDeleted"]);

                        objEmployeeJobDetailsManager.SaveEmployeeJobDetails(ObjEmployeeJobDetails, ref da, ref lstErr);

                        foreach (ErrorHandlerClass objerr in lstErr)
                        {
                            if (objerr.Type == "E")
                            {
                                da.ROLLBACK_TRANSACTION();
                                break;
                            }
                        }
                    }
                    da.COMMIT_TRANSACTION();
                }
                catch (Exception ex)
                {
                    if (da != null)
                    {
                        da.ROLLBACK_TRANSACTION();
                    }
                    objErrorHandlerClass.Type = ErrorConstant.strAboartType;
                    objErrorHandlerClass.MsgId = 0;
                    objErrorHandlerClass.Module = ErrorConstant.strInsertModule;
                    objErrorHandlerClass.ModulePart = ErrorConstant.strMasterModule;
                    objErrorHandlerClass.Message = ex.Message.ToString();
                    objErrorHandlerClass.RowNo = 0;
                    objErrorHandlerClass.FieldName = "";
                    objErrorHandlerClass.LogCode = "";
                    lstErr.Add(objErrorHandlerClass);
                }
                finally
                {
                    if (da != null)
                    {
                        da.Close_Connection();
                        da = null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objXConn.Close();
            }
            return lstErr;
        }

        public ICollection<ErrorHandlerClass> BulkInsert4EmployeeQualificationDetails(string argExcelPath, string argQuery, string strTableName, string argFileExt, string argUserName)
        {
            DataTable dtExcel = null;
            EmployeeQualificationDetails ObjEmployeeQualificationDetails = null;
            string xConnStr = "";
            string strSheetName = "";
            DataSet dsExcel = new DataSet();
            DataTable dtTableSchema = new DataTable();
            OleDbConnection objXConn = null;
            OleDbDataAdapter objDataAdapter = new OleDbDataAdapter();
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();

            if (argFileExt.ToString() == ".xls")
            {
                xConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                "Data Source=" + argExcelPath.Trim() + ";" +
                "Extended Properties=Excel 8.0";
            }
            else
            {
                xConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=" + argExcelPath.Trim() + ";" +
                "Extended Properties=Excel 12.0";
            }

            try
            {
                objXConn = new OleDbConnection(xConnStr);
                objXConn.Open();

                dtTableSchema = objXConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (argFileExt.ToString() == ".xls")
                {
                    strSheetName = Convert.ToString(dtTableSchema.Rows[0]["TABLE_NAME"]);
                }
                else
                {
                    strSheetName = Convert.ToString(dtTableSchema.Rows[0]["TABLE_NAME"]);

                    if (strSheetName.IndexOf(@"_xlnm#_FilterDatabase") >= 0)
                    {
                        strSheetName = Convert.ToString(dtTableSchema.Rows[1]["TABLE_NAME"]);
                    }
                }
                argQuery = argQuery + " [" + strSheetName + "]";
                OleDbCommand objCommand = new OleDbCommand(argQuery, objXConn);
                objDataAdapter.SelectCommand = objCommand;
                objDataAdapter.Fill(dsExcel);
                dtExcel = dsExcel.Tables[0];

                /*****************************************/
                DataAccess da = new DataAccess();
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                try
                {
                    foreach (DataRow drExcel in dtExcel.Rows)
                    {
                        ObjEmployeeQualificationDetails = new EmployeeQualificationDetails();
                        ObjEmployeeQualificationDetails.EmployeeQualificationId = Convert.ToInt32(drExcel["EmployeeQualificationId"]);
                        ObjEmployeeQualificationDetails.EmployeeId = Convert.ToString(drExcel["EmployeeId"]).Trim();
                        ObjEmployeeQualificationDetails.ItemNo = Convert.ToInt32(drExcel["ItemNo"]);
                        ObjEmployeeQualificationDetails.ClassId = Convert.ToString(drExcel["ClassId"]).Trim();
                        ObjEmployeeQualificationDetails.ClassName = Convert.ToString(drExcel["ClassName"]).Trim();
                        ObjEmployeeQualificationDetails.CollegeOrUniversityName = Convert.ToString(drExcel["CollegeOrUniversityName"]).Trim();
                        ObjEmployeeQualificationDetails.Subject = Convert.ToString(drExcel["Subject"]).Trim();
                        ObjEmployeeQualificationDetails.PassingYear = Convert.ToString(drExcel["PassingYear"]).Trim();
                        ObjEmployeeQualificationDetails.Percentage = Convert.ToString(drExcel["Percentage"]).Trim();

                        ObjEmployeeQualificationDetails.CreatedBy = Convert.ToString(drExcel["CreatedBy"]).Trim();
                        ObjEmployeeQualificationDetails.ModifiedBy = Convert.ToString(drExcel["ModifiedBy"]).Trim();
                        ObjEmployeeQualificationDetails.ModifiedDate = Convert.ToDateTime(drExcel["CreatedDate"]);
                        ObjEmployeeQualificationDetails.ModifiedDate = Convert.ToDateTime(drExcel["ModifiedDate"]);
                        ObjEmployeeQualificationDetails.IsDeleted = Convert.ToInt32(drExcel["IsDeleted"]);

                        objEmployeeQualificationDetailsManager.SaveEmployeeQualificationDetails(ObjEmployeeQualificationDetails, ref da, ref lstErr);

                        foreach (ErrorHandlerClass objerr in lstErr)
                        {
                            if (objerr.Type == "E")
                            {
                                da.ROLLBACK_TRANSACTION();
                                break;
                            }
                        }
                    }
                    da.COMMIT_TRANSACTION();
                }
                catch (Exception ex)
                {
                    if (da != null)
                    {
                        da.ROLLBACK_TRANSACTION();
                    }
                    objErrorHandlerClass.Type = ErrorConstant.strAboartType;
                    objErrorHandlerClass.MsgId = 0;
                    objErrorHandlerClass.Module = ErrorConstant.strInsertModule;
                    objErrorHandlerClass.ModulePart = ErrorConstant.strMasterModule;
                    objErrorHandlerClass.Message = ex.Message.ToString();
                    objErrorHandlerClass.RowNo = 0;
                    objErrorHandlerClass.FieldName = "";
                    objErrorHandlerClass.LogCode = "";
                    lstErr.Add(objErrorHandlerClass);
                }
                finally
                {
                    if (da != null)
                    {
                        da.Close_Connection();
                        da = null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objXConn.Close();
            }
            return lstErr;
        }

        public ICollection<ErrorHandlerClass> BulkInsert4EmployeeEarningDetails(string argExcelPath, string argQuery, string strTableName, string argFileExt, string argUserName)
        {
            DataTable dtExcel = null;
            EmployeeEarningDetails ObjEmployeeEarningDetails = null;
            string xConnStr = "";
            string strSheetName = "";
            DataSet dsExcel = new DataSet();
            DataTable dtTableSchema = new DataTable();
            OleDbConnection objXConn = null;
            OleDbDataAdapter objDataAdapter = new OleDbDataAdapter();
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();

            if (argFileExt.ToString() == ".xls")
            {
                xConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                "Data Source=" + argExcelPath.Trim() + ";" +
                "Extended Properties=Excel 8.0";
            }
            else
            {
                xConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=" + argExcelPath.Trim() + ";" +
                "Extended Properties=Excel 12.0";
            }

            try
            {
                objXConn = new OleDbConnection(xConnStr);
                objXConn.Open();

                dtTableSchema = objXConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (argFileExt.ToString() == ".xls")
                {
                    strSheetName = Convert.ToString(dtTableSchema.Rows[0]["TABLE_NAME"]);
                }
                else
                {
                    strSheetName = Convert.ToString(dtTableSchema.Rows[0]["TABLE_NAME"]);

                    if (strSheetName.IndexOf(@"_xlnm#_FilterDatabase") >= 0)
                    {
                        strSheetName = Convert.ToString(dtTableSchema.Rows[1]["TABLE_NAME"]);
                    }
                }
                argQuery = argQuery + " [" + strSheetName + "]";
                OleDbCommand objCommand = new OleDbCommand(argQuery, objXConn);
                objDataAdapter.SelectCommand = objCommand;
                objDataAdapter.Fill(dsExcel);
                dtExcel = dsExcel.Tables[0];

                /*****************************************/
                DataAccess da = new DataAccess();
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                try
                {
                    foreach (DataRow drExcel in dtExcel.Rows)
                    {
                        ObjEmployeeEarningDetails = new EmployeeEarningDetails();
                        ObjEmployeeEarningDetails.EmployeeEarningId = Convert.ToInt32(drExcel["EmployeeEarningId"]);
                        ObjEmployeeEarningDetails.EmployeeId = Convert.ToString(drExcel["EmployeeId"]).Trim();
                        ObjEmployeeEarningDetails.ItemNo = Convert.ToInt32(drExcel["ItemNo"]);
                        ObjEmployeeEarningDetails.Allowances = Convert.ToString(drExcel["Allowances"]).Trim();
                        ObjEmployeeEarningDetails.Amount = Convert.ToDouble(drExcel["Amount"]);
                        ObjEmployeeEarningDetails.CalcOn = Convert.ToString(drExcel["CalcOn"]).Trim();
                        ObjEmployeeEarningDetails.PaymentMode = Convert.ToString(drExcel["PaymentMode"]);
                        ObjEmployeeEarningDetails.Bonus = Convert.ToInt32(drExcel["Bonus"]);
                        ObjEmployeeEarningDetails.OT = Convert.ToInt32(drExcel["OT"]);

                        ObjEmployeeEarningDetails.CreatedBy = Convert.ToString(drExcel["CreatedBy"]).Trim();
                        ObjEmployeeEarningDetails.ModifiedBy = Convert.ToString(drExcel["ModifiedBy"]).Trim();
                        ObjEmployeeEarningDetails.ModifiedDate = Convert.ToDateTime(drExcel["CreatedDate"]);
                        ObjEmployeeEarningDetails.ModifiedDate = Convert.ToDateTime(drExcel["ModifiedDate"]);
                        ObjEmployeeEarningDetails.IsDeleted = Convert.ToInt32(drExcel["IsDeleted"]);

                        objEmployeeEarningDetailsManager.SaveEmployeeEarningDetails(ObjEmployeeEarningDetails, ref da, ref lstErr);

                        foreach (ErrorHandlerClass objerr in lstErr)
                        {
                            if (objerr.Type == "E")
                            {
                                da.ROLLBACK_TRANSACTION();
                                break;
                            }
                        }
                    }
                    da.COMMIT_TRANSACTION();
                }
                catch (Exception ex)
                {
                    if (da != null)
                    {
                        da.ROLLBACK_TRANSACTION();
                    }
                    objErrorHandlerClass.Type = ErrorConstant.strAboartType;
                    objErrorHandlerClass.MsgId = 0;
                    objErrorHandlerClass.Module = ErrorConstant.strInsertModule;
                    objErrorHandlerClass.ModulePart = ErrorConstant.strMasterModule;
                    objErrorHandlerClass.Message = ex.Message.ToString();
                    objErrorHandlerClass.RowNo = 0;
                    objErrorHandlerClass.FieldName = "";
                    objErrorHandlerClass.LogCode = "";
                    lstErr.Add(objErrorHandlerClass);
                }
                finally
                {
                    if (da != null)
                    {
                        da.Close_Connection();
                        da = null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objXConn.Close();
            }
            return lstErr;
        }

        public ICollection<ErrorHandlerClass> BulkInsert4EmployeeDeductionDetails(string argExcelPath, string argQuery, string strTableName, string argFileExt, string argUserName)
        {
            DataTable dtExcel = null;
            EmployeeDeductionDetails ObjEmployeeDeductionDetails = null;
            string xConnStr = "";
            string strSheetName = "";
            DataSet dsExcel = new DataSet();
            DataTable dtTableSchema = new DataTable();
            OleDbConnection objXConn = null;
            OleDbDataAdapter objDataAdapter = new OleDbDataAdapter();
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();

            if (argFileExt.ToString() == ".xls")
            {
                xConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                "Data Source=" + argExcelPath.Trim() + ";" +
                "Extended Properties=Excel 8.0";
            }
            else
            {
                xConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=" + argExcelPath.Trim() + ";" +
                "Extended Properties=Excel 12.0";
            }

            try
            {
                objXConn = new OleDbConnection(xConnStr);
                objXConn.Open();

                dtTableSchema = objXConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (argFileExt.ToString() == ".xls")
                {
                    strSheetName = Convert.ToString(dtTableSchema.Rows[0]["TABLE_NAME"]);
                }
                else
                {
                    strSheetName = Convert.ToString(dtTableSchema.Rows[0]["TABLE_NAME"]);

                    if (strSheetName.IndexOf(@"_xlnm#_FilterDatabase") >= 0)
                    {
                        strSheetName = Convert.ToString(dtTableSchema.Rows[1]["TABLE_NAME"]);
                    }
                }
                argQuery = argQuery + " [" + strSheetName + "]";
                OleDbCommand objCommand = new OleDbCommand(argQuery, objXConn);
                objDataAdapter.SelectCommand = objCommand;
                objDataAdapter.Fill(dsExcel);
                dtExcel = dsExcel.Tables[0];

                /*****************************************/
                DataAccess da = new DataAccess();
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                try
                {
                    foreach (DataRow drExcel in dtExcel.Rows)
                    {
                        ObjEmployeeDeductionDetails = new EmployeeDeductionDetails();
                        ObjEmployeeDeductionDetails.EmployeeId = Convert.ToString(drExcel["EmployeeId"]).Trim();
                        ObjEmployeeDeductionDetails.ItemNo = Convert.ToInt32(drExcel["ItemNo"]);
                        ObjEmployeeDeductionDetails.Deductions = Convert.ToString(drExcel["Deductions"]).Trim();
                        ObjEmployeeDeductionDetails.DeductionPercetage = Convert.ToDouble(drExcel["DeductionPercetage"]);
                        ObjEmployeeDeductionDetails.DeductionAmount = Convert.ToDouble(drExcel["DeductionAmount"]);
                        ObjEmployeeDeductionDetails.DeductionCalcOn = Convert.ToString(drExcel["DeductionCalcOn"]).Trim();
                        ObjEmployeeDeductionDetails.DeductionPayMode = Convert.ToString(drExcel["DeductionPayMode"]);
                        ObjEmployeeDeductionDetails.DeductionLimit = Convert.ToInt32(drExcel["DeductionLimit"]);
                        ObjEmployeeDeductionDetails.LimitAmount = Convert.ToDouble(drExcel["LimitAmount"]);

                        ObjEmployeeDeductionDetails.CreatedBy = Convert.ToString(drExcel["CreatedBy"]).Trim();
                        ObjEmployeeDeductionDetails.ModifiedBy = Convert.ToString(drExcel["ModifiedBy"]).Trim();
                        ObjEmployeeDeductionDetails.ModifiedDate = Convert.ToDateTime(drExcel["CreatedDate"]);
                        ObjEmployeeDeductionDetails.ModifiedDate = Convert.ToDateTime(drExcel["ModifiedDate"]);
                        ObjEmployeeDeductionDetails.IsDeleted = Convert.ToInt32(drExcel["IsDeleted"]);

                        objEmployeeDeductionDetailsManager.SaveEmployeeDeductionDetails(ObjEmployeeDeductionDetails, ref da, ref lstErr);

                        foreach (ErrorHandlerClass objerr in lstErr)
                        {
                            if (objerr.Type == "E")
                            {
                                da.ROLLBACK_TRANSACTION();
                                break;
                            }
                        }
                    }
                    da.COMMIT_TRANSACTION();
                }
                catch (Exception ex)
                {
                    if (da != null)
                    {
                        da.ROLLBACK_TRANSACTION();
                    }
                    objErrorHandlerClass.Type = ErrorConstant.strAboartType;
                    objErrorHandlerClass.MsgId = 0;
                    objErrorHandlerClass.Module = ErrorConstant.strInsertModule;
                    objErrorHandlerClass.ModulePart = ErrorConstant.strMasterModule;
                    objErrorHandlerClass.Message = ex.Message.ToString();
                    objErrorHandlerClass.RowNo = 0;
                    objErrorHandlerClass.FieldName = "";
                    objErrorHandlerClass.LogCode = "";
                    lstErr.Add(objErrorHandlerClass);
                }
                finally
                {
                    if (da != null)
                    {
                        da.Close_Connection();
                        da = null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objXConn.Close();
            }
            return lstErr;
        }

        public ICollection<ErrorHandlerClass> BulkInsert4EmployeeLeaveDetails(string argExcelPath, string argQuery, string strTableName, string argFileExt, string argUserName)
        {
            DataTable dtExcel = null;
            EmployeeLeaveDetails ObjEmployeeLeaveDetails = null;
            string xConnStr = "";
            string strSheetName = "";
            DataSet dsExcel = new DataSet();
            DataTable dtTableSchema = new DataTable();
            OleDbConnection objXConn = null;
            OleDbDataAdapter objDataAdapter = new OleDbDataAdapter();
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();

            if (argFileExt.ToString() == ".xls")
            {
                xConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                "Data Source=" + argExcelPath.Trim() + ";" +
                "Extended Properties=Excel 8.0";
            }
            else
            {
                xConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=" + argExcelPath.Trim() + ";" +
                "Extended Properties=Excel 12.0";
            }

            try
            {
                objXConn = new OleDbConnection(xConnStr);
                objXConn.Open();

                dtTableSchema = objXConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (argFileExt.ToString() == ".xls")
                {
                    strSheetName = Convert.ToString(dtTableSchema.Rows[0]["TABLE_NAME"]);
                }
                else
                {
                    strSheetName = Convert.ToString(dtTableSchema.Rows[0]["TABLE_NAME"]);

                    if (strSheetName.IndexOf(@"_xlnm#_FilterDatabase") >= 0)
                    {
                        strSheetName = Convert.ToString(dtTableSchema.Rows[1]["TABLE_NAME"]);
                    }
                }
                argQuery = argQuery + " [" + strSheetName + "]";
                OleDbCommand objCommand = new OleDbCommand(argQuery, objXConn);
                objDataAdapter.SelectCommand = objCommand;
                objDataAdapter.Fill(dsExcel);
                dtExcel = dsExcel.Tables[0];

                /*****************************************/
                DataAccess da = new DataAccess();
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                try
                {
                    foreach (DataRow drExcel in dtExcel.Rows)
                    {
                        ObjEmployeeLeaveDetails = new EmployeeLeaveDetails();
                        ObjEmployeeLeaveDetails.EmployeeLeaveId = Convert.ToInt32(drExcel["EmployeeLeaveId"]);
                        ObjEmployeeLeaveDetails.EmployeeId = Convert.ToString(drExcel["EmployeeId"]).Trim();
                        ObjEmployeeLeaveDetails.ItemNo = Convert.ToInt32(drExcel["ItemNo"]);
                        ObjEmployeeLeaveDetails.LeaveType = Convert.ToString(drExcel["LeaveType"]).Trim();
                        ObjEmployeeLeaveDetails.Opening = Convert.ToInt32(drExcel["Opening"]);
                        ObjEmployeeLeaveDetails.MonthlyEarnedType = Convert.ToInt32(drExcel["MonthlyEarnedType"]);
                        ObjEmployeeLeaveDetails.MonthlyEarned = Convert.ToString(drExcel["MonthlyEarned"]).Trim();
                        ObjEmployeeLeaveDetails.EarningLeaveAllowedAfter = Convert.ToInt32(drExcel["EarningLeaveAllowedAfter"]);
                        ObjEmployeeLeaveDetails.EarningLeaveIn = Convert.ToString(drExcel["EarningLeaveIn"]).Trim();
                        ObjEmployeeLeaveDetails.ConsumedEL = Convert.ToInt32(drExcel["ConsumedEL"]);
                        ObjEmployeeLeaveDetails.CasulLeaveAllowedAfter = Convert.ToInt32(drExcel["CasulLeaveAllowedAfter"]);
                        ObjEmployeeLeaveDetails.CasualLeaveAllowedIn = Convert.ToString(drExcel["CasualLeaveAllowedIn"]).Trim();
                        ObjEmployeeLeaveDetails.EarnedCL = Convert.ToInt32(drExcel["EarnedCL"]);

                        ObjEmployeeLeaveDetails.CreatedBy = Convert.ToString(drExcel["CreatedBy"]).Trim();
                        ObjEmployeeLeaveDetails.ModifiedBy = Convert.ToString(drExcel["ModifiedBy"]).Trim();
                        ObjEmployeeLeaveDetails.ModifiedDate = Convert.ToDateTime(drExcel["CreatedDate"]);
                        ObjEmployeeLeaveDetails.ModifiedDate = Convert.ToDateTime(drExcel["ModifiedDate"]);
                        ObjEmployeeLeaveDetails.IsDeleted = Convert.ToInt32(drExcel["IsDeleted"]);

                        objEmployeeLeaveDetailsManager.SaveEmployeeLeaveDetails(ObjEmployeeLeaveDetails, ref da, ref lstErr);

                        foreach (ErrorHandlerClass objerr in lstErr)
                        {
                            if (objerr.Type == "E")
                            {
                                da.ROLLBACK_TRANSACTION();
                                break;
                            }
                        }
                    }
                    da.COMMIT_TRANSACTION();
                }
                catch (Exception ex)
                {
                    if (da != null)
                    {
                        da.ROLLBACK_TRANSACTION();
                    }
                    objErrorHandlerClass.Type = ErrorConstant.strAboartType;
                    objErrorHandlerClass.MsgId = 0;
                    objErrorHandlerClass.Module = ErrorConstant.strInsertModule;
                    objErrorHandlerClass.ModulePart = ErrorConstant.strMasterModule;
                    objErrorHandlerClass.Message = ex.Message.ToString();
                    objErrorHandlerClass.RowNo = 0;
                    objErrorHandlerClass.FieldName = "";
                    objErrorHandlerClass.LogCode = "";
                    lstErr.Add(objErrorHandlerClass);
                }
                finally
                {
                    if (da != null)
                    {
                        da.Close_Connection();
                        da = null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objXConn.Close();
            }
            return lstErr;
        }

        public ICollection<ErrorHandlerClass> BulkInsert4EmployeeLeftDetails(string argExcelPath, string argQuery, string strTableName, string argFileExt, string argUserName)
        {
            DataTable dtExcel = null;
            EmployeeLeftDetails ObjEmployeeLeftDetails = null;
            string xConnStr = "";
            string strSheetName = "";
            DataSet dsExcel = new DataSet();
            DataTable dtTableSchema = new DataTable();
            OleDbConnection objXConn = null;
            OleDbDataAdapter objDataAdapter = new OleDbDataAdapter();
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();

            if (argFileExt.ToString() == ".xls")
            {
                xConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                "Data Source=" + argExcelPath.Trim() + ";" +
                "Extended Properties=Excel 8.0";
            }
            else
            {
                xConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=" + argExcelPath.Trim() + ";" +
                "Extended Properties=Excel 12.0";
            }

            try
            {
                objXConn = new OleDbConnection(xConnStr);
                objXConn.Open();

                dtTableSchema = objXConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (argFileExt.ToString() == ".xls")
                {
                    strSheetName = Convert.ToString(dtTableSchema.Rows[0]["TABLE_NAME"]);
                }
                else
                {
                    strSheetName = Convert.ToString(dtTableSchema.Rows[0]["TABLE_NAME"]);

                    if (strSheetName.IndexOf(@"_xlnm#_FilterDatabase") >= 0)
                    {
                        strSheetName = Convert.ToString(dtTableSchema.Rows[1]["TABLE_NAME"]);
                    }
                }
                argQuery = argQuery + " [" + strSheetName + "]";
                OleDbCommand objCommand = new OleDbCommand(argQuery, objXConn);
                objDataAdapter.SelectCommand = objCommand;
                objDataAdapter.Fill(dsExcel);
                dtExcel = dsExcel.Tables[0];

                /*****************************************/
                DataAccess da = new DataAccess();
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                try
                {
                    foreach (DataRow drExcel in dtExcel.Rows)
                    {
                        ObjEmployeeLeftDetails = new EmployeeLeftDetails();
                        ObjEmployeeLeftDetails.EmployeeLeftId = Convert.ToInt32(drExcel["EmployeeLeftId"]);
                        ObjEmployeeLeftDetails.EmployeeId = Convert.ToString(drExcel["EmployeeId"]).Trim();
                        ObjEmployeeLeftDetails.LeftDate = Convert.ToString(drExcel["LeftDate"]);
                        ObjEmployeeLeftDetails.FullnFinal = Convert.ToInt32(drExcel["FullnFinal"]);
                        ObjEmployeeLeftDetails.LeftReason = Convert.ToString(drExcel["LeftReason"]).Trim();
                        ObjEmployeeLeftDetails.LeavingReason4PFDepartment = Convert.ToString(drExcel["LeavingReason4PFDepartment"]).Trim();
                        ObjEmployeeLeftDetails.LeavingReason4ESIDepartment = Convert.ToString(drExcel["LeavingReason4ESIDepartment"]).Trim();

                        ObjEmployeeLeftDetails.CreatedBy = Convert.ToString(drExcel["CreatedBy"]).Trim();
                        ObjEmployeeLeftDetails.ModifiedBy = Convert.ToString(drExcel["ModifiedBy"]).Trim();
                        ObjEmployeeLeftDetails.ModifiedDate = Convert.ToDateTime(drExcel["CreatedDate"]);
                        ObjEmployeeLeftDetails.ModifiedDate = Convert.ToDateTime(drExcel["ModifiedDate"]);
                        ObjEmployeeLeftDetails.IsDeleted = Convert.ToInt32(drExcel["IsDeleted"]);

                        objEmployeeLeftDetailsManager.SaveEmployeeLeftDetails(ObjEmployeeLeftDetails, ref da, ref lstErr);

                        foreach (ErrorHandlerClass objerr in lstErr)
                        {
                            if (objerr.Type == "E")
                            {
                                da.ROLLBACK_TRANSACTION();
                                break;
                            }
                        }
                    }
                    da.COMMIT_TRANSACTION();
                }
                catch (Exception ex)
                {
                    if (da != null)
                    {
                        da.ROLLBACK_TRANSACTION();
                    }
                    objErrorHandlerClass.Type = ErrorConstant.strAboartType;
                    objErrorHandlerClass.MsgId = 0;
                    objErrorHandlerClass.Module = ErrorConstant.strInsertModule;
                    objErrorHandlerClass.ModulePart = ErrorConstant.strMasterModule;
                    objErrorHandlerClass.Message = ex.Message.ToString();
                    objErrorHandlerClass.RowNo = 0;
                    objErrorHandlerClass.FieldName = "";
                    objErrorHandlerClass.LogCode = "";
                    lstErr.Add(objErrorHandlerClass);
                }
                finally
                {
                    if (da != null)
                    {
                        da.Close_Connection();
                        da = null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objXConn.Close();
            }
            return lstErr;
        }

        public ICollection<ErrorHandlerClass> BulkInsert4EmployeeOtherDetails(string argExcelPath, string argQuery, string strTableName, string argFileExt, string argUserName)
        {
            DataTable dtExcel = null;
            EmployeeOtherDetails ObjEmployeeOtherDetails = null;
            string xConnStr = "";
            string strSheetName = "";
            DataSet dsExcel = new DataSet();
            DataTable dtTableSchema = new DataTable();
            OleDbConnection objXConn = null;
            OleDbDataAdapter objDataAdapter = new OleDbDataAdapter();
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();

            if (argFileExt.ToString() == ".xls")
            {
                xConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                "Data Source=" + argExcelPath.Trim() + ";" +
                "Extended Properties=Excel 8.0";
            }
            else
            {
                xConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=" + argExcelPath.Trim() + ";" +
                "Extended Properties=Excel 12.0";
            }

            try
            {
                objXConn = new OleDbConnection(xConnStr);
                objXConn.Open();

                dtTableSchema = objXConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (argFileExt.ToString() == ".xls")
                {
                    strSheetName = Convert.ToString(dtTableSchema.Rows[0]["TABLE_NAME"]);
                }
                else
                {
                    strSheetName = Convert.ToString(dtTableSchema.Rows[0]["TABLE_NAME"]);

                    if (strSheetName.IndexOf(@"_xlnm#_FilterDatabase") >= 0)
                    {
                        strSheetName = Convert.ToString(dtTableSchema.Rows[1]["TABLE_NAME"]);
                    }
                }
                argQuery = argQuery + " [" + strSheetName + "]";
                OleDbCommand objCommand = new OleDbCommand(argQuery, objXConn);
                objDataAdapter.SelectCommand = objCommand;
                objDataAdapter.Fill(dsExcel);
                dtExcel = dsExcel.Tables[0];

                /*****************************************/
                DataAccess da = new DataAccess();
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                try
                {
                    foreach (DataRow drExcel in dtExcel.Rows)
                    {
                        ObjEmployeeOtherDetails = new EmployeeOtherDetails();
                        ObjEmployeeOtherDetails.EmployeeOtherId = Convert.ToInt32(drExcel["EmployeeOtherId"]);
                        ObjEmployeeOtherDetails.EmployeeId = Convert.ToString(drExcel["EmployeeId"]).Trim();
                        ObjEmployeeOtherDetails.SalaryType = Convert.ToString(drExcel["SalaryType"]).Trim();

                        ObjEmployeeOtherDetails.Skilled = Convert.ToString(drExcel["Skilled"]).Trim();
                        ObjEmployeeOtherDetails.Category = Convert.ToString(drExcel["Category"]).Trim();
                        ObjEmployeeOtherDetails.OTRateType = Convert.ToString(drExcel["OTRateType"]).Trim();
                        ObjEmployeeOtherDetails.OTRate = Convert.ToDouble(drExcel["OTRate"]);
                        ObjEmployeeOtherDetails.LateRateType = Convert.ToString(drExcel["LateRateType"]).Trim();
                        ObjEmployeeOtherDetails.LatePenaltyRate = Convert.ToDouble(drExcel["LatePenaltyRate"]);
                        ObjEmployeeOtherDetails.IncrementDueDate = Convert.ToString(drExcel["IncrementDueDate"]);
                        ObjEmployeeOtherDetails.IncrementMonth = Convert.ToString(drExcel["IncrementMonth"]).Trim();
                        ObjEmployeeOtherDetails.BasicPayIncrementAs = Convert.ToInt32(drExcel["BasicPayIncrementAs"]);
                        ObjEmployeeOtherDetails.IdentityCardValidity = Convert.ToString(drExcel["IdentityCardValidity"]);
                        ObjEmployeeOtherDetails.SalaryCalculationDays = Convert.ToInt32(drExcel["SalaryCalculationDays"]);
                        ObjEmployeeOtherDetails.GeneralWorkingHours = Convert.ToInt32(drExcel["GeneralWorkingHours"]);
                        ObjEmployeeOtherDetails.OTCalculationDays = Convert.ToInt32(drExcel["OTCalculationDays"]);
                        ObjEmployeeOtherDetails.OTWorkingHours = Convert.ToInt32(drExcel["OTWorkingHours"]);
                        ObjEmployeeOtherDetails.TotalDaysInMonth = Convert.ToInt32(drExcel["TotalDaysInMonth"]);

                        ObjEmployeeOtherDetails.CreatedBy = Convert.ToString(drExcel["CreatedBy"]).Trim();
                        ObjEmployeeOtherDetails.ModifiedBy = Convert.ToString(drExcel["ModifiedBy"]).Trim();
                        ObjEmployeeOtherDetails.ModifiedDate = Convert.ToDateTime(drExcel["CreatedDate"]);
                        ObjEmployeeOtherDetails.ModifiedDate = Convert.ToDateTime(drExcel["ModifiedDate"]);
                        ObjEmployeeOtherDetails.IsDeleted = Convert.ToInt32(drExcel["IsDeleted"]);

                        objEmployeeOtherDetailsManager.SaveEmployeeOtherDetails(ObjEmployeeOtherDetails, ref da, ref lstErr);

                        foreach (ErrorHandlerClass objerr in lstErr)
                        {
                            if (objerr.Type == "E")
                            {
                                da.ROLLBACK_TRANSACTION();
                                break;
                            }
                        }
                    }
                    da.COMMIT_TRANSACTION();
                }
                catch (Exception ex)
                {
                    if (da != null)
                    {
                        da.ROLLBACK_TRANSACTION();
                    }
                    objErrorHandlerClass.Type = ErrorConstant.strAboartType;
                    objErrorHandlerClass.MsgId = 0;
                    objErrorHandlerClass.Module = ErrorConstant.strInsertModule;
                    objErrorHandlerClass.ModulePart = ErrorConstant.strMasterModule;
                    objErrorHandlerClass.Message = ex.Message.ToString();
                    objErrorHandlerClass.RowNo = 0;
                    objErrorHandlerClass.FieldName = "";
                    objErrorHandlerClass.LogCode = "";
                    lstErr.Add(objErrorHandlerClass);
                }
                finally
                {
                    if (da != null)
                    {
                        da.Close_Connection();
                        da = null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objXConn.Close();
            }
            return lstErr;
        }

        #region SetObjectInfo
        public ICollection<EmployeeMasterDetails> setObjectInfor4Employee()
        {
            List<EmployeeMasterDetails> lst = new List<EmployeeMasterDetails>();
            EmployeeMasterDetails ObjEmployeeMasterDetails = null;
            foreach (DataRow drExcel in dtExcel.Rows)
            {
                ObjEmployeeMasterDetails = new EmployeeMasterDetails();
                ObjEmployeeMasterDetails.EmployeeId = Convert.ToString(drExcel["EmployeeId"]).Trim();
                ObjEmployeeMasterDetails.PCardNo = Convert.ToString(drExcel["PCardNo"]).Trim();
                ObjEmployeeMasterDetails.EmployeeType = Convert.ToString(drExcel["EmployeeTypeId"]).Trim();
                ObjEmployeeMasterDetails.FirstName = Convert.ToString(drExcel["FirstName"]).Trim();
                ObjEmployeeMasterDetails.MiddleName = Convert.ToString(drExcel["MiddleName"]).Trim();
                ObjEmployeeMasterDetails.LastName = Convert.ToString(drExcel["LastName"]).Trim();
                ObjEmployeeMasterDetails.FatherName = Convert.ToString(drExcel["FatherName"]).Trim();
                ObjEmployeeMasterDetails.Designation = Convert.ToString(drExcel["Designation"]).Trim();
                ObjEmployeeMasterDetails.Unit = Convert.ToString(drExcel["Unit"]).Trim();
                ObjEmployeeMasterDetails.SubUnit = Convert.ToString(drExcel["SubUnit"]);
                ObjEmployeeMasterDetails.Department = Convert.ToString(drExcel["Department"]).Trim();
                ObjEmployeeMasterDetails.PFNo = Convert.ToString(drExcel["PFNo"]).Trim();
                ObjEmployeeMasterDetails.ESINo = Convert.ToString(drExcel["ESINo"]).Trim();
                ObjEmployeeMasterDetails.AliasName = Convert.ToString(drExcel["AliasName"]).Trim();
                ObjEmployeeMasterDetails.NickName = Convert.ToString(drExcel["NickName"]).Trim();
                ObjEmployeeMasterDetails.LocalAddress = Convert.ToString(drExcel["LocalAddress"]).Trim();
                ObjEmployeeMasterDetails.City = Convert.ToString(drExcel["City"]).Trim();
                ObjEmployeeMasterDetails.ZipCode = Convert.ToString(drExcel["ZipCode"]);
                ObjEmployeeMasterDetails.Country = Convert.ToString(drExcel["Country"]).Trim();
                ObjEmployeeMasterDetails.State = Convert.ToString(drExcel["State"]).Trim();
                ObjEmployeeMasterDetails.ContactNo = Convert.ToString(drExcel["ContactNo"]).Trim();
                ObjEmployeeMasterDetails.EmailId = Convert.ToString(drExcel["EmailId"]).Trim();
                ObjEmployeeMasterDetails.ParamAddress = Convert.ToString(drExcel["ParamAddress"]).Trim();
                ObjEmployeeMasterDetails.ParamCity = Convert.ToString(drExcel["ParamCity"]).Trim();
                ObjEmployeeMasterDetails.ParamZipCode = Convert.ToString(drExcel["ParamZipCode"]).Trim();
                ObjEmployeeMasterDetails.ParamCountry = Convert.ToString(drExcel["ParamCountry"]);
                ObjEmployeeMasterDetails.ParamState = Convert.ToString(drExcel["ParamState"]).Trim();
                ObjEmployeeMasterDetails.PlaceOfBirth = Convert.ToString(drExcel["PlaceOfBirth"]).Trim();
                ObjEmployeeMasterDetails.RationCardNo = Convert.ToString(drExcel["RationCardNo"]).Trim();
                ObjEmployeeMasterDetails.VoterId = Convert.ToString(drExcel["VoterId"]).Trim();
                ObjEmployeeMasterDetails.PassportNo = Convert.ToString(drExcel["PassportNo"]).Trim();
                ObjEmployeeMasterDetails.PANNo = Convert.ToString(drExcel["PANCardNo"]).Trim();
                ObjEmployeeMasterDetails.BankName = Convert.ToString(drExcel["BankDetail"]).Trim();
                ObjEmployeeMasterDetails.AccountNo = Convert.ToString(drExcel["BankAccountNo"]).Trim();
                ObjEmployeeMasterDetails.AccountHolderName = Convert.ToString(drExcel["AccountHolderName"]).Trim();
                ObjEmployeeMasterDetails.Branch = Convert.ToString(drExcel["Branch"]).Trim();
                ObjEmployeeMasterDetails.DLNo = Convert.ToString(drExcel["DLNo"]).Trim();
                ObjEmployeeMasterDetails.ValidUpTo = Convert.ToString(drExcel["ValidUpTo"]).Trim();
                ObjEmployeeMasterDetails.IdentityMarks = Convert.ToString(drExcel["IdentityMarks"]);
                ObjEmployeeMasterDetails.Religion = Convert.ToString(drExcel["Religion"]).Trim();
                ObjEmployeeMasterDetails.Nationality = Convert.ToString(drExcel["Nationality"]).Trim();
                ObjEmployeeMasterDetails.DateOfBirth = Convert.ToString(drExcel["DateOfBirth"]).Trim();
                ObjEmployeeMasterDetails.RetirementDate = Convert.ToString(drExcel["RetirementDate"]).Trim();
                ObjEmployeeMasterDetails.Gender = Convert.ToString(drExcel["Gender"]).Trim();
                if (Convert.ToString(drExcel["Height"]).Trim() != "")
                {
                    ObjEmployeeMasterDetails.Height = Convert.ToDouble(drExcel["Height"]);
                }
                else
                {
                    ObjEmployeeMasterDetails.Height = 0.0;
                }
                ObjEmployeeMasterDetails.BloodGroup = Convert.ToString(drExcel["BloodGroup"]).Trim();
                ObjEmployeeMasterDetails.MaritalStatus = Convert.ToString(drExcel["MaritalStatus"]);
                ObjEmployeeMasterDetails.Date = Convert.ToString(drExcel["Date"]).Trim();
                ObjEmployeeMasterDetails.LoginId = Convert.ToString(drExcel["LoginId"]).Trim();
                ObjEmployeeMasterDetails.Password = Convert.ToString(drExcel["Password"]).Trim();
                ObjEmployeeMasterDetails.EmployeePic = Convert.ToString(drExcel["EmployeePic"]).Trim();
                ObjEmployeeMasterDetails.CityType = Convert.ToString(drExcel["CityType"]).Trim();

                ObjEmployeeMasterDetails.CreatedBy = Convert.ToString(drExcel["CreatedBy"]).Trim();
                ObjEmployeeMasterDetails.ModifiedBy = Convert.ToString(drExcel["ModifiedBy"]).Trim();
                ObjEmployeeMasterDetails.IsDeleted = Convert.ToInt32(drExcel["IsDeleted"]);
                lst.Add(ObjEmployeeMasterDetails);
            }
            return lst;
        }

        public ICollection<EmployeeJobDetails> setObjectInfor4Job()
        {
            List<EmployeeJobDetails> lst = new List<EmployeeJobDetails>();
            EmployeeJobDetails ObjEmployeeJobDetails = null;

            foreach (DataRow drExcel in dtExcel4Job.Rows)
            {
                ObjEmployeeJobDetails = new EmployeeJobDetails();
                //ObjEmployeeJobDetails.EmployeeJobId = Convert.ToInt32(drExcel["EmployeeJobId"]);
                ObjEmployeeJobDetails.EmployeeId = Convert.ToString(drExcel["EmployeeId"]).Trim();

                ObjEmployeeJobDetails.ApplicationDate = Convert.ToString(drExcel["ApplicationDate"]);
                ObjEmployeeJobDetails.InterviewDate = Convert.ToString(drExcel["InterviewDate"]);
                ObjEmployeeJobDetails.JoiningDate = Convert.ToString(drExcel["JoiningDate"]);
                ObjEmployeeJobDetails.ConfirmationDate = Convert.ToString(drExcel["ConfirmationDate"]);
                ObjEmployeeJobDetails.AppointmentLetterIssueDate = Convert.ToString(drExcel["AppointmentLetterIssueDate"]);
                ObjEmployeeJobDetails.SalartyStopAfter = Convert.ToString(drExcel["SalartyStopAfter"]);
                ObjEmployeeJobDetails.ContractStartDate = Convert.ToString(drExcel["ContractStartDate"]);
                ObjEmployeeJobDetails.ContractEndDate = Convert.ToString(drExcel["ContractEndDate"]);
                ObjEmployeeJobDetails.DateOfTransfer = Convert.ToString(drExcel["DateOfTransfer"]);
                ObjEmployeeJobDetails.PFStartDate = Convert.ToString(drExcel["PFStartDate"]);
                ObjEmployeeJobDetails.EPSStartDate = Convert.ToString(drExcel["EPSStartDate"]);
                ObjEmployeeJobDetails.ESISStartDate = Convert.ToString(drExcel["ESISStartDate"]);
                ObjEmployeeJobDetails.Category = Convert.ToString(drExcel["Category"]).Trim();
                ObjEmployeeJobDetails.Grade = Convert.ToString(drExcel["Grade"]).Trim();
                ObjEmployeeJobDetails.Lavel = Convert.ToString(drExcel["Lavel"]).Trim();
                ObjEmployeeJobDetails.Location = Convert.ToString(drExcel["Location"]).Trim();
                ObjEmployeeJobDetails.Status = Convert.ToString(drExcel["Status"]).Trim();
                ObjEmployeeJobDetails.AdharCardNo = Convert.ToString(drExcel["AdharCardNo"]).Trim();
                ObjEmployeeJobDetails.PSNo = Convert.ToString(drExcel["PSNo"]).Trim();
                ObjEmployeeJobDetails.NSSNo = Convert.ToString(drExcel["NSSNo"]).Trim();
                ObjEmployeeJobDetails.ESIDispensary = Convert.ToString(drExcel["ESIDispensary"]).Trim();
                ObjEmployeeJobDetails.PlacementBy = Convert.ToString(drExcel["PlacementBy"]).Trim();
                ObjEmployeeJobDetails.BossReportTo = Convert.ToString(drExcel["BossReportTo"]).Trim();

                ObjEmployeeJobDetails.CreatedBy = Convert.ToString(drExcel["CreatedBy"]).Trim();
                ObjEmployeeJobDetails.ModifiedBy = Convert.ToString(drExcel["ModifiedBy"]).Trim();
                ObjEmployeeJobDetails.IsDeleted = Convert.ToInt32(drExcel["IsDeleted"]);
                lst.Add(ObjEmployeeJobDetails);
            }
            return lst;
        }

        public ICollection<EmployeeQualificationDetails> SetObjectInfo4Qualification()
        {
            List<EmployeeQualificationDetails> lst = new List<EmployeeQualificationDetails>();
            EmployeeQualificationDetails ObjEmployeeQualificationDetails = null;

            foreach (DataRow drExcel in dtExcel4Qualification.Rows)
            {
                ObjEmployeeQualificationDetails = new EmployeeQualificationDetails();
                //ObjEmployeeQualificationDetails.EmployeeQualificationId = Convert.ToInt32(drExcel["EmployeeQualificationId"]);
                ObjEmployeeQualificationDetails.EmployeeId = Convert.ToString(drExcel["EmployeeId"]).Trim();
                ObjEmployeeQualificationDetails.ItemNo = Convert.ToInt32(drExcel["ItemNo"]);
                ObjEmployeeQualificationDetails.ClassId = Convert.ToString(drExcel["ClassId"]).Trim();
                ObjEmployeeQualificationDetails.ClassName = Convert.ToString(drExcel["ClassName"]).Trim();
                ObjEmployeeQualificationDetails.CollegeOrUniversityName = Convert.ToString(drExcel["CollegeOrUniversityName"]).Trim();
                ObjEmployeeQualificationDetails.Subject = Convert.ToString(drExcel["Subject"]).Trim();
                ObjEmployeeQualificationDetails.PassingYear = Convert.ToString(drExcel["PassingYear"]).Trim();
                ObjEmployeeQualificationDetails.Percentage = Convert.ToString(drExcel["Percentage"]).Trim();

                ObjEmployeeQualificationDetails.CreatedBy = Convert.ToString(drExcel["CreatedBy"]).Trim();
                ObjEmployeeQualificationDetails.ModifiedBy = Convert.ToString(drExcel["ModifiedBy"]).Trim();
                ObjEmployeeQualificationDetails.IsDeleted = Convert.ToInt32(drExcel["IsDeleted"]);
                lst.Add(ObjEmployeeQualificationDetails);
            }
            return lst;
        }

        public ICollection<EmployeeEarningDetails> SetObjectInfo4Earnings()
        {
            List<EmployeeEarningDetails> lst = new List<EmployeeEarningDetails>();
            EmployeeEarningDetails ObjEmployeeEarningDetails = null;

            foreach (DataRow drExcel in dtExcel4Earning.Rows)
            {
                ObjEmployeeEarningDetails = new EmployeeEarningDetails();
                //ObjEmployeeEarningDetails.EmployeeEarningId = Convert.ToInt32(drExcel["EmployeeEarningId"]);
                ObjEmployeeEarningDetails.EmployeeId = Convert.ToString(drExcel["EmployeeId"]).Trim();
                ObjEmployeeEarningDetails.ItemNo = Convert.ToInt32(drExcel["ItemNo"]);
                ObjEmployeeEarningDetails.Allowances = Convert.ToString(drExcel["Allowances"]).Trim();
                ObjEmployeeEarningDetails.Amount = Convert.ToDouble(drExcel["Amount"]);
                ObjEmployeeEarningDetails.CalcOn = Convert.ToString(drExcel["CalcOn"]).Trim();
                ObjEmployeeEarningDetails.PaymentMode = Convert.ToString(drExcel["PaymentMode"]);
                ObjEmployeeEarningDetails.Bonus = Convert.ToInt32(drExcel["Bonus"]);
                ObjEmployeeEarningDetails.OT = Convert.ToInt32(drExcel["OT"]);

                ObjEmployeeEarningDetails.CreatedBy = Convert.ToString(drExcel["CreatedBy"]).Trim();
                ObjEmployeeEarningDetails.ModifiedBy = Convert.ToString(drExcel["ModifiedBy"]).Trim();
                ObjEmployeeEarningDetails.IsDeleted = Convert.ToInt32(drExcel["IsDeleted"]);
                lst.Add(ObjEmployeeEarningDetails);

            }
            return lst;
        }

        public ICollection<EmployeeDeductionDetails> SetObjectInfo4Deductions()
        {
            List<EmployeeDeductionDetails> lst = new List<EmployeeDeductionDetails>();
            EmployeeDeductionDetails ObjEmployeeDeductionDetails = null;

            foreach (DataRow drExcel in dtExcel4Deduction.Rows)
            {
                ObjEmployeeDeductionDetails = new EmployeeDeductionDetails();
                ObjEmployeeDeductionDetails.EmployeeId = Convert.ToString(drExcel["EmployeeId"]).Trim();
                ObjEmployeeDeductionDetails.ItemNo = Convert.ToInt32(drExcel["ItemNo"]);
                ObjEmployeeDeductionDetails.Deductions = Convert.ToString(drExcel["Deductions"]).Trim();
                ObjEmployeeDeductionDetails.DeductionPercetage = Convert.ToDouble(drExcel["DeductionPercetage"]);
                ObjEmployeeDeductionDetails.DeductionAmount = Convert.ToDouble(drExcel["DeductionAmount"]);
                ObjEmployeeDeductionDetails.DeductionCalcOn = Convert.ToString(drExcel["DeductionCalcOn"]).Trim();
                ObjEmployeeDeductionDetails.DeductionPayMode = Convert.ToString(drExcel["DeductionPayMode"]);
                ObjEmployeeDeductionDetails.DeductionLimit = Convert.ToInt32(drExcel["DeductionLimit"]);
                ObjEmployeeDeductionDetails.LimitAmount = Convert.ToDouble(drExcel["LimitAmount"]);

                ObjEmployeeDeductionDetails.CreatedBy = Convert.ToString(drExcel["CreatedBy"]).Trim();
                ObjEmployeeDeductionDetails.ModifiedBy = Convert.ToString(drExcel["ModifiedBy"]).Trim();
                ObjEmployeeDeductionDetails.IsDeleted = Convert.ToInt32(drExcel["IsDeleted"]);

                lst.Add(ObjEmployeeDeductionDetails);

            }
            return lst;
        }

        public ICollection<EmployeeLeaveDetails> SetObjectInfo4Leaves()
        {
            List<EmployeeLeaveDetails> lst = new List<EmployeeLeaveDetails>();
            EmployeeLeaveDetails ObjEmployeeLeaveDetails = null;

            foreach (DataRow drExcel in dtExcel4Leave.Rows)
            {
                ObjEmployeeLeaveDetails = new EmployeeLeaveDetails();
                //ObjEmployeeLeaveDetails.EmployeeLeaveId = Convert.ToInt32(drExcel["EmployeeLeaveId"]);
                ObjEmployeeLeaveDetails.EmployeeId = Convert.ToString(drExcel["EmployeeId"]).Trim();
                ObjEmployeeLeaveDetails.ItemNo = Convert.ToInt32(drExcel["ItemNo"]);
                ObjEmployeeLeaveDetails.LeaveType = Convert.ToString(drExcel["LeaveType"]).Trim();
                ObjEmployeeLeaveDetails.Opening = Convert.ToInt32(drExcel["Opening"]);
                ObjEmployeeLeaveDetails.MonthlyEarnedType = Convert.ToInt32(drExcel["MonthlyEarnedType"]);
                ObjEmployeeLeaveDetails.MonthlyEarned = Convert.ToString(drExcel["MonthlyEarned"]).Trim();
                ObjEmployeeLeaveDetails.EarningLeaveAllowedAfter = Convert.ToInt32(drExcel["EarningLeaveAllowedAfter"]);
                ObjEmployeeLeaveDetails.EarningLeaveIn = Convert.ToString(drExcel["EarningLeaveIn"]).Trim();
                ObjEmployeeLeaveDetails.ConsumedEL = Convert.ToInt32(drExcel["ConsumedEL"]);
                ObjEmployeeLeaveDetails.CasulLeaveAllowedAfter = Convert.ToInt32(drExcel["CasulLeaveAllowedAfter"]);
                ObjEmployeeLeaveDetails.CasualLeaveAllowedIn = Convert.ToString(drExcel["CasualLeaveAllowedIn"]).Trim();
                ObjEmployeeLeaveDetails.EarnedCL = Convert.ToInt32(drExcel["EarnedCL"]);

                ObjEmployeeLeaveDetails.CreatedBy = Convert.ToString(drExcel["CreatedBy"]).Trim();
                ObjEmployeeLeaveDetails.ModifiedBy = Convert.ToString(drExcel["ModifiedBy"]).Trim();
                ObjEmployeeLeaveDetails.IsDeleted = Convert.ToInt32(drExcel["IsDeleted"]);

                lst.Add(ObjEmployeeLeaveDetails);

            }
            return lst;
        }

        public ICollection<EmployeeLeftDetails> setObjectInfor4Left()
        {
            List<EmployeeLeftDetails> lst = new List<EmployeeLeftDetails>();
            EmployeeLeftDetails ObjEmployeeLeftDetails = null;

            foreach (DataRow drExcel in dtExcel4Left.Rows)
            {
                ObjEmployeeLeftDetails = new EmployeeLeftDetails();
                //ObjEmployeeLeftDetails.EmployeeLeftId = Convert.ToInt32(drExcel["EmployeeLeftId"]);
                ObjEmployeeLeftDetails.EmployeeId = Convert.ToString(drExcel["EmployeeId"]).Trim();
                ObjEmployeeLeftDetails.LeftDate = Convert.ToString(drExcel["LeftDate"]);
                ObjEmployeeLeftDetails.FullnFinal = Convert.ToInt32(drExcel["FullnFinal"]);
                ObjEmployeeLeftDetails.LeftReason = Convert.ToString(drExcel["LeftReason"]).Trim();
                ObjEmployeeLeftDetails.LeavingReason4PFDepartment = Convert.ToString(drExcel["LeavingReason4PFDepartment"]).Trim();
                ObjEmployeeLeftDetails.LeavingReason4ESIDepartment = Convert.ToString(drExcel["LeavingReason4ESIDepartment"]).Trim();

                ObjEmployeeLeftDetails.CreatedBy = Convert.ToString(drExcel["CreatedBy"]).Trim();
                ObjEmployeeLeftDetails.ModifiedBy = Convert.ToString(drExcel["ModifiedBy"]).Trim();
                ObjEmployeeLeftDetails.IsDeleted = Convert.ToInt32(drExcel["IsDeleted"]);

                lst.Add(ObjEmployeeLeftDetails);

            }
            return lst;
        }

        public ICollection<EmployeeOtherDetails> setObjectInfor4Other()
        {
            List<EmployeeOtherDetails> lst = new List<EmployeeOtherDetails>();
            EmployeeOtherDetails ObjEmployeeOtherDetails = null;

            foreach (DataRow drExcel in dtExcel4Other.Rows)
            {
                ObjEmployeeOtherDetails = new EmployeeOtherDetails();
                //ObjEmployeeOtherDetails.EmployeeOtherId = Convert.ToInt32(drExcel["EmployeeOtherId"]);
                ObjEmployeeOtherDetails.EmployeeId = Convert.ToString(drExcel["EmployeeId"]).Trim();
                ObjEmployeeOtherDetails.SalaryType = Convert.ToString(drExcel["SalaryType"]).Trim();

                ObjEmployeeOtherDetails.Skilled = Convert.ToString(drExcel["Skilled"]).Trim();
                ObjEmployeeOtherDetails.Category = Convert.ToString(drExcel["Category"]).Trim();
                ObjEmployeeOtherDetails.OTRateType = Convert.ToString(drExcel["OTRateType"]).Trim();
                ObjEmployeeOtherDetails.OTRate = Convert.ToDouble(drExcel["OTRate"]);
                ObjEmployeeOtherDetails.LateRateType = Convert.ToString(drExcel["LateRateType"]).Trim();
                ObjEmployeeOtherDetails.LatePenaltyRate = Convert.ToDouble(drExcel["LatePenaltyRate"]);
                ObjEmployeeOtherDetails.IncrementDueDate = Convert.ToString(drExcel["IncrementDueDate"]);
                ObjEmployeeOtherDetails.IncrementMonth = Convert.ToString(drExcel["IncrementMonth"]).Trim();
                ObjEmployeeOtherDetails.BasicPayIncrementAs = Convert.ToInt32(drExcel["BasicPayIncrementAs"]);
                ObjEmployeeOtherDetails.IdentityCardValidity = Convert.ToString(drExcel["IdentityCardValidity"]);
                ObjEmployeeOtherDetails.SalaryCalculationDays = Convert.ToInt32(drExcel["SalaryCalculationDays"]);
                ObjEmployeeOtherDetails.GeneralWorkingHours = Convert.ToInt32(drExcel["GeneralWorkingHours"]);
                ObjEmployeeOtherDetails.OTCalculationDays = Convert.ToInt32(drExcel["OTCalculationDays"]);
                ObjEmployeeOtherDetails.OTWorkingHours = Convert.ToInt32(drExcel["OTWorkingHours"]);
                ObjEmployeeOtherDetails.TotalDaysInMonth = Convert.ToInt32(drExcel["TotalDaysInMonth"]);

                ObjEmployeeOtherDetails.CreatedBy = Convert.ToString(drExcel["CreatedBy"]).Trim();
                ObjEmployeeOtherDetails.ModifiedBy = Convert.ToString(drExcel["ModifiedBy"]).Trim();
                ObjEmployeeOtherDetails.IsDeleted = Convert.ToInt32(drExcel["IsDeleted"]);

                lst.Add(ObjEmployeeOtherDetails);

            }
            return lst;
        }
        #endregion

    }

}
