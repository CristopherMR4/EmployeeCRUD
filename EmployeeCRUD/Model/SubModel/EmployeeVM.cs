//import
using Microsoft.AspNetCore.Mvc.Rendering;


namespace EmployeeCRUD.Model.SubModel
{
    public class EmployeeVM
    {
        public Employee oEmployee {  get; set; }
        //in a sfer way to use the values of Employee

        public List<SelectListItem> oRolList { get; set; }
        //this a list that will have the values of my table Rol

    }
}
