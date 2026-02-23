using System.Diagnostics;
using EmployeeCRUD.Models;
using Microsoft.AspNetCore.Mvc;
//importanciones
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeCRUD.Model;
//


namespace EmployeeCRUD.Controllers
{
    public class HomeController : Controller {

        private readonly CrudEmployeeContext _dbContext;

        public HomeController(CrudEmployeeContext dbContext)
        {
                _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Employee>EmployeeList = _dbContext.Employees.Include(r => r.ObjRol).ToList();
            //Consulta a la BD para traer la data incluyyendo los datos relacionados de la tabla Rol
            return View(EmployeeList);
        }


    }
}
