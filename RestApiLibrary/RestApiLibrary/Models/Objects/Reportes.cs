using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApiLibrary.Models.Objects
{
    public class Reportes
    {
        public class BookAuthor : LibraryObject
        {
            public int AuthorId { get; set;  }
            public string AuthorName { get; set; }
            public List<Book> Books { get; set; }

        }

        public class BookCategory : LibraryObject
        {
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }    
            public List<Book> Books { get; set; }
        }

        public class Book
        {
            public int DocumentId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
        }
    }
}