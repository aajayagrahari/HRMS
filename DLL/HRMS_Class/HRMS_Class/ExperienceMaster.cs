using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ErrorHandler;
using HRMS_Class;
using System.Data;
using HRMS_Connection;
#region Developnet Detatil
//Developer Name: Harendra Kumar Maurya
//Date:           19-10-2013
#endregion Developnet Detatil

namespace HRMS_Class
{
  public class ExperienceMaster
    {
   long  _ExperienceId;
string _Organization;
string _Designation;
string _Duration;
decimal _Salary;
string _JobDescription;
long _RRId;
public long ExperienceId
{
    get
    {
        return _ExperienceId;
    }
    set
    {
        _ExperienceId = value;
    }
}
public long RRId
{
    get
    {
        return _RRId;
    }
    set
    {
        _RRId = value;
    }
}
public string Organization
{
    get
    {
        return _Organization;
    }
    set
    {
        _Organization = value;
    }
}
public string Designation
{
    get
    {
        return _Designation;
    }
    set
    {
        _Designation = value;
    }
}
public string Duration
{
    get
    {
        return _Duration;
    }
    set
    {
        _Duration = value;
    }
}
public decimal Salary
{
    get
    {
        return _Salary;
    }
    set
    {
        _Salary = value;
    }
}
public string JobDescription
{
    get
    {
        return _JobDescription;
    }
    set
    {
        _JobDescription = value;
    }
}
    }
}
