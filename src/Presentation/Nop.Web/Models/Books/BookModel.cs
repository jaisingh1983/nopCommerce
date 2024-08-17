using Nop.Web.Framework.Models;
using System;

namespace Nop.Web.Models.Books
{
    public class BooksModel : BaseNopEntityModel
    {
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
