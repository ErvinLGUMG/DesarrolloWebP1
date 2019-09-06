using RestApiLibrary.Models.DO;
using RestApiLibrary.Models.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApiLibrary.Models.BO
{
    public class BO_Country
    {
        private DbLibrary dbLibrary;
        private DO_Country doCountry;

        public BO_Country(DbLibrary dbLibrary)
        {
            this.dbLibrary = dbLibrary;
            doCountry = new DO_Country(this.dbLibrary);
        }

        public List<LibraryObject> GetAll()
        {
            try
            {
                return doCountry.GetAll().Cast<LibraryObject>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LibraryObject GetId(string countryId)
        {
            try
            {
                return doCountry.GetId(countryId);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public LibraryObject Create(Country country)
        {
            try
            {
                return doCountry.Create(country);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public LibraryObject Update(Country country)
        {
            try
            {
                return doCountry.Update(country);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LibraryObject ChangeState(string countryId, bool state)
        {
            try
            {
                return doCountry.ChangeState(countryId, state);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}