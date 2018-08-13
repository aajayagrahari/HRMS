using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRMS_Class
{
    public class Reimbursement
    {
        private Int32 _ReimbursementId;
        private string _EmployeeId;
        private string _EmployeeName;
        private string _ManagerName;
        private string _Department;
        private string _FromDate;
        private string _ToDate;
        private string _BusinessPurpose;
        private bool _IsDeleted;
        private string _CreatedDate;
        private string _CreatedBy;
        private string _ModifiedDate;
        private string _ModifiedBy;

        public Int32 ReimbursementId
        {
            get
            {
                return _ReimbursementId;
            }
            set
            {
                _ReimbursementId = value;
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
        public string EmployeeName
        {
            get
            {
                return _EmployeeName;
            }
            set
            {
                _EmployeeName = value;
            }
        }
        public string ManagerName
        {
            get
            {
                return _ManagerName;
            }
            set
            {
                _ManagerName = value;
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
        public string FromDate
        {
            get
            {
                return _FromDate;
            }
            set
            {
                _FromDate = value;
            }
        }
        public string ToDate
        {
            get
            {
                return _ToDate;
            }
            set
            {
                _ToDate = value;
            }
        }
        public string BusinessPurpose
        {
            get
            {
                return _BusinessPurpose;
            }
            set
            {
                _BusinessPurpose = value;
            }
        }
        public bool IsDeleted
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
        public string CreatedDate
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
        public string ModifiedDate
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
        public void SetObjectInfo(DataRow dr)
        {
            this.ReimbursementId = Convert.ToInt32(dr["ReimbursementId"]);
            this.EmployeeId = Convert.ToString(dr["EmployeeId"]);
            this.EmployeeName = Convert.ToString(dr["EmployeeName"]);
            this.ManagerName = Convert.ToString(dr["ManagerName"]);
            this.Department = Convert.ToString(dr["Department"]);
            this.FromDate = Convert.ToString(dr["FromDate"]);
            this.ToDate = Convert.ToString(dr["ToDate"]);
            this.BusinessPurpose = Convert.ToString(dr["BusinessPurpose"]);
            this.IsDeleted = Convert.ToBoolean(dr["IsDeleted"]);
            this.CreatedDate = Convert.ToString(dr["CreatedDate"]);
            this.CreatedBy = Convert.ToString(dr["CreatedBy"]);
            this.ModifiedDate = Convert.ToString(dr["ModifiedDate"]);
            this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]);
          

        }
    }
}
