using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace HRMS_Class
{
public class RequitmentMaster
    {
        private string _StateCode;
        private string _CountryCode;
        private int _RId;
        private string _FName;
        private string _LName;
        private string _Gender;
        private string _DOB;
        private string _EmailId;
        private string _MobileNo;
        private string _Qualification;
        private string _Exprience;
        private string _Designation;
        private string _City;
        private string _PinCode;
        private string _CAddress;
        private string _PAddress;
        private string _Resume;
        private string _CreatedBy;
        private string _ModifiedBy;

        public int RId
        {
            get
            {
                return _RId;
            }
            set
            {
                _RId = value;
            }
        }
        public string FName
        {
            get
            {
                return _FName;
            }
            set
            {
                _FName = value;
            }
        }
        public string LName
        {
            get
            {
                return _LName;
            }
            set
            {
                _LName = value;
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
        public string DOB
        {
            get
            {
                return _DOB;
            }
            set
            {
                _DOB = value;
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
        public string MobileNo
        {
            get
            {
                return _MobileNo;
            }
            set
            {
                _MobileNo = value;
            }
        }
        public string Qualification
        {
            get
            {
                return _Qualification;
            }
            set
            {
                _Qualification = value;
            }
        }
        public string Exprience
        {
            get
            {
                return _Exprience;
            }
            set
            {
                _Exprience = value;
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
        public string PinCode
        {
            get
            {
                return _PinCode;
            }
            set
            {
                _PinCode = value;
            }
        }
        public string CAddress
        {
            get
            {
                return _CAddress;
            }
            set
            {
                _CAddress = value;
            }
        }
        public string PAddress
        {
            get
            {
                return _PAddress;
            }
            set
            {
                _PAddress = value;
            }
        }
        public string Resume
        {
            get
            {
                return _Resume;
            }
            set
            {
                _Resume = value;
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
        public string CountryCode
        {
            get
            {
                return _CountryCode;
            }
            set
            {
                _CountryCode = value;
            }
        }

        public string StateCode
        {
            get
            {
                return _StateCode;
            }
            set
            {
                _StateCode = value;
            }
        }
     

        public void SetObjectInfo(DataRow dr)
        {
            this.CountryCode = Convert.ToString(dr["CountryCode"]);
            this.StateCode = Convert.ToString(dr["StateCode"]);
            this.RId = Convert.ToInt32(dr["RId"]);
            this.FName = Convert.ToString(dr["FName"]);
            this.LName = Convert.ToString(dr["LName"]);
            this.Gender = Convert.ToString(dr["Gender"]);
            this.DOB = Convert.ToString(dr["DOB"]);
            this.EmailId = Convert.ToString(dr["EmailId"]);
            this.MobileNo = Convert.ToString(dr["MobileNo"]);
            this.Qualification = Convert.ToString(dr["Qualification"]);
            this.Exprience = Convert.ToString(dr["Exprience"]);
            this.Designation = Convert.ToString(dr["Designation"]);
            this.City = Convert.ToString(dr["City"]);
            this.PinCode = Convert.ToString(dr["PinCode"]);
            this.CAddress = Convert.ToString(dr["CAddress"]);
            this.PAddress = Convert.ToString(dr["PAddress"]);
            this.Resume = Convert.ToString(dr["Resume"]);
            this.CreatedBy = Convert.ToString(dr["CreatedBy"]);
            this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]);
         
          
        }
    }
}
