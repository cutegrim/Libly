using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using AutoMapper;
using Libly.Dtos;
using Libly.Models;

namespace Libly.Controllers.Api
{
    public class BooksController : ApiController
    {
        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        //GET/api/books
        public IHttpActionResult GetBooks()
        {
            var bookDtos = _context.Books
                .Include(b => b.Genre)
                .ToList()
                .Select(Mapper.Map<Book, BookDto>);

            return Ok(bookDtos);
        }

        //GET/api/books/1

        public IHttpActionResult GetBook(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if (book == null) return NotFound();

            return Ok(Mapper.Map<Book, BookDto>(book));
        }

        //POST/api/books
        [HttpPost]
        public IHttpActionResult Createbook(BookDto bookDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var book = Mapper.Map<BookDto, Book>(bookDto);
            _context.Books.Add(book);
            _context.SaveChanges();

            bookDto.Id = book.Id;

            return Created(new Uri(Request.RequestUri + "/" + book.Id.ToString()), bookDto);

        }

        //PUT/api/books/1
        [HttpPut]
        public IHttpActionResult Updatebook(int id, BookDto bookDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var bookInDb = _context.Books.SingleOrDefault(b => b.Id == id);

            if (bookInDb == null) return NotFound();

            Mapper.Map(bookDto, bookInDb);

            _context.SaveChanges();

            return Ok();
        }

        //DELETE/api/books/1
        [HttpDelete]
        public IHttpActionResult Deletebook(int id)
        {
            var bookInDb = _context.Books.SingleOrDefault(b => b.Id == id);

            if (bookInDb == null) return NotFound();

            _context.Books.Remove(bookInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}