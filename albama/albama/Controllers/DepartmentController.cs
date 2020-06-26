using albama.Models;
using albama.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace albama.Controllers
{
    public class DepartmentController:Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Department Index";
            var departments = await _departmentService.GetAll();
            return View(departments);
        }
        [HttpGet] // 默认可以不写 默认为get
        public IActionResult Add()
        {
            ViewBag.Title = "Add Department";
            return View(new Department());
        }
        [HttpPost]
        public async Task<IActionResult> add(Department model)
        {
            // 判断是否合法 
            if(ModelState.IsValid)
            {
                await _departmentService.Add(model);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
