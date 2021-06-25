using Lab23.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab23.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("Html5 & CSS3 the coplete manual-Author name book 1");
            books.Add("html5 & css3 the reponsive web design cookbook-Author name book 2 ");
            books.Add("profestional ASP.Net MVC -Author name book 3");
            ViewBag.Books = books;
            return View();
        }
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1,"Html5 & CSS3  the complete manual","Author name book 1","Content/image/01_cover.jfif"));
            books.Add(new Book(2, "Html5 & CSS Web design cook book", "Author name book 2", "Content/image/02.jpg"));
            books.Add(new Book(3, "Profestional ASP.NET MVC", "Author name book 3", "Content/image/03.jpg"));
            return View(books);

        }


        [HttpPost,ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id, string Title, string Author, string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Html5 & CSS3  the complete manual", "Author name book 1", "Content/image/01_cover.jfif"));
            books.Add(new Book(2, "Html5 & CSS Web design cook book", "Author name book 2", "Content/image/02.jpg"));
            books.Add(new Book(3, "Profestional ASP.NET MVC", "Author name book 3", "Content/image/03.jpg"));
            if (id == null)
            {
                return HttpNotFound();
            }
            foreach(Book b in books)
            {
                if(b.Id == id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.ImageCover = ImageCover;
                    break;
                }    
            }    
            
            return View("ListBookModel", books);

        }
        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost,ActionName("CreateBook")]
        [ValidateAntiForgeryToken]

        public ActionResult Contact([Bind(Include ="Id,Title,Author,ImageCover")]Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Html5 & CSS3  the complete manual", "Author name book 1", "Content/image/01_cover.jfif"));
            books.Add(new Book(2, "Html5 & CSS Web design cook book", "Author name book 2", "Content/image/02.jpg"));
            books.Add(new Book(3, "Profestional ASP.NET MVC", "Author name book 3", "Content/image/03.jpg"));
            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(book);
                }    
            }
            catch (RetrylimitExceededException)
            {
                ModelState.AddModelError("","Error Save Data");
            }
            return View("ListBookModel", books);
        }
    }
}