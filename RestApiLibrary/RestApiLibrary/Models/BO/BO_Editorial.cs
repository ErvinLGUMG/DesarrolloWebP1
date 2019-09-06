using RestApiLibrary.Models.DO;
using RestApiLibrary.Models.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApiLibrary.Models.BO
{
    public class BO_Editorial
    {
        private DbLibrary dbLibrary;
        private DO_Editorial doEditorial;

        public BO_Editorial(DbLibrary dbLibrary)
        {
            this.dbLibrary = dbLibrary;
            doEditorial = new DO_Editorial(this.dbLibrary);
        }

        public List<LibraryObject> GetAll()
        {
            try
            {
                return doEditorial.GetAll().Cast<LibraryObject>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<LibraryObject> GetCountryId(string countryId)
        {
            try
            {
                return doEditorial.GetCountryId(countryId).Cast<LibraryObject>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LibraryObject GetId(int editorialId)
        {
            try
            {
                return doEditorial.GetId(editorialId);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public LibraryObject Create(Editorial editorial)
        {
            try
            {
                return doEditorial.Create(editorial);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public LibraryObject Update(Editorial editorial)
        {
            try
            {
                return doEditorial.Update(editorial);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LibraryObject ChangeState(int editorialId, bool state)
        {
            try
            {
                return doEditorial.ChangeState(editorialId, state);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}