using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRMS_Classes
{
    public class UnitMaster
    {
        private string _UnitCode;
        private string _UnitName;
        private string _CreatedBy;
        private string _ModifiedBy;
        private Int32 _IsDeleted;
        private string _ModifiedDate;

        public string UnitCode
        {
            get
            {
                return _UnitCode;
            }
            set
            {
                _UnitCode = value;
            }
        }
        public string UnitName
        {
            get
            {
                return _UnitName;
            }
            set
            {
                _UnitName = value;
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
        public string ModifiedDate
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
        public Int32 IsDeleted
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
        public void setObjectInfo(DataRow dr)
        {
            this.UnitCode = Convert.ToString(dr["UnitCode"]);
            this.UnitName = Convert.ToString(dr["UnitName"]);
            this.CreatedBy = Convert.ToString(dr["CreatedBy"]);
            this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]);
            this.ModifiedDate = Convert.ToString(dr["ModifiedDate"]);
            this.IsDeleted = Convert.ToInt32(dr["IsDeleted"]);
        }
    }
}
