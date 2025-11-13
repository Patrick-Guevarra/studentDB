using Microsoft.AspNetCore.Mvc;
using Student.Data;
using Student.Models;

namespace Student.Controllers
{
    public class StudentController : Controller
    {
        private StudentContext context { get; set; }

        public StudentController(StudentContext ctx) =>
            context = ctx;

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new StudentEntity());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var student = context.Students.Find(id);
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(StudentEntity student)
        {
            if (ModelState.IsValid)
            {
                if (student.StudentId == 0)
                    context.Students.Add(student);
                else
                    context.Students.Update(student);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action =
                    (student.StudentId == 0) ? "Add" : "Edit";
                return View(student);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = context.Students.Find(id);
            return View(student);
        }
        [HttpPost]
        public IActionResult Delete(StudentEntity student)
        {
            context.Students.Remove(student);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}