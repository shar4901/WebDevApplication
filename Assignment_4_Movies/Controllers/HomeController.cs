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

        private StudentFormContext _blahContext;
        //constructor
        public HomeController(ILogger<HomeController> logger, StudentFormContext someName)
        {
            _blahContext = someName;
        }



        //Index page controller
        public async Task<IActionResult> Index()
        {
            var student = await _blahContext.student.ToListAsync();
            return View(student);
        }

        //Delete student index page
        [HttpPost]
        public async Task<IActionResult> Index(StudentModel students)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var exist = _blahContext.student.Where(x => x.student_id == students.student_id).FirstOrDefault();

                    if (exist != null)
                    {
                        _blahContext.Remove(exist);
                        await _blahContext.SaveChangesAsync();

                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Something went wrong {ex.Message}");
                }
            }

            ModelState.AddModelError(string.Empty, $"Something went wrong, invalid model");

            return View();
        }


        //Edit Student controller
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var exist = await _blahContext.student.Where(x => x.student_id == id).FirstOrDefaultAsync();

            return View(exist);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentModel studentInstance)
        {
            // validate that our model meets the requirement
            if (ModelState.IsValid)
            {
                try
                {
                    // Check if the contact exist based on the id
                    var exist = _blahContext.student.Where(x => x.student_id == studentInstance.student_id).FirstOrDefault();

                    // if the contact is not null we update the information
                    if (exist != null)
                    {
                        exist.first_name = studentInstance.first_name;
                        exist.last_name = studentInstance.last_name;
                        exist.street_address = studentInstance.street_address;
                        exist.city = studentInstance.city;
                        exist.state = studentInstance.state;
                        exist.zip = studentInstance.zip;
                        exist.phone_number = studentInstance.phone_number;
                        exist.email = studentInstance.email;
                        exist.category = studentInstance.category;

                        // we save the changes into the db
                        await _blahContext.SaveChangesAsync();

                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Something went wrong {ex.Message}");
                }
            }

            ModelState.AddModelError(string.Empty, $"Something went wrong, invalid model");

            return View(studentInstance);
        }

        //Delete Student controller
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var exist = await _blahContext.student.Where(x => x.student_id == id).FirstOrDefaultAsync();

            return View(exist);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(StudentModel students)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var exist = _blahContext.student.Where(x => x.student_id == students.student_id).FirstOrDefault();

                    if (exist != null)
                    {
                        _blahContext.Remove(exist);
                        await _blahContext.SaveChangesAsync();

                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Something went wrong {ex.Message}");
                }
            }

            ModelState.AddModelError(string.Empty, $"Something went wrong, invalid model");

            return View();
        }




        //Create Student Controller
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
