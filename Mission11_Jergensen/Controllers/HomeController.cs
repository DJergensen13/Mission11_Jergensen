using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;
using Mission11_Jergensen.Models;
using Mission11_Jergensen.Models.ViewModels;

// using Mission11_Jergensen.Models;

namespace Mission11_Jergensen.Controllers;

public class HomeController : Controller
{
    private IBookRepository _repo;

    public HomeController(IBookRepository temp)
    {
        _repo = temp;
    }

    public IActionResult Index(int pageNum)
    {
        int pageSize = 10;
        var blah = new BooksList()
        {
            Books = _repo.Books
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
                
            PaginationInfo = new PaginationInfo
            {
                CurrentPage = pageNum,
                ItemsPerPage = pageSize,
                TotalItems = _repo.Books.Count()
            }
        };
        
        return View(blah);
    }

}