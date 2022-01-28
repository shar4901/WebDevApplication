using Assignment_4_Movies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_4_Movies.Controllers
{
    public class HomeController : Controller
    {
        //private ILogger<HomeController> _logger;

        private StudentFormContext _blahContext { get; set; }
        //constructor
        public HomeController(ILogger<HomeController> logger, StudentFormContext someName)
        {
            _blahContext = someName;
        }



        //public IActionResult Index()
        //{
        //    return View();
        //}
        public async Task<IActionResult> Index()
        {
            var student = await _blahContext.student.ToListAsync();
            return View(student);
        }

        //edit controller

        [HttpGet]
        public IActionResult CreateStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateStudent(StudentModel ar)
        {
            if (ModelState.IsValid) {
                _blahContext.Add(ar);
                _blahContext.SaveChanges();
                return View("submissionConf", ar);
            }
            else  {
                return View(ar);
            }
                

            
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
