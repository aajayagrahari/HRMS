using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HRMS_Class
{
    public class HolidayMaster
    {
        private Int32 _HolidaysId;
        private string _HoliDays;
        private string _FinancialYear;
        private string _EnglishMonth;
        private Int32 _EnglishDate;
        private string _SakaMonth;
        private Int32 _SakaDate;
        private string _HoliDays_Day;
        private string _Holidays_Type;
        private bool _IsDeleted;
        private DateTime _CreatedDate;
        private string _CreatedBy;
        private DateTime _ModifiedDate;
        private string _ModifiedBy;

        public Int32 HolidaysId
        {
            get
            {
                return _HolidaysId;
            }
            set
            {
                _HolidaysId = value;
            }
        }
        public string FinancialYear
        {
            get
            {
                return _FinancialYear;
            }
            set
            {
                _FinancialYear = value;
            }
        }
        public Int32 EnglishDate
        {
            get
            {
                return _EnglishDate;
            }
            set
            {
                _EnglishDate = value;
            }
        }
        public Int32 SakaDate
        {
            get
            {
                return _SakaDate;
            }
            set
            {
                _SakaDate = value;
            }
        }

        public string HoliDays
        {
            get
            {
                return _HoliDays;
            }
            set
            {
                _HoliDays = value;
            }
        }
        public string EnglishMonth
        {
            get
            {
                return _EnglishMonth;
            }
            set
            {
                _EnglishMonth = value;
            }
        }
        public string SakaMonth
        {
            get
            {
                return _SakaMonth;
            }
            set
            {
                _SakaMonth = value;
            }
        }
        public string HoliDays_Day
        {
            get
            {
                return _HoliDays_Day;
            }
            set
            {
                _HoliDays_Day = value;
            }
        }
        public string Holidays_Type
        {
            get
            {
                return _Holidays_Type;
            }
            set
            {
                _Holidays_Type = value;
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



        public void SetObjectInfo(DataRow dr)
        {
            this.HolidaysId = Convert.ToInt32(dr["HolidaysId"]);
            this.FinancialYear = Convert.ToString(dr["FinancialYear"]);
            this.EnglishDate = Convert.ToInt32(dr["EnglishDate"]);
            this.SakaDate = Convert.ToInt32(dr["SakaDate"]);
            this.HoliDays = Convert.ToString(dr["HoliDays"]);
            this.EnglishMonth = Convert.ToString(dr["EnglishMonth"]);
            this.SakaMonth = Convert.ToString(dr["SakaMonth"]);
            this.HoliDays_Day = Convert.ToString(dr["HoliDays_Day"]);
            this.Holidays_Type = Convert.ToString(dr["Holidays_Type"]);
            //this.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);
            this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]);
            this.IsDeleted = Convert.ToBoolean(dr["IsDeleted"]);
           // this.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
            this.CreatedBy = Convert.ToString(dr["CreatedBy"]);
            

        }





    }
            
}
