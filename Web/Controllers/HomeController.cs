using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Web.Models;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        
        private IEmployeeRepository employeeRepository;
        private readonly IWebHostEnvironment WebHostEnvironment;
        public HomeController(IEmployeeRepository employeeRepository, IWebHostEnvironment WebHostEnvironment)
        {
            this.employeeRepository = employeeRepository;
            this.WebHostEnvironment = WebHostEnvironment;
        }

        public ViewResult Index()
        {
            var employees = employeeRepository.Gets();
            return View(employees);
        }

        public ViewResult Details(int? id)
        {
            try
            {
                int.Parse(id.Value.ToString());
                var employee = employeeRepository.Get(id.Value);
                if (employee == null)
                {
                   
                    return View("~/Views/Error/EmployeeNotFound.cshtml", id.Value);
                }
                var detailViewModel = new HomeDetailViewModel()
                {
                    Employee = employeeRepository.Get(id.Value),
                    TitleName = "Employee Details"
                };
                return View(detailViewModel);
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(HomeCreateViewModel model) 
        {
            if(ModelState.IsValid)
            {
                var employee = new Employee()
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    Department = model.Department
                };
                var fileName = string.Empty;
                if(model.Avatar != null)
                {
                    string uploadFolder = Path.Combine(WebHostEnvironment.WebRootPath, "images");
                    fileName = model.Avatar.FileName;
                    var filePath = Path.Combine(uploadFolder, fileName);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        model.Avatar.CopyTo(fs);
                    }    
                }
                employee.AvatarPath = fileName;
                var newEmployee = employeeRepository.Create(employee);
                return RedirectToAction("Details", new { id = newEmployee.ID });
            }
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            var employee = employeeRepository.Get(id);
            if (employee == null)
            {
                //ViewBag.id = id.Value;
                return View("~/Views/Error/EmployeeNotFound.cshtml", id);
            }
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            var employee = employeeRepository.Edit(model);
            if (employee != null)
            {                                                                                                       
                return RedirectToAction("Details", new { id = employee.ID});
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            if(employeeRepository.Delete(id))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
