using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApiLibrary.Models.Responses
{
    public class ResponseToken
    {
        public string status { get; set; }
        public string message { get; set; }
        public string token { get; set; }
    }
}