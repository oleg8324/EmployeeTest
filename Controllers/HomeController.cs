using EmployeeTest.data;
using EmployeeTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private EmployeeService _employeeService;

        public HomeController(ILogger<HomeController> logger, EmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            return View(_employeeService.Employees);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
        [HttpPost]
        public ActionResult Work(int id, IFormCollection form)
        {
            var employee = _employeeService.Employees[id]; // Get the employee with the given id
            int days = int.Parse(form["days"]);
            employee.Work(days);

            return RedirectToAction("Index");
        }

        
        [HttpPost]
        public ActionResult TakeVacation(int id, IFormCollection form)
        {
            var employee = _employeeService.Employees[id]; // Get the employee with the given id
            float days = float.Parse(form["days"]);
            employee.TakeVacation(days);

            return RedirectToAction("Index");
        }
    }
}