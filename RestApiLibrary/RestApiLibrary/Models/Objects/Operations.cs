using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApiLibrary.Models.Objects
{
    public class Operations : LibraryObject
    {
        public string Result { get; set; }
        public string Message { get; set; }
    }
}