using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private booksContext context;
        private readonly ILogger<HomeController> _logger;
        public HomeController(booksContext context, ILogger<HomeController> logger)
        {
            this.context = context;
            _logger = logger;

        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult List()
        {
            return View(context.Books);//Sql e çeviriyor
        }
        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBook(Book model)
        {
            context.Books.Add(model);
            context.SaveChanges();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}