using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HRMS_Class
{
    [Serializable]
    public class EmployeeEarningDetails
    {
        private int _EmployeeEarningId;
        private string _EmployeeId;
        private int _ItemNo;
        private string _Allowances;
        private double _Amount;
        private string _CalcOn;
        private string _PaymentMode;
        private int _Bonus;
        private int _OT;
        private string _CreatedBy;
        private string _ModifiedBy;
        private DateTime _CreatedDate;
        private DateTime _ModifiedDate;
        private int _IsDeleted;

        public int EmployeeEarningId
        {
            get
            {
                return _EmployeeEarningId;
            }
            set
            {
                _EmployeeEarningId = value;
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

        public string Allowances
        {
            get
            {
                return _Allowances;
            }
            set
            {
                _Allowances = value;
            }
        }

        public double Amount
        {
            get
            {
                return _Amount;
            }
            set
            {
                _Amount = value;
            }
        }

        public string CalcOn
        {
            get
            {
                return _CalcOn;
            }
            set
            {
                _CalcOn = value;
            }
        }

        public string PaymentMode
        {
            get
            {
                return _PaymentMode;
            }
            set
            {
                _PaymentMode = value;
            }
        }

        public int Bonus
        {
            get
            {
                return _Bonus;
            }
            set
            {
                _Bonus = value;
            }
        }

        public int OT
        {
            get
            {
                return _OT;
            }
            set
            {
                _OT = value;
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
            this.EmployeeEarningId = Convert.ToInt32(dr["EmployeeEarningId"]);
            this.EmployeeId = Convert.ToString(dr["EmployeeId"]).Trim();
            this.ItemNo = Convert.ToInt32(dr["ItemNo"]);
            this.Allowances = Convert.ToString(dr["Allowances"]).Trim();
            this.Amount = Convert.ToDouble(dr["Amount"]);
            this.CalcOn = Convert.ToString(dr["CalcOn"]).Trim();
            this.PaymentMode = Convert.ToString(dr["PaymentMode"]);
            this.Bonus = Convert.ToInt32(dr["Bonus"]);
            this.OT = Convert.ToInt32(dr["OT"]);

            this.CreatedBy = Convert.ToString(dr["CreatedBy"]).Trim();
            this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]).Trim();
            this.ModifiedDate = Convert.ToDateTime(dr["CreatedDate"]);
            this.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);
            this.IsDeleted = Convert.ToInt32(dr["IsDeleted"]);
        }

    }

}
