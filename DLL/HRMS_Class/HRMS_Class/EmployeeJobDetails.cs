using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HRMS_Class
{
    [Serializable]
    public class EmployeeJobDetails
    {
        private int _EmployeeJobId;
        private string _EmployeeId;
        private string _ApplicationDate;
        private string _InterviewDate;
        private string _JoiningDate;
        private string _ConfirmationDate;
        private string _AppointmentLetterIssueDate;
        private string _SalartyStopAfter;
        private string _ContractStartDate;
        private string _ContractEndDate;
        private string _DateOfTransfer;
        private string _PFStartDate;
        private string _EPSStartDate;
        private string _ESISStartDate;
        private string _Category;
        private string _Grade;
        private string _Lavel;
        private string _Location;
        private string _Status;
        private string _AdharCardNo;
        private string _PSNo;
        private string _NSSNo;
        private string _ESIDispensary;
        private string _PlacementBy;
        private string _BossReportTo;
        private string _CreatedBy;
        private string _ModifiedBy;
        private DateTime _CreatedDate;
        private DateTime _ModifiedDate;
        private int _IsDeleted;

        public int EmployeeJobId
        {
            get
            {
                return _EmployeeJobId;
            }
            set
            {
                _EmployeeJobId = value;
            }
        }
        
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

        public string ApplicationDate
        {
            get
            {
                return _ApplicationDate;
            }
            set
            {
                _ApplicationDate = value;
            }
        }

        public string InterviewDate
        {
            get
            {
                return _InterviewDate;
            }
            set
            {
                _InterviewDate = value;
            }
        }

        public string JoiningDate
        {
            get
            {
                return _JoiningDate;
            }
            set
            {
                _JoiningDate = value;
            }
        }

        public string ConfirmationDate
        {
            get
            {
                return _ConfirmationDate;
            }
            set
            {
                _ConfirmationDate = value;
            }
        }

        public string AppointmentLetterIssueDate
        {
            get
            {
                return _AppointmentLetterIssueDate;
            }
            set
            {
                _AppointmentLetterIssueDate = value;
            }
        }

        public string SalartyStopAfter
        {
            get
            {
                return _SalartyStopAfter;
            }
            set
            {
                _SalartyStopAfter = value;
            }
        }

        public string ContractStartDate
        {
            get
            {
                return _ContractStartDate;
            }
            set
            {
                _ContractStartDate = value;
            }
        }

        public string ContractEndDate
        {
            get
            {
                return _ContractEndDate;
            }
            set
            {
                _ContractEndDate = value;
            }
        }

        public string DateOfTransfer
        {
            get
            {
                return _DateOfTransfer;
            }
            set
            {
                _DateOfTransfer = value;
            }
        }

        public string PFStartDate
        {
            get
            {
                return _PFStartDate;
            }
            set
            {
                _PFStartDate = value;
            }
        }

        public string EPSStartDate
        {
            get
            {
                return _EPSStartDate;
            }
            set
            {
                _EPSStartDate = value;
            }
        }

        public string ESISStartDate
        {
            get
            {
                return _ESISStartDate;
            }
            set
            {
                _ESISStartDate = value;
            }
        }

        public string Category
        {
            get
            {
                return _Category;
            }
            set
            {
                _Category = value;
            }
        }

        public string Grade
        {
            get
            {
                return _Grade;
            }
            set
            {
                _Grade = value;
            }
        }

        public string Lavel
        {
            get
            {
                return _Lavel;
            }
            set
            {
                _Lavel = value;
            }
        }

        public string Location
        {
            get
            {
                return _Location;
            }
            set
            {
                _Location = value;
            }
        }

        public string Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }

        public string AdharCardNo
        {
            get
            {
                return _AdharCardNo;
            }
            set
            {
                _AdharCardNo = value;
            }
        }

        public string PSNo
        {
            get
            {
                return _PSNo;
            }
            set
            {
                _PSNo = value;
            }
        }

        public string NSSNo
        {
            get
            {
                return _NSSNo;
            }
            set
            {
                _NSSNo = value;
            }
        }

        public string ESIDispensary
        {
            get
            {
                return _ESIDispensary;
            }
            set
            {
                _ESIDispensary = value;
            }
        }

        public string PlacementBy
        {
            get
            {
                return _PlacementBy;
            }
            set
            {
                _PlacementBy = value;
            }
        }

        public string BossReportTo
        {
            get
            {
                return _BossReportTo;
            }
            set
            {
                _BossReportTo = value;
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
            this.EmployeeJobId = Convert.ToInt32(dr["EmployeeJobId"]);
            this.EmployeeId = Convert.ToString(dr["EmployeeId"]).Trim();

            this.ApplicationDate = Convert.ToString(dr["ApplicationDate"]);
            this.InterviewDate = Convert.ToString(dr["InterviewDate"]);
            this.JoiningDate = Convert.ToString(dr["JoiningDate"]);
            this.ConfirmationDate = Convert.ToString(dr["ConfirmationDate"]);
            this.AppointmentLetterIssueDate = Convert.ToString(dr["AppointmentLetterIssueDate"]);
            this.SalartyStopAfter = Convert.ToString(dr["SalartyStopAfter"]);
            this.ContractStartDate = Convert.ToString(dr["ContractStartDate"]);
            this.ContractEndDate = Convert.ToString(dr["ContractEndDate"]);
            this.DateOfTransfer = Convert.ToString(dr["DateOfTransfer"]);
            this.PFStartDate = Convert.ToString(dr["PFStartDate"]);
            this.EPSStartDate = Convert.ToString(dr["EPSStartDate"]);
            this.ESISStartDate = Convert.ToString(dr["ESISStartDate"]);
            this.Category = Convert.ToString(dr["Category"]).Trim();
            this.Grade = Convert.ToString(dr["Grade"]).Trim();
            this.Lavel = Convert.ToString(dr["Lavel"]).Trim();
            this.Location = Convert.ToString(dr["Location"]).Trim();
            this.Status = Convert.ToString(dr["Status"]).Trim();
            this.AdharCardNo = Convert.ToString(dr["AdharCardNo"]).Trim();
            this.PSNo = Convert.ToString(dr["PSNo"]).Trim();
            this.ESIDispensary = Convert.ToString(dr["ESIDispensary"]).Trim();
            this.PlacementBy = Convert.ToString(dr["PlacementBy"]).Trim();
            this.BossReportTo = Convert.ToString(dr["BossReportTo"]).Trim();

            this.CreatedBy = Convert.ToString(dr["CreatedBy"]).Trim();
            this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]).Trim();
            this.ModifiedDate = Convert.ToDateTime(dr["CreatedDate"]);
            this.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);
            this.IsDeleted = Convert.ToInt32(dr["IsDeleted"]);
        }

    }

}
