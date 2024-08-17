using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Domain.Book
{
    public class Books : BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
    }

}
