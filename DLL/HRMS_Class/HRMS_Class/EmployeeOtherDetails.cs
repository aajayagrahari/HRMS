using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HRMS_Class
{
    [Serializable]
    public class EmployeeOtherDetails
    {
        private int _EmployeeOtherId;
        private string _EmployeeId;
        private string _SalaryType;
        
        private string _Skilled;
        private string _Category;
        private string _OTRateType;
        private double _OTRate;
        private string _LateRateType;
        private double _LatePenaltyRate;
        private string _IncrementDueDate;
        private string _IncrementMonth;
        private int _BasicPayIncrementAs;
        private string _IdentityCardValidity;
        private int _SalaryCalculationDays;
        private int _GeneralWorkingHours;
        private int _OTCalculationDays;
        private int _OTWorkingHours;
        private int _TotalDaysInMonth;
        private string _CreatedBy;
        private string _ModifiedBy;
        private DateTime _CreatedDate;
        private DateTime _ModifiedDate;
        private int _IsDeleted;

        public int EmployeeOtherId
        {
            get
            {
                return _EmployeeOtherId;
            }
            set
            {
                _EmployeeOtherId = value;
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

        public string SalaryType
        {
            get
            {
                return _SalaryType;
            }
            set
            {
                _SalaryType = value;
            }
        }

        

        public string Skilled
        {
            get
            {
                return _Skilled;
            }
            set
            {
                _Skilled = value;
            }
        }

        public string Category
        {
            get
            {
                return _Category;
            }
            set
            {
                _Category = value;
            }
        }

        public string OTRateType
        {
            get
            {
                return _OTRateType;
            }
            set
            {
                _OTRateType = value;
            }
        }

        public double OTRate
        {
            get
            {
                return _OTRate;
            }
            set
            {
                _OTRate = value;
            }
        }

        public string LateRateType
        {
            get
            {
                return _LateRateType;
            }
            set
            {
                _LateRateType = value;
            }
        }

        public double LatePenaltyRate
        {
            get
            {
                return _LatePenaltyRate;
            }
            set
            {
                _LatePenaltyRate = value;
            }
        }

        public string IncrementDueDate
        {
            get
            {
                return _IncrementDueDate;
            }
            set
            {
                _IncrementDueDate = value;
            }
        }

        public string IncrementMonth
        {
            get
            {
                return _IncrementMonth;
            }
            set
            {
                _IncrementMonth = value;
            }
        }

        public int BasicPayIncrementAs
        {
            get
            {
                return _BasicPayIncrementAs;
            }
            set
            {
                _BasicPayIncrementAs = value;
            }
        }

        public string IdentityCardValidity
        {
            get
            {
                return _IdentityCardValidity;
            }
            set
            {
                _IdentityCardValidity = value;
            }
        }

        public int SalaryCalculationDays
        {
            get
            {
                return _SalaryCalculationDays;
            }
            set
            {
                _SalaryCalculationDays = value;
            }
        }

        public int GeneralWorkingHours
        {
            get
            {
                return _GeneralWorkingHours;
            }
            set
            {
                _GeneralWorkingHours = value;
            }
        }

        public int OTCalculationDays
        {
            get
            {
                return _OTCalculationDays;
            }
            set
            {
                _OTCalculationDays = value;
            }
        }

        public int OTWorkingHours
        {
            get
            {
                return _OTWorkingHours;
            }
            set
            {
                _OTWorkingHours = value;
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
            this.EmployeeOtherId = Convert.ToInt32(dr["EmployeeOtherId"]);
            this.EmployeeId = Convert.ToString(dr["EmployeeId"]).Trim();
            this.SalaryType = Convert.ToString(dr["SalaryType"]).Trim();
            
            this.Skilled = Convert.ToString(dr["Skilled"]).Trim();
            this.Category = Convert.ToString(dr["Category"]).Trim();
            this.OTRateType = Convert.ToString(dr["OTRateType"]).Trim();
            this.OTRate = Convert.ToDouble(dr["OTRate"]);
            this.LateRateType = Convert.ToString(dr["LateRateType"]).Trim();
            this.LatePenaltyRate = Convert.ToDouble(dr["LatePenaltyRate"]);
            this.IncrementDueDate = Convert.ToString(dr["IncrementDueDate"]);
            this.IncrementMonth = Convert.ToString(dr["IncrementMonth"]).Trim();
            this.BasicPayIncrementAs = Convert.ToInt32(dr["BasicPayIncrementAs"]);
            this.IdentityCardValidity = Convert.ToString(dr["IdentityCardValidity"]);
            this.SalaryCalculationDays = Convert.ToInt32(dr["SalaryCalculationDays"]);
            this.GeneralWorkingHours = Convert.ToInt32(dr["GeneralWorkingHours"]);
            this.OTCalculationDays = Convert.ToInt32(dr["OTCalculationDays"]);
            this.OTWorkingHours = Convert.ToInt32(dr["OTWorkingHours"]);
            this.TotalDaysInMonth = Convert.ToInt32(dr["TotalDaysInMonth"]);

            this.CreatedBy = Convert.ToString(dr["CreatedBy"]).Trim();
            this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]).Trim();
            this.ModifiedDate = Convert.ToDateTime(dr["CreatedDate"]);
            this.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);
            this.IsDeleted = Convert.ToInt32(dr["IsDeleted"]);
        }

    }

}
