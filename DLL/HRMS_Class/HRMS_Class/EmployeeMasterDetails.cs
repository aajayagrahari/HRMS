using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HRMS_Class
{
    [Serializable]
    public class EmployeeMasterDetails
    {
        private string _EmployeeId;
        private string _EmployeeType;
        private string _LoginId;
        private string _Password;
        private string _PCardNo;
        private string _FirstName;
        private string _MiddleName;
        private string _LastName;
        private string _FatherName;
        private string _Designation;
        private string _Unit;
        private string _SubUnit;
        private string _Department;
        private string _PFNo;
        private string _ESINo;
        private string _AliasName;
        private string _NickName;
        private string _LocalAddress;
        private string _City;
        private string _ZipCode;
        private string _Country;
        private string _State;
        private string _ContactNo;
        private string _EmailId;
        private string _ParamAddress;
        private string _ParamCity;
        private string _ParamZipCode;
        private string _ParamCountry;
        private string _ParamState;
        private string _PlaceOfBirth;
        private string _RationCardNo;
        private string _VoterId;
        private string _PassportNo;
        private string _PANNo;
        private string _BankName;
        private string _AccountNo;
        private string _AccountHolderName;
        private string _Branch;
        private string _DLNo;
        private string _ValidUpTo;
        private string _IdentityMarks;
        private string _Religion;
        private string _Nationality;
        private string _DateOfBirth;
        private string _RetirementDate;
        private string _Gender;
        private double _Height;
        private string _BloodGroup;
        private string _MaritalStatus;
        private string _Date;
        private string _EmployeePic;
        private string _CityType;
        private string _CreatedBy;
        private string _ModifiedBy;
        private DateTime _CreatedDate;
        private DateTime _ModifiedDate;
        private int _IsDeleted;


        public string EmployeeId
        {
            get
            {
                return _EmployeeId;
            }
            set
            {
                _EmployeeId = value;
            }
        }

        public string EmployeeType
        {
            get
            {
                return _EmployeeType;
            }
            set
            {
                _EmployeeType = value;
            }
        }
       
        public string PCardNo
        {
            get
            {
                return _PCardNo;
            }
            set
            {
                _PCardNo = value;
            }
        }

        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return _MiddleName;
            }
            set
            {
                _MiddleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
            }
        }

        public string FatherName
        {
            get
            {
                return _FatherName;
            }
            set
            {
                _FatherName = value;
            }
        }

        public string Designation
        {
            get
            {
                return _Designation;
            }
            set
            {
                _Designation = value;
            }
        }

        public string Unit
        {
            get
            {
                return _Unit;
            }
            set
            {
                _Unit = value;
            }
        }

        public string SubUnit
        {
            get
            {
                return _SubUnit;
            }
            set
            {
                _SubUnit = value;
            }
        }

        public string Department
        {
            get
            {
                return _Department;
            }
            set
            {
                _Department = value;
            }
        }

        public string PFNo
        {
            get
            {
                return _PFNo;
            }
            set
            {
                _PFNo = value;
            }
        }

        public string ESINo
        {
            get
            {
                return _ESINo;
            }
            set
            {
                _ESINo = value;
            }
        }

        public string AliasName
        {
            get
            {
                return _AliasName;
            }
            set
            {
                _AliasName = value;
            }
        }

        public string NickName
        {
            get
            {
                return _NickName;
            }
            set
            {
                _NickName = value;
            }
        }

        public string LocalAddress
        {
            get
            {
                return _LocalAddress;
            }
            set
            {
                _LocalAddress = value;
            }
        }

        public string City
        {
            get
            {
                return _City;
            }
            set
            {
                _City = value;
            }
        }

        public string ZipCode
        {
            get
            {
                return _ZipCode;
            }
            set
            {
                _ZipCode = value;
            }
        }

        public string Country
        {
            get
            {
                return _Country;
            }
            set
            {
                _Country = value;
            }
        }

        public string State
        {
            get
            {
                return _State;
            }
            set
            {
                _State = value;
            }
        }

        public string ContactNo
        {
            get
            {
                return _ContactNo;
            }
            set
            {
                _ContactNo = value;
            }
        }

        public string EmailId
        {
            get
            {
                return _EmailId;
            }
            set
            {
                _EmailId = value;
            }
        }

        public string ParamAddress
        {
            get
            {
                return _ParamAddress;
            }
            set
            {
                _ParamAddress = value;
            }
        }

        public string ParamCity
        {
            get
            {
                return _ParamCity;
            }
            set
            {
                _ParamCity = value;
            }
        }

        public string ParamZipCode
        {
            get
            {
                return _ParamZipCode;
            }
            set
            {
                _ParamZipCode = value;
            }
        }

        public string ParamCountry
        {
            get
            {
                return _ParamCountry;
            }
            set
            {
                _ParamCountry = value;
            }
        }

        public string ParamState
        {
            get
            {
                return _ParamState;
            }
            set
            {
                _ParamState = value;
            }
        }

        public string PlaceOfBirth
        {
            get
            {
                return _PlaceOfBirth;
            }
            set
            {
                _PlaceOfBirth = value;
            }
        }

        public string RationCardNo
        {
            get
            {
                return _RationCardNo;
            }
            set
            {
                _RationCardNo = value;
            }
        }

        public string VoterId
        {
            get
            {
                return _VoterId;
            }
            set
            {
                _VoterId = value;
            }
        }

        public string PassportNo
        {
            get
            {
                return _PassportNo;
            }
            set
            {
                _PassportNo = value;
            }
        }

        public string PANNo
        {
            get
            {
                return _PANNo;
            }
            set
            {
                _PANNo = value;
            }
        }

        public string BankName
        {
            get
            {
                return _BankName;
            }
            set
            {
                _BankName = value;
            }
        }

        public string AccountNo
        {
            get
            {
                return _AccountNo;
            }
            set
            {
                _AccountNo = value;
            }
        }

        public string AccountHolderName
        {
            get
            {
                return _AccountHolderName;
            }
            set
            {
                _AccountHolderName = value;
            }
        }

        public string Branch
        {
            get
            {
                return _Branch;
            }
            set
            {
                _Branch = value;
            }
        }

        public string DLNo
        {
            get
            {
                return _DLNo;
            }
            set
            {
                _DLNo = value;
            }
        }

        public string ValidUpTo
        {
            get
            {
                return _ValidUpTo;
            }
            set
            {
                _ValidUpTo = value;
            }
        }

        public string IdentityMarks
        {
            get
            {
                return _IdentityMarks;
            }
            set
            {
                _IdentityMarks = value;
            }
        }

        public string Religion
        {
            get
            {
                return _Religion;
            }
            set
            {
                _Religion = value;
            }
        }

        public string Nationality
        {
            get
            {
                return _Nationality;
            }
            set
            {
                _Nationality = value;
            }
        }

        public string DateOfBirth
        {
            get
            {
                return _DateOfBirth;
            }
            set
            {
                _DateOfBirth = value;
            }
        }

        public string RetirementDate
        {
            get
            {
                return _RetirementDate;
            }
            set
            {
                _RetirementDate = value;
            }
        }

        public string Gender
        {
            get
            {
                return _Gender;
            }
            set
            {
                _Gender = value;
            }
        }

        public double Height
        {
            get
            {
                return _Height;
            }
            set
            {
                _Height = value;
            }
        }

        public string BloodGroup
        {
            get
            {
                return _BloodGroup;
            }
            set
            {
                _BloodGroup = value;
            }
        }

        public string MaritalStatus
        {
            get
            {
                return _MaritalStatus;
            }
            set
            {
                _MaritalStatus = value;
            }
        }

        public string Date
        {
            get
            {
                return _Date;
            }
            set
            {
                _Date = value;
            }
        }

        public string LoginId
        {
            get
            {
                return _LoginId;
            }
            set
            {
                _LoginId = value;
            }
        }

        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }

        public string EmployeePic
        {
            get
            {
                return _EmployeePic;
            }
            set
            {
                _EmployeePic = value;
            }
        }

        public string CityType
        {
            get
            {
                return _CityType;
            }
            set
            {
                _CityType = value;
            }
        }

        public string CreatedBy
        {
            get
            {
                return _CreatedBy;
            }
            set
            {
                _CreatedBy = value;
            }
        }

        public string ModifiedBy
        {
            get
            {
                return _ModifiedBy;
            }
            set
            {
                _ModifiedBy = value;
            }
        }

        public DateTime CreatedDate
        {
            get
            {
                return _CreatedDate;
            }
            set
            {
                _CreatedDate = value;
            }

        }

        public DateTime ModifiedDate
        {
            get
            {
                return _ModifiedDate;
            }
            set
            {
                _ModifiedDate = value;
            }
        }
        
        public int IsDeleted
        {
            get
            {
                return _IsDeleted;
            }
            set
            {
                _IsDeleted = value;
            }
        }
        
        public void SetObjectInfo(DataRow dr)
        {
            this.EmployeeId = Convert.ToString(dr["EmployeeId"]).Trim();
            this.EmployeeType = Convert.ToString(dr["EmployeeTypeId"]).Trim();
            this.FirstName = Convert.ToString(dr["FirstName"]).Trim();
            this.MiddleName = Convert.ToString(dr["MiddleName"]).Trim();
            this.LastName = Convert.ToString(dr["LastName"]).Trim();
            this.FatherName = Convert.ToString(dr["FatherName"]).Trim();
            this.Designation = Convert.ToString(dr["Designation"]).Trim();
            this.Unit = Convert.ToString(dr["Unit"]).Trim();
            this.SubUnit = Convert.ToString(dr["SubUnit"]);
            this.Department = Convert.ToString(dr["Department"]).Trim();
            this.PFNo = Convert.ToString(dr["PFNo"]).Trim();
            this.ESINo = Convert.ToString(dr["ESINo"]).Trim();
            this.AliasName = Convert.ToString(dr["AliasName"]).Trim();
            this.NickName = Convert.ToString(dr["NickName"]).Trim();
            this.LocalAddress = Convert.ToString(dr["LocalAddress"]).Trim();
            this.City = Convert.ToString(dr["City"]).Trim();
            this.ZipCode = Convert.ToString(dr["ZipCode"]);
            this.Country = Convert.ToString(dr["Country"]).Trim();
            this.State = Convert.ToString(dr["State"]).Trim();
            this.ContactNo = Convert.ToString(dr["ContactNo"]).Trim();
            this.EmailId = Convert.ToString(dr["EmailId"]).Trim();
            this.ParamAddress = Convert.ToString(dr["ParamAddress"]).Trim();
            this.ParamCity = Convert.ToString(dr["ParamCity"]).Trim();
            this.ParamZipCode = Convert.ToString(dr["ParamZipCode"]).Trim();
            this.ParamCountry = Convert.ToString(dr["ParamCountry"]);
            this.ParamState = Convert.ToString(dr["ParamState"]).Trim();
            this.PlaceOfBirth = Convert.ToString(dr["PlaceOfBirth"]).Trim();
            this.RationCardNo = Convert.ToString(dr["RationCardNo"]).Trim();
            this.VoterId = Convert.ToString(dr["VoterId"]).Trim();
            this.PassportNo = Convert.ToString(dr["PassportNo"]).Trim();
            this.PANNo = Convert.ToString(dr["PANCardNo"]).Trim();
            this.BankName = Convert.ToString(dr["BankDetail"]).Trim();
            this.AccountNo = Convert.ToString(dr["BankAccountNo"]).Trim();
            this.AccountHolderName = Convert.ToString(dr["AccountHolderName"]).Trim();
            this.Branch = Convert.ToString(dr["Branch"]).Trim();
            this.DLNo = Convert.ToString(dr["DLNo"]).Trim();
            this.ValidUpTo = Convert.ToString(dr["ValidUpTo"]).Trim();
            this.IdentityMarks = Convert.ToString(dr["IdentityMarks"]);
            this.Religion = Convert.ToString(dr["Religion"]).Trim();
            this.Nationality = Convert.ToString(dr["Nationality"]).Trim();
            this.DateOfBirth = Convert.ToString(dr["DateOfBirth"]).Trim();
            this.RetirementDate = Convert.ToString(dr["RetirementDate"]).Trim();
            this.Gender = Convert.ToString(dr["Gender"]).Trim();
            this.Height = Convert.ToDouble(dr["Height"]);
            this.BloodGroup = Convert.ToString(dr["BloodGroup"]).Trim();
            this.MaritalStatus = Convert.ToString(dr["MaritalStatus"]);
            this.Date = Convert.ToString(dr["Date"]).Trim();
            this.LoginId = Convert.ToString(dr["LoginId"]).Trim();
            this.Password = Convert.ToString(dr["Password"]).Trim();
            this.EmployeePic = Convert.ToString(dr["EmployeePic"]).Trim();
            this.CityType = Convert.ToString(dr["CityType"]).Trim();
            
            this.CreatedBy = Convert.ToString(dr["CreatedBy"]).Trim();
            this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]).Trim();
            this.ModifiedDate = Convert.ToDateTime(dr["CreatedDate"]);
            this.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);
            this.IsDeleted = Convert.ToInt32(dr["IsDeleted"]);
        }

    }

}
