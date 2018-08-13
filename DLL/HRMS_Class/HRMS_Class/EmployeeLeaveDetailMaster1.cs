using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
#region Developnet Detatil
//Developer Name: Shruti Dwivedi
//Date:           20-09-2013
#endregion Developnet Detatil
namespace HRMS_Class
{
    public class EmployeeLeaveDetailMaster1
    {
        private Int32 _LeaveId;
        private Int64 _EmployeeId;
        private string _FromDate;
        private string _FromPeriod;
        private string _ToDate;
        private string _ToPeriod;
        private string _Reason;
        private string _IsSubmitted;
        private string _IsApproved;
        private string _ApprovedBy;
        private string _ApprovedDate;
        private string _IsDeleted;
        private DateTime _CreatedDate;
        private string _CreatedBy;
        private DateTime _ModifiedDate;
        private string _ModifiedBy;
        private string _SubmittedDate;
        private string _LeaveTypeId;
        private string _Remark;





        public Int32 LeaveId
        {
            get
            {
                return _LeaveId;
            }
            set
            {
                _LeaveId = value;
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
        public string FromPeriod
        {
            get
            {
                return _FromPeriod;
            }
            set
            {
                _FromPeriod = value;
            }
        }
        public string ToPeriod
        {
            get
            {
                return _ToPeriod;
            }
            set
            {
                _ToPeriod = value;
            }
        }
        public string Reason
        {
            get
            {
                return _Reason;
            }
            set
            {
                _Reason = value;
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
        public string IsSubmitted
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
        public string IsApproved
        {
            get
            {
                return _IsApproved;
            }
            set
            {
                _IsApproved = value;
            }
        }
        public string IsDeleted
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

        public string Remark
        {
            get
            {
                return _Remark;
            }
            set
            {
                _Remark = value;
            }
        }



        public string LeaveTypeId
        {
            get
            {
                return _LeaveTypeId;
            }
            set
            {
                _LeaveTypeId = value;
            }
        }
        public void SetObjectInfo(DataRow dr)
        {

            this.LeaveId = Convert.ToInt32(dr["LeaveId"]);
            this.EmployeeId = Convert.ToInt64(dr["EmployeeId"]);
            this.FromDate = Convert.ToString(dr["FromDate"]);
            this.FromPeriod = Convert.ToString(dr["FromPeriod"]);
            this.ToDate = Convert.ToString(dr["ToDate"]);
            this.ToPeriod = Convert.ToString(dr["ToPeriod"]);
            this.Reason = Convert.ToString(dr["Reason"]);
            this.IsSubmitted = Convert.ToString((dr["IsSubmitted"] == DBNull.Value ? 0 : dr["IsSubmitted"]));
            this.LeaveTypeId = Convert.ToString(dr["LeaveTypeId"]);
            this.Remark = Convert.ToString(dr["Remark"]);
            this.SubmittedDate = Convert.ToString(dr["SubmittedDate"]);
            this.IsApproved = Convert.ToString((dr["IsApproved"] == DBNull.Value ? "" : dr["IsApproved"]));
            this.ApprovedBy = Convert.ToString((dr["ApprovedBy"]==DBNull.Value?"":dr["ApprovedBy"]));
            this.ApprovedDate = Convert.ToString(dr["ApprovedDate"]);
            this.IsDeleted = Convert.ToString((dr["IsDeleted"] == DBNull.Value ? 0 : dr["IsDeleted"]));
        }

    }
}
