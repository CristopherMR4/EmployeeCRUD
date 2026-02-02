using System;
using System.Collections.Generic;

namespace EmployeeCRUD.Model;

public partial class Rol
{
    public int IdRol { get; set; }

    public string? Detail { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
