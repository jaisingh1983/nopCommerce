using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nop.Core.Domain.Book;
using Nop.Data;

namespace Nop.Services.Book
{
    public partial class BookService : IBookService
    {
        private readonly IRepository<Books> _bookRepository;

        public BookService(IRepository<Books> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void InsertBook(Books book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            _bookRepository.Insert(book);
        }

        public void UpdateBook(Books book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            _bookRepository.Update(book);
        }

        public void DeleteBook(Books book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            _bookRepository.Delete(book);
        }

        public Books GetBookById(int bookId)
        {
            if (bookId == 0)
                return null;

            return _bookRepository.GetById(bookId);
        }

        public IList<Books> GetAllBooks(string name = null)
        {
            var query = _bookRepository.Table;

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(b => b.Name.Contains(name));

            return query.ToList();
        }

        
    }
}
