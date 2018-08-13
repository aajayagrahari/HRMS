using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HRMS_Class
{
   public class EmployeeAttendanceMaster
    {
        
        private Int64 _AttendanceId;
        private Int64 _EmployeeId;

        private string _MarkInDate;
        private string _MarkOutDate; 
       
        private string _MarkIntime;
        private string _MarkOutTime;
        private bool _IsDeleted;
        private string _CreatedDate;
        private string _CreatedBy;
        private string _ModifiedDate;
        private string _ModifiedBy;
        private string _MarkInRemark;
        private string _MarkoutRemark;
        private string _MarkInIPAddress;
        private string _MarkOutIPAddress;
        private string _AlertMessasg;
        private string _MarkOutAlertMessasg;

        private bool _IsSubmitted;
        private Int32 _IsApprived;

        private string _SubmittedBy;
        private string _ApprovedBy;
        private string _SubmittedDate;
        private string _ApprovedDate;
        private string _ApprovalRemark;

        private string _UpdatedMarkInTime;
        private string _UpdatedMarkOutTime;




        public Int64 AttendanceId
        {
            get
            {
                return _AttendanceId;
            }
            set
            {
                _AttendanceId = value;
            }
        }
        public Int64 EmployeeId
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
        public string AlertMessasg
        {
            get
            {
                return _AlertMessasg;
            }
            set
            {
                _AlertMessasg = value;
            }
        }
        public string MarkOutAlertMessasg
        {
            get
            {
                return _MarkOutAlertMessasg;
            }
            set
            {
                _MarkOutAlertMessasg = value;
            }
        }

        public string MarkInDate
        {
            get
            {
                return _MarkInDate;
            }
            set
            {
                _MarkInDate = value;
            }
        }
        public string MarkOutDate
        {
            get
            {
                return _MarkOutDate;
            }
            set
            {
                _MarkOutDate = value;
            }
        }
        public string MarkIntime
        {
            get
            {
                return _MarkIntime;
            }
            set
            {
                _MarkIntime = value;
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
        public bool IsSubmitted
        {
            get
            {
                return _IsSubmitted;
            }
            set
            {
                _IsSubmitted = value;
            }
        }
        public Int32 IsApprived
        {
            get
            {
                return _IsApprived;
            }
            set
            {
                _IsApprived = value;
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
        public string MarkInRemark
        {
            get
            {
                return _MarkInRemark;
            }
            set
            {
                _MarkInRemark = value;
            }

        }
        public string MarkoutRemark
        {
            get
            {
                return _MarkoutRemark;
            }
            set
            {
                _MarkoutRemark = value;
            }

        }
        public string MarkInIPAddress
        {
            get
            {
                return _MarkInIPAddress;
            }
            set
            {
                _MarkInIPAddress = value;
            }

        }
        public string MarkOutIPAddress
        {
            get
            {
                return _MarkOutIPAddress;
            }
            set
            {
                _MarkOutIPAddress = value;
            }

        }
        public string SubmittedBy
        {
            get
            {
                return _SubmittedBy;
            }
            set
            {
                _SubmittedBy = value;
            }

        }
        public string ApprovedBy
        {
            get
            {
                return _ApprovedBy;
            }
            set
            {
                _ApprovedBy = value;
            }

        }
        public string SubmittedDate
        {
            get
            {
                return _SubmittedDate;
            }
            set
            {
                _SubmittedDate = value;
            }

        }
        public string ApprovedDate
        {
            get
            {
                return _ApprovedDate;
            }
            set
            {
                _ApprovedDate = value;
            }

        }
        public string ApprovalRemark
        {
            get
            {
                return _ApprovalRemark;
            }
            set
            {
                _ApprovalRemark = value;
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

        public void SetObjectInfo(DataRow dr)
        {
            this.AttendanceId =Convert.ToInt32(dr["AttendanceId"]);
            this.EmployeeId =  Convert.ToInt32(dr["EmployeeId"]);
            this.MarkInDate = Convert.ToString(dr["MarkInDate"]);
            this.MarkOutDate = Convert.ToString(dr["MarkOutDate"]);
            this.MarkIntime = Convert.ToString(dr["MarkIntime"]);
            this.MarkOutTime = Convert.ToString(dr["MarkOutTime"]);
            this.IsDeleted = Convert.ToBoolean(dr["IsDeleted"]);
            this.CreatedDate = Convert.ToString(dr["IsDeleted"]);
            this.CreatedBy = Convert.ToString(dr["CreatedBy"]);
            this.ModifiedDate = Convert.ToString(dr["ModifiedDate"]);
            this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]);
            this.MarkInRemark = Convert.ToString(dr["MarkInRemark"]);
            this.MarkoutRemark = Convert.ToString(dr["MarkoutRemark"]);
            this.MarkInIPAddress = Convert.ToString(dr["MarkInIPAddress"]);
            this.MarkOutIPAddress = Convert.ToString(dr["MarkOutIPAddress"]);
            this.AlertMessasg = Convert.ToString(dr["AlertMessasg"]);
            this.IsSubmitted = Convert.ToBoolean(dr["IsSubmitted"]);
            this.IsApprived = Convert.ToInt32(dr["IsApprived"]);
            this.SubmittedBy = Convert.ToString(dr["SubmittedBy"]);

            this.SubmittedDate = Convert.ToString(dr["SubmittedDate"]);
            this.ApprovedBy = Convert.ToString(dr["ApprovedBy"]);
            this.ApprovedDate = Convert.ToString(dr["ApprovedDate"]);
            this.ApprovalRemark = Convert.ToString(dr["ApprovalRemark"]);
            this.UpdatedMarkInTime = Convert.ToString(dr["UpdatedMarkInTime"]);
            this.UpdatedMarkOutTime = Convert.ToString(dr["UpdatedMarkOutTime"]);
            
        }
        

    }
}
