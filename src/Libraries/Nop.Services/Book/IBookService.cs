using System;
using System.Collections.Generic;
using System.Text;
using Nop.Core.Domain.Book;
using Nop.Services.Plugins;


namespace Nop.Services.Book
{
    public partial interface IBookService
    {
        void InsertBook(Books book);
        void UpdateBook(Books book);
        void DeleteBook(Books book);
        Books GetBookById(int bookId);
        IList<Books> GetAllBooks(string name = null);
    }
}
