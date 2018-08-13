using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRMS_Class
{
    public class PostQEDetail
    {
        private string _PostQEDetailId;
        private string _PostId;
        private string _QualificationDetail;
        private string _ExperienceDetail;
        private string _QualificationType;
        private bool _IsDeleted;
        private DateTime _CreatedDate;
        private string _CreatedBy;
        private DateTime _ModifiedDate;
        private string _ModifiedBy;
        string _EType;
        public string EType
        {
            get
            {
                return _EType;
            }
            set
            {
                _EType = value;
            }

        }
        public string PostQEDetailId
        {
            get
            {
                return _PostQEDetailId;
            }
            set
            {
                _PostQEDetailId = value;
            }
        }
        public string PostId
        {
            get
            {
                return _PostId;
            }
            set
            {
                _PostId = value;
            }
        }
        public string QualificationDetail
        {
            get
            {
                return _QualificationDetail;
            }
            set
            {
                _QualificationDetail = value;
            }
        }
        public string ExperienceDetail
        {
            get
            {
                return _ExperienceDetail;
            }
            set
            {
                _ExperienceDetail = value;
            }
        }
        public string QualificationType
        {
            get
            {
                return _QualificationType;
            }
            set
            {
                _QualificationType = value;
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

            this.PostQEDetailId = Convert.ToString(dr["PostQEDetailId"]);
            this.PostId = Convert.ToString(dr["PostId"]);
            this.QualificationDetail = Convert.ToString(dr["QualificationDetail"]);
            this.ExperienceDetail = Convert.ToString(dr["ExperienceDetail"]);
            this.QualificationType = Convert.ToString(dr["QualificationType"]);
            this.CreatedBy = Convert.ToString(dr["CreatedBy"]);
            this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]);
            this.IsDeleted = Convert.ToBoolean(dr["IsDeleted"]);
            this.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
            this.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);

           

        }
    }
            
}
