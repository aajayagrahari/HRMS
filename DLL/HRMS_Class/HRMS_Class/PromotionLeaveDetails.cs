using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HRMS_Class
{
    [Serializable]
    public class PromotionLeaveDetails
    {
        private int _EmployeeLeaveId;
        private int _EmployeePromotionNo;
        private string _EmployeeId;
        private int _ItemNo;
        private string _LeaveType;
        private int _Opening;
        private int _NewOpening;
        private int _MonthlyEarnedType;
        private string _MonthlyEarned;
        private int _EarningLeaveAllowedAfter;
        private string _EarningLeaveIn;
        private int _ConsumedEL;
        private int _CasulLeaveAllowedAfter;
        private string _CasualLeaveAllowedIn;
        private int _EarnedCL;
        private string _CreatedBy;
        private string _ModifiedBy;
        private DateTime _CreatedDate;
        private DateTime _ModifiedDate;
        private int _IsDeleted;

        public int EmployeeLeaveId
        {
            get
            {
                return _EmployeeLeaveId;
            }
            set
            {
                _EmployeeLeaveId = value;
            }
        }

        public int EmployeePromotionNo
        {
            get
            {
                return _EmployeePromotionNo;
            }
            set
            {
                _EmployeePromotionNo = value;
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

        public string LeaveType
        {
            get
            {
                return _LeaveType;
            }
            set
            {
                _LeaveType = value;
            }
        }

        public int Opening
        {
            get
            {
                return _Opening;
            }
            set
            {
                _Opening = value;
            }
        }

        public int NewOpening
        {
            get
            {
                return _NewOpening;
            }
            set
            {
                _NewOpening = value;
            }
        }

        public int MonthlyEarnedType
        {
            get
            {
                return _MonthlyEarnedType;
            }
            set
            {
                _MonthlyEarnedType = value;
            }
        }

        public string MonthlyEarned
        {
            get
            {
                return _MonthlyEarned;
            }
            set
            {
                _MonthlyEarned = value;
            }
        }

        public int EarningLeaveAllowedAfter
        {
            get
            {
                return _EarningLeaveAllowedAfter;
            }
            set
            {
                _EarningLeaveAllowedAfter = value;
            }
        }

        public string EarningLeaveIn
        {
            get
            {
                return _EarningLeaveIn;
            }
            set
            {
                _EarningLeaveIn = value;
            }
        }

        public int ConsumedEL
        {
            get
            {
                return _ConsumedEL;
            }
            set
            {
                _ConsumedEL = value;
            }
        }

        public int CasulLeaveAllowedAfter
        {
            get
            {
                return _CasulLeaveAllowedAfter;
            }
            set
            {
                _CasulLeaveAllowedAfter = value;
            }
        }

        public string CasualLeaveAllowedIn
        {
            get
            {
                return _CasualLeaveAllowedIn;
            }
            set
            {
                _CasualLeaveAllowedIn = value;
            }
        }

        public int EarnedCL
        {
            get
            {
                return _EarnedCL;
            }
            set
            {
                _EarnedCL = value;
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
            this.EmployeeLeaveId = Convert.ToInt32(dr["EmployeeLeaveId"]);
            this.EmployeePromotionNo = Convert.ToInt32(dr["EmployeePromotionNo"]);
            this.EmployeeId = Convert.ToString(dr["EmployeeId"]).Trim();
            this.ItemNo = Convert.ToInt32(dr["ItemNo"]);
            this.LeaveType = Convert.ToString(dr["LeaveType"]).Trim();
            this.Opening = Convert.ToInt32(dr["Opening"]);
            this.NewOpening = Convert.ToInt32(dr["NewOpening"]);
            this.MonthlyEarnedType = Convert.ToInt32(dr["MonthlyEarnedType"]);
            this.MonthlyEarned = Convert.ToString(dr["MonthlyEarned"]).Trim();
            this.EarningLeaveAllowedAfter = Convert.ToInt32(dr["EarningLeaveAllowedAfter"]);
            this.EarningLeaveIn = Convert.ToString(dr["EarningLeaveIn"]).Trim();
            this.ConsumedEL = Convert.ToInt32(dr["ConsumedEL"]);
            this.CasulLeaveAllowedAfter = Convert.ToInt32(dr["CasulLeaveAllowedAfter"]);
            this.CasualLeaveAllowedIn = Convert.ToString(dr["CasualLeaveAllowedIn"]).Trim();
            this.EarnedCL = Convert.ToInt32(dr["EarnedCL"]);

            this.CreatedBy = Convert.ToString(dr["CreatedBy"]).Trim();
            this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]).Trim();
            this.ModifiedDate = Convert.ToDateTime(dr["CreatedDate"]);
            this.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);
            this.IsDeleted = Convert.ToInt32(dr["IsDeleted"]);
        }

    }

}
