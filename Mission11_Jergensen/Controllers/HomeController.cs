using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
// using Mission11_Jergensen.Models;

namespace Mission11_Jergensen.Controllers;

public class HomeController : Controller
{

    public HomeController()
    {
    }

    public IActionResult Index()
    {
        return View();
    }

}