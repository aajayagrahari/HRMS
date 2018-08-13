using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HRMS_Class
{
   public class OutOfOfficeAttendanceMaster
    {

        private string _EmployeeId;
        private string _OutOfOfficeDateFrom;
        private string _OutOfOfficeDateTo;
        private string _Purpose;
        private string _Status;
        private string _Approvedby;
        private int _IsApprove;
        private int _month;
        private int _year;

        private int _IsDeleted;
        private DateTime _CreatedDate;
        private DateTime _ModifiedDate;
        private string _CreatedBy;
        private string _ModifiedBy;

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

        public string OutOfOfficeDateFrom
        {
            get
            {
                return _OutOfOfficeDateFrom;
            }
            set
            {
                _OutOfOfficeDateFrom = value;
            }
        }

        public string OutOfOfficeDateTo
        {
            get
            {
                return _OutOfOfficeDateTo;
            }
            set
            {
                _OutOfOfficeDateTo = value;
            }
        }

        public string Purpose
        {
            get
            {
                return _Purpose;
            }
            set
            {
                _Purpose = value;
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

        public string Approvedby
        {
            get
            {
                return _Approvedby;
            }
            set
            {
                _Approvedby = value;
            }

        }

        public int IsApprove
        {
            get
            {
                return _IsApprove;
            }
            set
            {
                _IsApprove = value;
            }

        }

        public int month
        {
            get
            {
                return _month;
            }
            set
            {
                _month = value;
            }

        }

        public int year
        {
            get
            {
                return _year;
            }
            set
            {
                _year = value;
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

        public void SetObjectInfo(DataRow dr)
        {
            this.OutOfOfficeDateFrom = Convert.ToString(dr["OutOfOfficeDateFrom"]);
            this.OutOfOfficeDateTo = Convert.ToString(dr["OutOfOfficeDateTo"]);
            this.EmployeeId = Convert.ToString(dr["EmployeeId"]).Trim();
            this.Purpose = Convert.ToString(dr["Purpose"]);
            this.Status = Convert.ToString(dr["Status"]);
            this.Approvedby = Convert.ToString(dr["ApprovedBy"]);
            this.IsApprove = Convert.ToInt32(dr["IsApprove"]);
            this.month = Convert.ToInt32(dr["month"]);
            this.year = Convert.ToInt32(dr["year"]);

            this.IsDeleted = Convert.ToInt32(dr["IsDeleted"]);
            this.CreatedDate = Convert.ToDateTime(dr["IsDeleted"]);
            this.CreatedBy = Convert.ToString(dr["CreatedBy"]);
            this.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);
            this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]);
        }
        

    }
}
