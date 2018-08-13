using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRMS_Class
{
    public class PostMaster
    {
        private string _PostId;
        private string _PostName;
        private Int32 _AdvertisementId;
        private bool _IsDeleted;
        private string _CreatedDate;
        private string _CreatedBy;
        private string _ModifiedDate;
        private string _ModifiedBy;
        private string _PostDescription;
        private Int32 _MinAge;
        private Int32 _MaxAge;

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
        public string PostName
        {
            get
            {
                return _PostName;
            }
            set
            {
                _PostName = value;
            }
        }
        public Int32 AdvertisementId
        {
            get
            {
                return _AdvertisementId;
            }
            set
            {
                _AdvertisementId = value;
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
        public string PostDescription
        {
            get
            {
                return _PostDescription;
            }
            set
            {
                _PostDescription = value;
            }
        }
        public Int32 MinAge
        {
            get
            {
                return _MinAge;
            }
            set
            {
                _MinAge = value;
            }

        }
        public Int32 MaxAge
        {
            get
            {
                return _MaxAge;
            }
            set
            {
                _MaxAge = value;
            }
        }

        public void SetObjectInfo(DataRow dr)
        {
           
            this.PostId = Convert.ToString(dr["PostId"]);
            this.PostName = Convert.ToString(dr["PostName"]);
            this.AdvertisementId = Convert.ToInt32(dr["AdvertisementId"]);
            this.IsDeleted = Convert.ToBoolean(dr["IsDeleted"]);
            this.CreatedDate = Convert.ToString(dr["CreatedDate"]);
            this.CreatedBy = Convert.ToString(dr["CreatedBy"]);
            this.ModifiedDate = Convert.ToString(dr["ModifiedDate"]);
            this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]);
            this.PostDescription = Convert.ToString(dr["PostDescription"]);
            this.MaxAge = Convert.ToInt32(dr["MaxAge"]);
            this.MaxAge = Convert.ToInt32(dr["MaxAge"]);
            
        }
    }
}
