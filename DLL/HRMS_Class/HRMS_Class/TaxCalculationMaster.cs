using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HRMS_Class
{
    [Serializable]
    public class TaxCalculationMaster
    {
        private string _EmployeeId;
        private int _TDSNo;
        private int _ItemNo;
        private string _TaxableAllowance;
        private double _TaxableAmount;
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

        public int TDSNo
        {
            get
            {
                return _TDSNo;
            }
            set
            {
                _TDSNo = value;
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

        public string TaxableAllowance
        {
            get
            {
                return _TaxableAllowance;
            }
            set
            {
                _TaxableAllowance = value;
            }
        }

        public double TaxableAmount
        {
            get
            {
                return _TaxableAmount;
            }
            set
            {
                _TaxableAmount = value;
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
            this.TDSNo = Convert.ToInt32(dr["TDSNo"]);
            this.ItemNo = Convert.ToInt32(dr["ItemNo"]);
            this.TaxableAllowance = Convert.ToString(dr["TaxableAllowance"]).Trim();
            this.TaxableAmount = Convert.ToDouble(dr["TaxableAmount"]);

            this.CreatedBy = Convert.ToString(dr["CreatedBy"]).Trim();
            this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]).Trim();
            this.ModifiedDate = Convert.ToDateTime(dr["CreatedDate"]);
            this.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);
            this.IsDeleted = Convert.ToInt32(dr["IsDeleted"]);
        }

    }

}
