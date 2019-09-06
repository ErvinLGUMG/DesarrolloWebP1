using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestApiLibrary.Models.Objects;

namespace RestApiLibrary.Models.Responses
{
    [Serializable]
    public class DataMessage :Message
    {
        List<LibraryObject> data;
        public DataMessage(List<LibraryObject> data)
        {
            this.data = data;
        }

        public DataMessage(LibraryObject row)
        {
            data = new List<LibraryObject>();
            data.Add(row);
        }
            
    }
}