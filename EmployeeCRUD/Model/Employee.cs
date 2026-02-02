using System;
using System.Collections.Generic;

namespace EmployeeCRUD.Model;

public partial class Employee
{
    public int IdEmployee { get; set; }

    public string? UserName { get; set; }

    public string? Mail { get; set; }

    public string? Cellphone { get; set; }

    public int? Rolid { get; set; }


    //changing the name
    public virtual Rol? ObjRol { get; set; }
}
