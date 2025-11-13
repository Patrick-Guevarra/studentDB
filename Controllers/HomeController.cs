using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Student.Models;
using Student.Data;

namespace Student.Controllers;

public class HomeController : Controller
{
    private StudentContext context { get; set; }

    public HomeController(StudentContext ctx) =>
        context = ctx;
    
    public IActionResult Index()
    {
        // sorts students by last name, then first name if two have the same last name
        var students = context.Students.OrderBy(s => s.LastName).ThenBy(s=> s.FirstName).ToList();
        return View(students);
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
}
