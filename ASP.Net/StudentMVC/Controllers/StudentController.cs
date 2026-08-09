using Microsoft.AspNetCore.Mvc;
using StudentMVC.Data;
using StudentMVC.Models;

namespace StudentMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = new Dictionary<string, string>();

                    foreach (var key in ModelState.Keys)
                    {
                        var error = ModelState[key].Errors.FirstOrDefault();
                        if (error != null)
                            errors[key] = error.ErrorMessage;
                    }

                    return Json(new { success = false, errors = errors });
                }

                _context.Students.Add(student);
                _context.SaveChanges();

                return Json(new
                {
                    success = true,
                    message = $"{student.Name} added successfully"
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error: " + ex.Message });
            }
        }

        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
                return NotFound();
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = new Dictionary<string, string>();
                    foreach (var key in ModelState.Keys)
                    {
                        var error = ModelState[key].Errors.FirstOrDefault();
                        if (error != null)
                            errors[key] = error.ErrorMessage;
                    }
                    return Json(new { success = false, errors = errors });
                }

                _context.Students.Update(student);
                _context.SaveChanges();

                return Json(new
                {
                    success = true,
                    message = $"{student.Name} updated successfully"
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error: " + ex.Message });
            }
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var student = _context.Students.Find(id);
                if (student == null)
                    return Json(new { success = false, message = "Student not found" });

                _context.Students.Remove(student);
                _context.SaveChanges();
                return Json(new { success = true, message = $"{student.Name} deleted successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error: " + ex.Message });
            }
        }


    }
}