using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HRMS_Class
{
    public class AdvertisemetnMaster
    {
       private Int32 _AdvertisementId;
        private string _AdvertisementName;
        private string _OpeningDate;
        private string _ClosingDate;
        private bool _IsDeleted;
        private string _CreatedDate;
        private string _CreatedBy;
        private string _ModifiedDate;
        private string _ModifiedBy;
        private string _AdverDescription;
        private string _PDFFileName;

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
        public string AdvertisementName
        {
            get
            {
                return _AdvertisementName;
            }
            set
            {
                _AdvertisementName = value;
            }
        }
        public string OpeningDate
        {
            get
            {
                return _OpeningDate;
            }
            set
            {
                _OpeningDate = value;
            }
        }

        public string ClosingDate
        {
            get
            {
                return _ClosingDate;
            }
            set
            {
                _ClosingDate = value;
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
        public string AdverDescription
        {
            get
            {
                return _AdverDescription;
            }
            set
            {
                _AdverDescription = value;
            }
        }
        public string PDFFileName
        {
            get
            {
                return _PDFFileName;
            }
            set
            {
                _PDFFileName = value;
            }
        }

        public void SetObjectInfo(DataRow dr)
        {
            this.AdvertisementId = Convert.ToInt32(dr["AdvertisementId"]);
            this.AdvertisementName = Convert.ToString(dr["AdvertisementName"]);
            this.OpeningDate = Convert.ToString(dr["OpeningDate"]);
            this.ClosingDate = Convert.ToString(dr["ClosingDate"]);
            this.IsDeleted = Convert.ToBoolean(dr["IsDeleted"]);
            this.CreatedDate = Convert.ToString(dr["CreatedDate"]);
            this.CreatedBy = Convert.ToString(dr["CreatedBy"]);
            this.ModifiedDate = Convert.ToString(dr["ModifiedDate"]);
            this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]);
            this.AdverDescription = Convert.ToString(dr["AdverDescription"]);
            this.PDFFileName = Convert.ToString(dr["PDFFileName"]);
        }
    }
}
