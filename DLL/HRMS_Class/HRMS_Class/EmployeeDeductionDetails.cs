﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HRMS_Class
{
    [Serializable]
    public class EmployeeDeductionDetails
    {
        private int _EmployeeDeductionId;
        private string _EmployeeId;
        private int _ItemNo;
        private string _Deductions;
        private double _DeductionPercetage;
        private double _DeductionAmount;
        private string _DeductionCalcOn;
        private string _DeductionPayMode;
        private int _DeductionLimit;
        private double _LimitAmount;
        
        private string _CreatedBy;
        private string _ModifiedBy;
        private DateTime _CreatedDate;
        private DateTime _ModifiedDate;
        private int _IsDeleted;

        public int EmployeeDeductionId
        {
            get
            {
                return _EmployeeDeductionId;
            }
            set
            {
                _EmployeeDeductionId = value;
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

        public string Deductions
        {
            get
            {
                return _Deductions;
            }
            set
            {
                _Deductions = value;
            }
        }

        public double DeductionPercetage
        {
            get
            {
                return _DeductionPercetage;
            }
            set
            {
                _DeductionPercetage = value;
            }
        }

        public double DeductionAmount
        {
            get
            {
                return _DeductionAmount;
            }
            set
            {
                _DeductionAmount = value;
            }
        }

        public string DeductionCalcOn
        {
            get
            {
                return _DeductionCalcOn;
            }
            set
            {
                _DeductionCalcOn = value;
            }
        }

        public string DeductionPayMode
        {
            get
            {
                return _DeductionPayMode;
            }
            set
            {
                _DeductionPayMode = value;
            }
        }

        public int DeductionLimit
        {
            get
            {
                return _DeductionLimit;
            }
            set
            {
                _DeductionLimit = value;
            }
        }

        public double LimitAmount
        {
            get
            {
                return _LimitAmount;
            }
            set
            {
                _LimitAmount = value;
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
            this.EmployeeDeductionId = Convert.ToInt32(dr["EmployeeDeductionId"]);
            this.EmployeeId = Convert.ToString(dr["EmployeeId"]).Trim();
            this.ItemNo = Convert.ToInt32(dr["ItemNo"]);
            this.Deductions = Convert.ToString(dr["Deductions"]).Trim();
            this.DeductionPercetage = Convert.ToDouble(dr["DeductionPercetage"]);
            this.DeductionAmount = Convert.ToDouble(dr["DeductionAmount"]);
            this.DeductionCalcOn = Convert.ToString(dr["DeductionCalcOn"]).Trim();
            this.DeductionPayMode = Convert.ToString(dr["DeductionPayMode"]);
            this.DeductionLimit = Convert.ToInt32(dr["DeductionLimit"]);
            this.LimitAmount = Convert.ToDouble(dr["LimitAmount"]);

            this.CreatedBy = Convert.ToString(dr["CreatedBy"]).Trim();
            this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]).Trim();
            this.ModifiedDate = Convert.ToDateTime(dr["CreatedDate"]);
            this.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);
            this.IsDeleted = Convert.ToInt32(dr["IsDeleted"]);
        }

    }

}
