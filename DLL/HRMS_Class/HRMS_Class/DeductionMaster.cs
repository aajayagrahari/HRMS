using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

#region Developnet Detatil
//Developer Name: Shruti Dwivedi
//Date:           07-10-2013
#endregion Developnet Detatil
namespace HRMS_Class
{
    public class DeductionMaster
    {
        private Int32 _DesuctionId;
        private string _Deductions;
        private string _DeductionPercentage;
        private Int16 _IsDeleted;
        private DateTime _CreatedDate;
        private DateTime _ModifiedDate;
        private string _CreatedBy;
        private string _ModifiedBy;


        public Int32 DesuctionId
        {
            get
            {
                return _DesuctionId;
            }
            set
            {
                _DesuctionId = value;
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
        public string DeductionPercentage
        {
            get
            {
                return _DeductionPercentage;
            }
            set
            {
                _DeductionPercentage = value;
            }
        }
        public Int16 IsDeleted
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
        public void SetObjectInfo(DataRow dr)
        {
            this.DesuctionId = Convert.ToInt32(dr["DesuctionId"]);
            this.Deductions = Convert.ToString(dr["Deductions"]);
            this.DeductionPercentage = Convert.ToString(dr["DeductionPercentage"]);
            this.IsDeleted = Convert.ToInt16(dr["IsDeleted"]);
            this.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
            this.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);
            this.CreatedBy = Convert.ToString(dr["CreatedBy"]);
            this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]);

        }


    }
}
