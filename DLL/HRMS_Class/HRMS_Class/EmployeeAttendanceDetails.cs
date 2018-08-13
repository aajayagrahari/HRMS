using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HRMS_Class
{
    [Serializable]
    public class EmployeeAttendanceDetails
    {
        private int _EMPAttendanceId;
        private string _EmployeeId;
        private int _ItemNo;
        private string _AttendanceMonth;
        private string _AttendanceYear;
        private int _TotalDaysInMonth;
        private int _WeekOff;
        private int _Holidays;
        private int _PresentDays;
        private int _AbsentDays;
        private int _WorkingDays;
        private int _PaidDays;
        private string _SalaryProcessDate;
        private string _Status;
        private string _Remarks;
        private string _CreatedBy;
        private string _ModifiedBy;
        private DateTime _CreatedDate;
        private DateTime _ModifiedDate;
        private int _IsDeleted;

        public int EMPAttendanceId
        {
            get
            {
                return _EMPAttendanceId;
            }
            set
            {
                _EMPAttendanceId = value;
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

        public int ItemNo
        {
            get
            {
                return _ItemNo;
            }
            set
            {
                _ItemNo = value;
            }
        }

        public string AttendanceMonth
        {
            get
            {
                return _AttendanceMonth;
            }
            set
            {
                _AttendanceMonth = value;
            }
        }

        public string AttendanceYear
        {
            get
            {
                return _AttendanceYear;
            }
            set
            {
                _AttendanceYear = value;
            }
        }

        public int TotalDaysInMonth
        {
            get
            {
                return _TotalDaysInMonth;
            }
            set
            {
                _TotalDaysInMonth = value;
            }
        }

        public int WeekOff
        {
            get
            {
                return _WeekOff;
            }
            set
            {
                _WeekOff = value;
            }
        }

        public int Holidays
        {
            get
            {
                return _Holidays;
            }
            set
            {
                _Holidays = value;
            }
        }

        public int PresentDays
        {
            get
            {
                return _PresentDays;
            }
            set
            {
                _PresentDays = value;
            }
        }

        public int AbsentDays
        {
            get
            {
                return _AbsentDays;
            }
            set
            {
                _AbsentDays = value;
            }
        }

        public int WorkingDays
        {
            get
            {
                return _WorkingDays;
            }
            set
            {
                _WorkingDays = value;
            }
        }

        public int PaidDays
        {
            get
            {
                return _PaidDays;
            }
            set
            {
                _PaidDays = value;
            }
        }

        public string SalaryProcessDate
        {
            get
            {
                return _SalaryProcessDate;
            }
            set
            {
                _SalaryProcessDate = value;
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
            this.EMPAttendanceId = Convert.ToInt32(dr["EmployeeLeaveId"]);
            this.EmployeeId = Convert.ToString(dr["EmployeeId"]).Trim();
            this.ItemNo = Convert.ToInt32(dr["ItemNo"]);
            this.AttendanceMonth = Convert.ToString(dr["AttendanceMonth"]).Trim();
            this.AttendanceYear = Convert.ToString(dr["AttendanceYear"]).Trim();
            this.TotalDaysInMonth = Convert.ToInt32(dr["TotalDaysInMonth"]);
            this.WeekOff = Convert.ToInt32(dr["WeekOff"]);
            this.Holidays = Convert.ToInt32(dr["Holidays"]);
            this.PresentDays = Convert.ToInt32(dr["PresentDays"]);
            this.AbsentDays = Convert.ToInt32(dr["AbsentDays"]);
            this.WorkingDays = Convert.ToInt32(dr["WorkingDays"]);
            this.PaidDays = Convert.ToInt32(dr["PaidDays"]);
            this.SalaryProcessDate = Convert.ToString(dr["SalaryProcessDate"]).Trim();
            this.Status = Convert.ToString(dr["Status"]).Trim();
            this.Remarks = Convert.ToString(dr["Remarks"]).Trim();

            this.CreatedBy = Convert.ToString(dr["CreatedBy"]).Trim();
            this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]).Trim();
            this.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
            this.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);
            this.IsDeleted = Convert.ToInt32(dr["IsDeleted"]);
        }

    }

}
