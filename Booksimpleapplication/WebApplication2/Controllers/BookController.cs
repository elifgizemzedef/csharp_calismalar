using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class BookController : Controller
    {
        private IRepository repository;
        public BookController(IRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View(repository.Books);
        }
        public IActionResult Edit(int id)
        {
            
            return View(repository.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            repository.Update(book);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Creat()
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Creat(Book book)
        {
            repository.Create(book);
            return RedirectToAction(nameof(Index));
        }
        
        [HttpPost]
        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
