using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace HRMS_Class
{
    public class JobMaster
    {
long  _JobId=0;
string _Title=null;
string _Description=null;
string _Files=null;
string    _CreatedBy=null;
string _ModifiedBy = null;
int _IsDeleted = 0;
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
public long JobId
{
    get
    {
        return _JobId;
    }
    set
    {
        _JobId = value;
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
public string Files
{
    get
    {
        return _Files;
    }
    set
    {
        _Files = value;
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
    this.JobId = Convert.ToInt64(dr["JobId"]);
    this.Title = Convert.ToString(dr["Title"]);
    this.Description = Convert.ToString(dr["Description"]);
    this.Files = Convert.ToString(dr["Files"]);
    this.CreatedBy = Convert.ToString(dr["CreatedBy"]);
    this.ModifiedBy = Convert.ToString(dr["ModifiedBy"]);
    this.IsDeleted = Convert.ToInt32(dr["IsDeleted"]);
}

    }
}
