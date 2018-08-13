using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
#region Developnet Detatil
//Developer Name: Harendra kumar Maurya
//Date:           14-10-2013
#endregion Developnet Detatil
namespace HRMS_Class
{
    public class CircularMaster
    {
       long _CId;
string _Title;
string _Description;

string _CreatedBy;
string _ModifiedBy;
int _IsDeleted;

public long CId
        {
            get
            {
                return _CId;
            }
            set
            {
                _CId = value;
            }
        }
public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
            }
        }
public string Description
{
    get
    {
        return _Description;
    }
    set
    {
        _Description = value;
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
public int IsDeleted
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
    this.CId = Convert.ToInt64(dr["CId"]);
    this.Title = Convert.ToString(dr["Title"]);
    this.IsDeleted = Convert.ToInt32(dr["IsDeleted"]);
    this.Description = Convert.ToString(dr["Description"]);
    this._CreatedBy = Convert.ToString(dr["_CreatedBy"]);
    this.CreatedBy = Convert.ToString(dr["CreatedBy"]);
    this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]);

}
    }
}
