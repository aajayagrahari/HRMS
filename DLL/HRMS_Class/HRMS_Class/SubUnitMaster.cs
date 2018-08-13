using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRMS_Classes
{
    public class SubUnitMaster
    {
        private string _SubUnitCode;
        private string _SubUnitName;
        private string _UnitCode;
        private string _UnitName;
        private Int32 _IsDeleted;
        private string _CreatedBy;
        private string _ModifiedBy;
        private string _ModifiedDate;

        public string SubUnitCode
        {
            get
            {
                return _SubUnitCode;
            }
            set
            {
                _SubUnitCode = value;
            }
        }
        public string SubUnitName
        {
            get
            {
                return _SubUnitName;
            }
            set
            {
                _SubUnitName = value;
            }
        }
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
            this.SubUnitCode = Convert.ToString(dr["SubUnitCode"]);
            this.UnitCode = Convert.ToString(dr["UnitCode"]);
            this.UnitName = Convert.ToString(dr["UnitName"]);
            this.SubUnitName = Convert.ToString(dr["SubUnitName"]);
            this.CreatedBy = Convert.ToString(dr["CreatedBy"]);
            this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]);
            this.ModifiedDate = Convert.ToString(dr["ModifiedDate"]);
            this.IsDeleted = Convert.ToInt32(dr["IsDeleted"]);
        }
    }
}
