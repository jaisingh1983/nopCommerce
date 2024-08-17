using System;
using AutoMapper;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Extensions;
using Nop.Core.Domain;
using Nop.Services;
using Nop.Services.Book;
using Nop.Web.Models.Books;
using Nop.Core.Domain.Book;

namespace Nop.Web.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class BooksController : BasePublicController
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            var books = _bookService.GetAllBooks();
            var model = books.Select(b => b.ToModel(_mapper)).ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            var model = new BooksModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(BooksModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var book = _mapper.Map<BooksModel, Books>(model);
            book.CreatedOn = DateTime.UtcNow;
            _bookService.InsertBook(book);

            return RedirectToAction(nameof(List));
        }

        public IActionResult Edit(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
                return RedirectToAction(nameof(List));

            var model = book.ToModel(_mapper);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(BooksModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var book = _bookService.GetBookById(model.Id);
            if (book == null)
                return RedirectToAction(nameof(List));

            book = model.ToEntity(_mapper, book);
            _bookService.UpdateBook(book);

            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
                return RedirectToAction(nameof(List));

            _bookService.DeleteBook(book);
            return RedirectToAction(nameof(List));
        }
    }
}
