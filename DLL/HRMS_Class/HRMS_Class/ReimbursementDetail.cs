using System;
using System.Data;

namespace HRMS_Class
{
    public class ReimbursementDetail
    {
        private Int32 _ReimbursementDetailId;
        private Int32 _ReimbursementId;
        private string _ReimbursementDate;
        private string _ReimbursementDescription;
        private string _Category;
        private string _Cost;
        private bool _IsDeleted;
        private string _CreatedDate;
        private string _CreatedBy;
        private string _ModifiedDate;
        private string _ModifiedBy;

        private int _IsApprove;
        private string _ApprovedBy;
        private string _ApprovedDate;


        private bool _IsSubmitted;
        private string _SubmittedBy;
        private string _SubmittedDate;

        public Int32 ReimbursementDetailId
        {
            get
            {
                return _ReimbursementDetailId;
            }
            set
            {
                _ReimbursementDetailId = value;
            }
        }
        public Int32 ReimbursementId
        {
            get
            {
                return _ReimbursementId;
            }
            set
            {
                _ReimbursementId = value;
            }
        }
        public string ReimbursementDate
        {
            get
            {
                return _ReimbursementDate;
            }
            set
            {
                _ReimbursementDate = value;
            }
        }
        public string ReimbursementDescription
        {
            get
            {
                return _ReimbursementDescription;
            }
            set
            {
                _ReimbursementDescription = value;
            }
        }
        public string Category
        {
            get
            {
                return _Category;
            }
            set
            {
                _Category = value;
            }
        }
        public string Cost
        {
            get
            {
                return _Cost;
            }
            set
            {
                _Cost = value;
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

        public string ApprovedBy
        {
            get
            {
                return _ApprovedBy;
            }
            set
            {
                _ApprovedBy = value;
            }
        }
        public string ApprovedDate
        {
            get
            {
                return _ApprovedDate;
            }
            set
            {
                _ApprovedDate = value;
            }
        }
        public int IsApprove
        {
            get
            {
                return _IsApprove;
            }
            set
            {
                _IsApprove = value;
            }
        }


        public string SubmittedBy
        {
            get
            {
                return _SubmittedBy;
            }
            set
            {
                _SubmittedBy = value;
            }
        }
        public string SubmittedDate
        {
            get
            {
                return _SubmittedDate;
            }
            set
            {
                _SubmittedDate = value;
            }
        }
        public bool IsSubmitted
        {
            get
            {
                return _IsSubmitted;
            }
            set
            {
                _IsSubmitted = value;
            }
        }




        public void SetObjectInfo(DataRow dr)
        {
            this.ReimbursementDetailId = Convert.ToInt32(dr["ReimbursementDetailId"]);
            this.ReimbursementId = Convert.ToInt32(dr["ReimbursementId"]);
            this.ReimbursementDate = Convert.ToString(dr["ReimbursementDate"]);
            this.ReimbursementDescription = Convert.ToString(dr["ReimbursementDescription"]);
            this.Category = Convert.ToString(dr["Category"]);
            this.Cost = Convert.ToString(dr["Cost"]);
            this.IsDeleted = Convert.ToBoolean(dr["IsDeleted"]);
            this.CreatedDate = Convert.ToString(dr["CreatedDate"]);
            this.CreatedBy = Convert.ToString(dr["CreatedBy"]);
            this.ModifiedDate = Convert.ToString(dr["ModifiedDate"]);
            this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]);

            this.ApprovedBy = Convert.ToString(dr["ApprovedBy"]);
            this.ApprovedDate = Convert.ToString(dr["ApprovedDate"]);
            this.IsApprove = Convert.ToInt32(dr["IsApprove"]);


            this.SubmittedBy = Convert.ToString(dr["SubmittedBy"]);
            this.SubmittedDate = Convert.ToString(dr["SubmittedDate"]);
            this.IsSubmitted = Convert.ToBoolean(dr["IsSubmitted"]);


        }
    }
}
