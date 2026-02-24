using System.Diagnostics;
using EmployeeCRUD.Models;
using Microsoft.AspNetCore.Mvc;
//importaciones
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeCRUD.Model;
//
using EmployeeCRUD.Model.SubModel;
using Microsoft.Identity.Client;


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

        [HttpGet]
        public IActionResult EmployeeDetail() {

            //creation of an object that will help us to create a new employee in a safer way than directly
            //affecting the main classes.
            EmployeeVM oEmployeeVM = new EmployeeVM()
            {

                oEmployee = new Employee(),
                oRolList = _dbContext.Rols.Select(rol => new SelectListItem()
                {
                    Text = rol.Detail,
                    Value = rol.IdRol.ToString()
                }).ToList(),
                

            };

            return View(oEmployeeVM);        
        }

        [HttpPost]
        public IActionResult EmployeeDetail(EmployeeVM oEmployeeVM) {

            if(oEmployeeVM.oEmployee.IdEmployee == 0)
            {
                _dbContext.Employees.Add(oEmployeeVM.oEmployee);
            }

            _dbContext.SaveChanges();

            return RedirectToAction("Index","Home");
        }


    }
}
