using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HRMS_Class
{
    [Serializable]
    public class LeaveApplication
    {
        private string _EmployeeId;
        private string _SubjectLine;
        private string _Body;
        private string _EmpDocument;
        private string _Remarks;
        private string _Status;
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

        public string SubjectLine
        {
            get
            {
                return _SubjectLine;
            }
            set
            {
                _SubjectLine = value;
            }
        }

        public string Body
        {
            get
            {
                return _Body;
            }
            set
            {
                _Body = value;
            }
        }

        public string EmpDocument
        {
            get
            {
                return _EmpDocument;
            }
            set
            {
                _EmpDocument = value;
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
            this.SubjectLine = Convert.ToString(dr["SubjectLine"]);
            this.Body = Convert.ToString(dr["Body"]).Trim();
            this.EmpDocument = Convert.ToString(dr["EmpDocument"]).Trim();
            this.Remarks = Convert.ToString(dr["Remarks"]);
            this.Status = Convert.ToString(dr["Status"]);

            this.CreatedBy = Convert.ToString(dr["CreatedBy"]).Trim();
            this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]).Trim();
            this.ModifiedDate = Convert.ToDateTime(dr["CreatedDate"]);
            this.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);
            this.IsDeleted = Convert.ToInt32(dr["IsDeleted"]);
        }

    }

}
