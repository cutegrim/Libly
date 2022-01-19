using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Libly.Models;
using Libly.ViewModels;

namespace Libly.Controllers
{
    public class BooksController : Controller
    {

        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
           if(User.IsInRole(RoleName.CanManageBooks)) return View("Index");

           return View("ReadOnlyIndex");

        }

       public ActionResult Details(int id)
        {
            var book = _context.Books.Include(b => b.Genre).SingleOrDefault(b => b.Id == id);

            if (book == null) return HttpNotFound();

            return View(book);
        }
        [Authorize(Roles = RoleName.CanManageBooks)]
        public ViewResult NewBook()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new BookFormViewModel()
            {
                
                Genres = genres
            };


            return View("BookForm", viewModel);
        }
        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult Edit(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            var viewModel = new BookFormViewModel(book)
            {
                Genres = _context.Genres.ToList()
            };

            if (book == null) return HttpNotFound();
            return View("BookForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Book book)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BookFormViewModel(book)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("BookForm", viewModel);
            }
            if (book.Id == 0) _context.Books.Add(book);
            else
            {
                var bookInDb = _context.Books.Single(c => c.Id == book.Id);

                bookInDb.Name = book.Name;
                bookInDb.PublishDate = book.PublishDate;
                bookInDb.Author = book.Author;
                bookInDb.GenreId = book.GenreId;
                bookInDb.NumberInStock = book.NumberInStock;

            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Books");
        }
    }
}