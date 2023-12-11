using EmployeeInfo.Models;
using EmployeeInfo.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using X.PagedList;

namespace EmployeeInfo.Controllers
{
    public class HomeController : Controller
    {
        public readonly IEmployeeService _employeeService;

        public HomeController(IEmployeeService employeeService)
        {          
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EmployeeLis(int page = 1, string sortOrder = "")
        {
            try
            {
                ViewData["sortOrder"] = sortOrder == "" || sortOrder == "asc" ? "des" : "asc";
                var list = _employeeService.GetAllEmployeeDetail();

                List<Employee> emplist = new List<Employee>(list);
                if (sortOrder == "des")
                {
                    emplist = emplist.OrderByDescending(emp => emp.EmpId).ToList();
                }
                else
                {
                    emplist = emplist.OrderBy(emp => emp.EmpId).ToList();
                }

                var empData = emplist.ToPagedList(page, 5);
                return View(empData);
            }
            catch (Exception ex)
            {
                return BadRequest(false);
            }          

        }

        public IActionResult Edit(Employee item)
        {
            return View(item);
        }


        public IActionResult Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    bool deleted = _employeeService.DeleteEmployeeDetail(id);
                    return RedirectToAction("EmployeeLis");
                }
                else
                {
                    return BadRequest(false);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult AddEditEmployeeDetails(Employee emp)
        {
            try
            {            
                _employeeService.SaveEmployeeDetail(emp);
                return RedirectToAction("EmployeeLis");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getuniquecode")]
        public IActionResult GetUniqueCode(string emp_code)
        {
            try
            {
                var uniqueCode = _employeeService.IsUniqueCode(emp_code);
                return Ok(uniqueCode);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}