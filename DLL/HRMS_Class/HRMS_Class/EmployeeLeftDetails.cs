using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HRMS_Class
{
    [Serializable]
    public class EmployeeLeftDetails
    {
        private int _EmployeeLeftId;
        private string _EmployeeId;
        private string _LeftDate;
        private int _FullnFinal;
        private string _LeftReason;
        private string _LeavingReason4PFDepartment;
        private string _LeavingReason4ESIDepartment;
        private string _CreatedBy;
        private string _ModifiedBy;
        private DateTime _CreatedDate;
        private DateTime _ModifiedDate;
        private int _IsDeleted;

        public int EmployeeLeftId
        {
            get
            {
                return _EmployeeLeftId;
            }
            set
            {
                _EmployeeLeftId = value;
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

        public string LeftDate
        {
            get
            {
                return _LeftDate;
            }
            set
            {
                _LeftDate = value;
            }
        }

        public int FullnFinal
        {
            get
            {
                return _FullnFinal;
            }
            set
            {
                _FullnFinal = value;
            }
        }

        public string LeftReason
        {
            get
            {
                return _LeftReason;
            }
            set
            {
                _LeftReason = value;
            }
        }

        public string LeavingReason4PFDepartment
        {
            get
            {
                return _LeavingReason4PFDepartment;
            }
            set
            {
                _LeavingReason4PFDepartment = value;
            }
        }

        public string LeavingReason4ESIDepartment
        {
            get
            {
                return _LeavingReason4ESIDepartment;
            }
            set
            {
                _LeavingReason4ESIDepartment = value;
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
            this.EmployeeLeftId = Convert.ToInt32(dr["EmployeeLeftId"]);
            this.EmployeeId = Convert.ToString(dr["EmployeeId"]).Trim();
            this.LeftDate = Convert.ToString(dr["LeftDate"]);
            this.FullnFinal = Convert.ToInt32(dr["FullnFinal"]);
            this.LeftReason = Convert.ToString(dr["LeftReason"]).Trim();
            this.LeavingReason4PFDepartment = Convert.ToString(dr["LeavingReason4PFDepartment"]).Trim();
            this.LeavingReason4ESIDepartment = Convert.ToString(dr["LeavingReason4ESIDepartment"]).Trim();

            this.CreatedBy = Convert.ToString(dr["CreatedBy"]).Trim();
            this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]).Trim();
            this.ModifiedDate = Convert.ToDateTime(dr["CreatedDate"]);
            this.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);
            this.IsDeleted = Convert.ToInt32(dr["IsDeleted"]);
        }

    }

}


