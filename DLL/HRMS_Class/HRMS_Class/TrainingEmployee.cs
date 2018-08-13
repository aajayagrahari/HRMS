using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRMS_Class
{
    public class TrainingEmployee
    {
        private Int32 _TrainingEmployeeId;
        private Int32 _TrainingId;
        private string _EmployeeId;
        private string _CreatedDate;
        private string _CreatedBy;
        private string _ModifiedDate;
        private string _ModifiedBy;
        private bool _IsDeleted;

        public Int32 TrainingEmployeeId
        {
            get
            {
                return _TrainingEmployeeId;
            }
            set
            {
                _TrainingEmployeeId = value;
            }
        }
        public Int32 TrainingId
        {
            get
            {
                return _TrainingId;
            }
            set
            {
                _TrainingId = value;
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
        public string CreatedDate
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
        public void SetObjectInfo(DataRow dr)
        {
            this.TrainingEmployeeId = Convert.ToInt32(dr["TrainingEmployeeId"]);
            this.TrainingId = Convert.ToInt32(dr["TrainingId"]);
            this.EmployeeId = Convert.ToString(dr["EmployeeId"]);
            this.CreatedDate = Convert.ToString(dr["CreatedDate"]);
            this.CreatedBy = Convert.ToString(dr["CreatedBy"]);
            this._ModifiedDate = Convert.ToString(dr["_ModifiedDate"]);
            this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]);
           

        }
    }
}
