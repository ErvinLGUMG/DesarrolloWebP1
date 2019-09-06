using RestApiLibrary.Models.DO;
using RestApiLibrary.Models.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApiLibrary.Models.BO
{
    public class BO_Author
    {
        private DbLibrary dbLibrary;
        private DO_Author doAuthor;

        public BO_Author(DbLibrary dbLibrary)
        {
            this.dbLibrary = dbLibrary;
            doAuthor = new DO_Author(this.dbLibrary);
        }

        public List<LibraryObject> GetAll()
        {
            try
            {
                return doAuthor.GetAll().Cast<LibraryObject>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<LibraryObject>  GetCountryId(string countryId)
        {
            try
            {
                return doAuthor.GetCountryId(countryId).Cast<LibraryObject>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public LibraryObject GetId(int authorId)
        {
            try
            {
                return doAuthor.GetId(authorId);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public LibraryObject Create(Author author)
        {
            try
            {
                return doAuthor.Create(author);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public LibraryObject Update(Author author)
        {
            try
            {
                return doAuthor.Update(author);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LibraryObject ChangeState(int authorId, bool state)
        {
            try
            {
                return doAuthor.ChangeState(authorId, state);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}