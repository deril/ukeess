using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ukeess.Models;
using Ukeess.Models.ViewModels;

namespace Ukeess.Controllers
{
    public class EmployeesController : Controller
    {
        public int PageSize = 10;
        readonly IEmployeeRepository employeeRepository;
        readonly IDepartmentRepository departmentRepository;

        public EmployeesController(IEmployeeRepository employeeRepo, IDepartmentRepository departmentRepo)
        {
            employeeRepository = employeeRepo;
            departmentRepository = departmentRepo;
        }

        public ViewResult Index(string query, int employeePage = 1)
        {
            var employees = employeeRepository.Employees;
            if (!string.IsNullOrEmpty(query))
            {
                employees = employees.Where(e => EF.Functions.Like(e.Name, $"{query}%"));
            }

            ViewData["CurrentFilter"] = query;

            return View(new EmployeesListViewModel
            {
                Employees = employees
                    .OrderBy(e => e.EmployeeID)
                    .Skip((employeePage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = employeePage,
                    ItemsPerPage = PageSize,
                    TotalItems = employees.Count()
                }
            });
        }

        public ViewResult Show(int id) =>
            View(employeeRepository.Employees.FirstOrDefault(e => e.EmployeeID == id));

        public ViewResult Edit(int id) => View(new EmployeeEditViewModel
            {
                Emloyee = employeeRepository.Employees.FirstOrDefault(e => e.EmployeeID == id),
                Departments = new SelectList(departmentRepository.Departments, "DepartmentID", "Name")
            });

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            employeeRepository.SaveEmployee(employee);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int employeeID)
        {
            employeeRepository.DeleteEmployee(employeeID);
            return RedirectToAction("Index");
        }
    }
}
