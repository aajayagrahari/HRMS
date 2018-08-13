using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HRMS_Class
{
    [Serializable]
    public class EmployeePromotionDetails
    {
        private int _EmployeePromotionNo;
        private string _EmployeeId;
        private string _CurrentDept;
        private string _CurrentDesig;
        private string _NewDept;
        private string _NewDesig;
        private string _PromotionDate;
        private string _JoiningDate;
        
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

        public string CurrentDept
        {
            get
            {
                return _CurrentDept;
            }
            set
            {
                _CurrentDept = value;
            }
        }

        public string CurrentDesig
        {
            get
            {
                return _CurrentDesig;
            }
            set
            {
                _CurrentDesig = value;
            }
        }

        public string NewDept
        {
            get
            {
                return _NewDept;
            }
            set
            {
                _NewDept = value;
            }
        }

        public string NewDesig
        {
            get
            {
                return _NewDesig;
            }
            set
            {
                _NewDesig = value;
            }
        }

        public string PromotionDate
        {
            get
            {
                return _PromotionDate;
            }
            set
            {
                _PromotionDate = value;
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
            this.EmployeePromotionNo = Convert.ToInt32(dr["EmployeePromotionNo"]);
            this.EmployeeId = Convert.ToString(dr["EmployeeId"]).Trim();
            this.CurrentDept = Convert.ToString(dr["CurrentDept"]).Trim();
            this.CurrentDesig = Convert.ToString(dr["CurrentDesig"]).Trim();
            this.NewDept = Convert.ToString(dr["NewDept"]).Trim();
            this.NewDesig = Convert.ToString(dr["NewDesig"]).Trim();
            this.PromotionDate = Convert.ToString(dr["PromotionDate"]).Trim();
            this.JoiningDate = Convert.ToString(dr["JoiningDate"]).Trim();
            
            this.CreatedBy = Convert.ToString(dr["CreatedBy"]).Trim();
            this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]).Trim();
            this.ModifiedDate = Convert.ToDateTime(dr["CreatedDate"]);
            this.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);
            this.IsDeleted = Convert.ToInt32(dr["IsDeleted"]);
        }

    }

}
