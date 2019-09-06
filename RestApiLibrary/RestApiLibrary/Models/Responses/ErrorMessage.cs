using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestApiLibrary.Models.Objects;

namespace RestApiLibrary.Models.Responses
{
    [Serializable]
    
    public class ErrorMessage :Message
    {
        Error error;
        public ErrorMessage(Error error)
        {
            this.error = error;
        }

        public ErrorMessage(string status, string title, string detail)
        {
            error = new Error();
            error.status = status;
            error.title = title;
            error.detail = detail;
        }

    }
}