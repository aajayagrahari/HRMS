using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HRMS_Class
{
    public class MonthlyAttendanceRegister
    {

        private string _EmployeeId;
        private string _AttendanceDate;
        private string _MarkInTime;
        private string _UpdatedMarkInTime;
        private string _MarkOutTime;
        private string _UpdatedMarkOutTime;
        private string _Remarks;
        private int _Month;
        private int _Year;
        private string _Status;
        
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

        public string AttendanceDate
        {
            get
            {
                return _AttendanceDate;
            }
            set
            {
                _AttendanceDate = value;
            }
        }

        public string MarkInTime
        {
            get
            {
                return _MarkInTime;
            }
            set
            {
                _MarkInTime = value;
            }
        }

        public string UpdatedMarkInTime
        {
            get
            {
                return _UpdatedMarkInTime;
            }
            set
            {
                _UpdatedMarkInTime = value;
            }
        }

        public string MarkOutTime
        {
            get
            {
                return _MarkOutTime;
            }
            set
            {
                _MarkOutTime = value;
            }
        }

        public string UpdatedMarkOutTime
        {
            get
            {
                return _UpdatedMarkOutTime;
            }
            set
            {
                _UpdatedMarkOutTime = value;
            }

        }

        public string Remarks
        {
            get
            {
                return _Remarks;
            }
            set
            {
                _Remarks = value;
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

        public int Month
        {
            get
            {
                return _Month;
            }
            set
            {
                _Month = value;
            }

        }

        public int Year
        {
            get
            {
                return _Year;
            }
            set
            {
                _Year = value;
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
            this.AttendanceDate = Convert.ToString(dr["AttendanceDate"]).Trim();
            this.EmployeeId = Convert.ToString(dr["EmployeeId"]).Trim();
            this.MarkInTime = Convert.ToString(dr["MarkInTime"]).Trim();
            this.UpdatedMarkInTime = Convert.ToString(dr["UpdatedMarkInTime"]).Trim();
            this.MarkOutTime = Convert.ToString(dr["MarkOutTime"]).Trim();
            this.UpdatedMarkOutTime = Convert.ToString(dr["UpdatedMarkOutTime"]);
            this.Remarks = Convert.ToString(dr["Remarks"]);
            this.Status = Convert.ToString(dr["Status"]);
            this.Month = Convert.ToInt32(dr["Month"]);
            this.Year = Convert.ToInt32(dr["Year"]);

            this.IsDeleted = Convert.ToInt32(dr["IsDeleted"]);
            this.CreatedDate = Convert.ToDateTime(dr["IsDeleted"]);
            this.CreatedBy = Convert.ToString(dr["CreatedBy"]);
            this.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);
            this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]);
        }

    }
}
