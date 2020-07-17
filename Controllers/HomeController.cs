using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Demo.Models;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext context;
        private readonly IClassRepository classRepository;
        private readonly IStudentRepository studentRepository;
        public HomeController(AppDbContext context, IClassRepository classRepository, IStudentRepository studentRepository)
        {
            this.context = context;
            this.classRepository = classRepository;
            this.studentRepository = studentRepository;
        }

        public IActionResult Index()
        {
            return View(classRepository.Get());
        }
        public IActionResult Class(int id)
        {
            var cls = classRepository.Get(id);
            if (cls == null)
            {
                return RedirectToAction("Error");
            }
            var students = (from s in context.Students where s.ClassId == id select s);
            ViewBag.Class = cls;
            return View(students);
        }
        public IActionResult ViewStudent(int id)
        {
            var std = studentRepository.Get(id);
            if (std == null)
            {
                return RedirectToAction("Error");
            }
            ViewBag.Class = classRepository.Get(std.ClassId);
            return View(std);
        }
        [HttpGet]
        public IActionResult CreateStudent()
        {
            ViewBag.Classes = classRepository.Get();
            return View();
        }
        [HttpPost]
        public IActionResult CreateStudent(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var student = studentRepository.Create(new Student()
                {
                    ClassId = model.ClassId,
                    Dob = model.Dob,
                    FullName = model.FullName,
                    Gender = model.Gender,
                    Email = model.Email
                });
                return RedirectToAction("ViewStudent", "Home", new { id = student.StudentId });
            }
            ModelState.AddModelError("", "Có lỗi trong quá trình thực hiện, xin hãy thử lại!");
            return View();
        }
        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            var std = studentRepository.Get(id);
            if (std == null)
            {
                return RedirectToAction("Error");
            }
            ViewBag.Classes = classRepository.Get();
            return View(std);
        }
        [HttpPost]
        public IActionResult EditStudent(Student student)
        {
            if (ModelState.IsValid)
                if (studentRepository.Edit(student) != null)
                    return RedirectToAction("ViewStudent", "Home", new { id = student.StudentId });
            ModelState.AddModelError("", "Có lỗi trong quá trình thực hiện, xin hãy thử lại!");
            return View();
        }
        public IActionResult RemoveStudent(int id)
        {
            var std = studentRepository.Get(id);
            if (std == null)
            {
                return RedirectToAction("Error");
            }
            studentRepository.Remove(id);
            return RedirectToAction("Class", "Home", new { id = std.ClassId });
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
