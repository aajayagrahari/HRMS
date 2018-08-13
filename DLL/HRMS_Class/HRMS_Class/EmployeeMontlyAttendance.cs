using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HRMS_Class
{
    public class EmployeeMontlyAttendance
    {

        private int _AttendanceId;
        private string _EmployeeId;
        private int _ItemNo;
        private string _Month;
        private string _Year;
        private string _SalaryProcessDate;
        private int _TotalMontrhInDays;
        private int _OverTime;
        private int _Present;
        private int _Absent;
        private int _Holidays;
        private int _WeekOff;
        private int _RstHoliDays;
        private int _Maternity;
        private int _EL;
        private int _CL;
        private int _SL;
        private int _L1;
        private int _L2;
        private int _L3;
        private string _PaidDays;
       
        private int _DayWork;
        private int _ESILeave;

        private string _ArrPaidDays;
        private string _PFPaidDays;
        private string _ESIPaidDays;

        private string _Remarks;

        private string _Allwances;
        private double _AllowanesAmount;
        private string _Deductions;
        private double _DedPercentage;
        private double _DedAmount;

        private int _IsDeleted;
        private DateTime _CreatedDate;
        private DateTime _ModifiedDate;
        private string _CreatedBy;
        private string _ModifiedBy;

        private bool _IsSytemCalucalted;

        private string _NCEL;
        private string _CEL;
        private string _Paternity;
        private string _HalfDay;

       

        private string _OverTimeAmount ;
        private string _CalcOverTimeAmount ;
        private string _ActualEarnSalary;
        private string _SalaryCalculationDate;
        private string _HPL;
       // private string _ErrorMsg;



        public int AttendanceId
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

        public string Month
        {
            get
            {
                return _Month;
            }
            set
            {
                _Month = value;
            }
        }

        public string Year
        {
            get
            {
                return _Year;
            }
            set
            {
                _Year = value;
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

        public int TotalMontrhInDays
        {
            get
            {
                return _TotalMontrhInDays;
            }
            set
            {
                _TotalMontrhInDays = value;
            }
        }

        public int OverTime
        {
            get
            {
                return _OverTime;
            }
            set
            {
                _OverTime = value;
            }

        }

        public int Present
        {
            get
            {
                return _Present;
            }
            set
            {
                _Present = value;
            }

        }

        public int Absent
        {
            get
            {
                return _Absent;
            }
            set
            {
                _Absent = value;
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

        public int RstHoliDays
        {
            get
            {
                return _RstHoliDays;
            }
            set
            {
                _RstHoliDays = value;
            }

        }

        public int Maternity
        {
            get
            {
                return _Maternity;
            }
            set
            {
                _Maternity = value;
            }

        }

        public int EL
        {
            get
            {
                return _EL;
            }
            set
            {
                _EL = value;
            }

        }

        public int CL
        {
            get
            {
                return _CL;
            }
            set
            {
                _CL = value;
            }

        }

        public int SL
        {
            get
            {
                return _SL;
            }
            set
            {
                _SL = value;
            }

        }

        public int L1
        {
            get
            {
                return _L1;
            }
            set
            {
                _L1 = value;
            }

        }

        public int L2
        {
            get
            {
                return _L2;
            }
            set
            {
                _L2 = value;
            }

        }

        public int L3
        {
            get
            {
                return _L3;
            }
            set
            {
                _L3 = value;
            }

        }

        public string PaidDays
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
       

        public int DayWork
        {
            get
            {
                return _DayWork;
            }
            set
            {
                _DayWork = value;
            }

        }

        public int ESILeave
        {
            get
            {
                return _ESILeave;
            }
            set
            {
                _ESILeave = value;
            }

        }

        public string ArrPaidDays
        {
            get
            {
                return _ArrPaidDays;
            }
            set
            {
                _ArrPaidDays = value;
            }

        }

        public string PFPaidDays
        {
            get
            {
                return _PFPaidDays;
            }
            set
            {
                _PFPaidDays = value;
            }

        }

        public string ESIPaidDays
        {
            get
            {
                return _ESIPaidDays;
            }
            set
            {
                _ESIPaidDays = value;
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

        public string Allwances
        {
            get
            {
                return _Allwances;
            }
            set
            {
                _Allwances = value;
            }

        }

        public double AllowanesAmount
        {
            get
            {
                return _AllowanesAmount;
            }
            set
            {
                _AllowanesAmount = value;
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

        public double DedPercentage
        {
            get
            {
                return _DedPercentage;
            }
            set
            {
                _DedPercentage = value;
            }

        }

        public double DedAmount
        {
            get
            {
                return _DedAmount;
            }
            set
            {
                _DedAmount = value;
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

        public bool IsSytemCalucalted
        {
            get
            {
                return _IsSytemCalucalted;
            }
            set
            {
                _IsSytemCalucalted = value;
            }

        }
        public string NCEL
        {
            get
            {
                return _NCEL;
            }
            set
            {
                _NCEL = value;
            }

        }
        public string CEL
        {
            get
            {
                return _CEL;
            }
            set
            {
                _CEL = value;
            }

        }
        public string Paternity
        {
            get
            {
                return _Paternity;
            }
            set
            {
                _Paternity = value;
            }

        }
        public string HalfDay
        {
            get
            {
                return _HalfDay;
            }
            set
            {
                _HalfDay = value;
            }

        }

        public string OverTimeAmount
        {
            get
            {
                return _OverTimeAmount;
            }
            set
            {
                _OverTimeAmount = value;
            }

        }
        public string CalcOverTimeAmount
        {
            get
            {
                return _CalcOverTimeAmount;
            }
            set
            {
                _CalcOverTimeAmount = value;
            }

        }
        public string ActualEarnSalary
        {
            get
            {
                return _ActualEarnSalary;
            }
            set
            {
                _ActualEarnSalary = value;
            }

        }
        public string SalaryCalculationDate
        {
            get
            {
                return _SalaryCalculationDate;
            }
            set
            {
                _SalaryCalculationDate = value;
            }

        }
        public string HPL
        {
            get
            {
                return _HPL;
            }
            set
            {
                _HPL = value;
            }

        }
        public string ErrorMsg
        {
            get
            {
                return ErrorMsg;
            }
            set
            {
                ErrorMsg = value;
            }
        }
        public void SetObjectInfo(DataRow dr)
        {
            this.AttendanceId =Convert.ToInt32(dr["AttendanceId"]);
            this.EmployeeId = Convert.ToString(dr["EmployeeId"]);
            this.ItemNo = Convert.ToInt32(dr["ItemNo"]);
            this.Month = Convert.ToString(dr["Month"]);
            this.Year = Convert.ToString(dr["Year"]);
            this.SalaryProcessDate = Convert.ToString(dr["SalaryProcessDate"]);
            this.TotalMontrhInDays = Convert.ToInt32(dr["TotalMonthDays"]);
            this.OverTime = Convert.ToInt32(dr["OverTime"]);
            this.Present = Convert.ToInt32(dr["Present"]);
            this.Absent = Convert.ToInt32(dr["Absent"]);
            this.Holidays = Convert.ToInt32(dr["Holidays"]);
            this.WeekOff = Convert.ToInt32(dr["WeekOff"]);
            this.RstHoliDays = Convert.ToInt32(dr["RstHoliDays"]);
            this.Maternity = Convert.ToInt32(dr["Maternity"]);
            this.EL = Convert.ToInt32(dr["EL"]);
            this.CL = Convert.ToInt32(dr["CL"]);
            this.L1 = Convert.ToInt32(dr["L1"]);
            this.L2 = Convert.ToInt32(dr["L2"]);
            this.L3 = Convert.ToInt32(dr["L3"]);
            this.PaidDays = Convert.ToString(dr["PaidDays"]);
            this.DayWork = Convert.ToInt32(dr["DayWork"]);
            this.ESILeave = Convert.ToInt32(dr["ESILeave"]);
            this.ArrPaidDays = Convert.ToString(dr["ArrPaidDays"]);
            this.PFPaidDays = Convert.ToString(dr["PFPaidDays"]);
            this.ESIPaidDays = Convert.ToString(dr["ESIPaidDays"]);

            this.Allwances = Convert.ToString(dr["Allwances"]);
            this.AllowanesAmount = Convert.ToDouble(dr["AllowanesAmount"]);
            this.Deductions = Convert.ToString(dr["Deductions"]);
            this.DedPercentage = Convert.ToInt32(dr["DedPercentage"]);
            this.DedAmount = Convert.ToInt32(dr["DedAmount"]);

            this.Remarks = Convert.ToString(dr["Remarks"]);
            this.IsDeleted = Convert.ToInt32(dr["IsDeleted"]);
            this.CreatedDate = Convert.ToDateTime(dr["IsDeleted"]);
            this.CreatedBy = Convert.ToString(dr["CreatedBy"]);
            this.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);
            this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]);
            this.IsSytemCalucalted = Convert.ToBoolean(dr["IsSytemCalucalted"]);

            this.CEL = Convert.ToString(dr["CEL"]);
            this.NCEL = Convert.ToString(dr["NCEL"]);
            this.Paternity = Convert.ToString(dr["Paternity"]);
            this.HalfDay = Convert.ToString(dr["HalfDay"]);

            this.OverTimeAmount = Convert.ToString(dr["OverTimeAmount"]);
            this.CalcOverTimeAmount = Convert.ToString(dr["OverTimeAmount"]);
            this.ActualEarnSalary = Convert.ToString(dr["OverTimeAmount"]);

            this.SalaryCalculationDate = Convert.ToString(dr["SalaryCalculationDate"]);
            this.HPL = Convert.ToString(dr["HPL"]);
            
        }
        

    }
}
