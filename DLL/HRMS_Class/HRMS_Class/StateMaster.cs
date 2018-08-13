using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HRMS_Class
{
    public class StateMaster
    {
        private string _StateCode;
        private string _StateName;
        private string _CountryCode;

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

        public string StateCode
        {
            get
            {
                return _StateCode;
            }
            set
            {
                _StateCode = value;
            }
        }

        public string StateName
        {
            get
            {
                return _StateName;
            }
            set
            {
                _StateName = value;
            }
        }

        public void SetObjectInfo(DataRow dr)
        {
            this.CountryCode = Convert.ToString(dr["CountryCode"]);
            this.StateCode = Convert.ToString(dr["StateCode"]);
            this.StateName = Convert.ToString(dr["StateName"]);
        }
    }
}
