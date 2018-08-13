using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HRMS_Class
{
    public class CountryMaster
    {
        private string _CountryCode;
        private string _CountryName;

        public string CountryCode
        {
            get
            {
                return _CountryCode;
            }
            set
            {
                _CountryCode = value;
            }
        }

        public string CountryName
        {
            get
            {
                return _CountryName;
            }
            set
            {
                _CountryName = value;
            }
        }

        public void SetObjectInfo(DataRow dr)
        {
            this.CountryCode = Convert.ToString(dr["CountryCode"]);
            this.CountryName = Convert.ToString(dr["CountryName"]);
        }
    }
}
