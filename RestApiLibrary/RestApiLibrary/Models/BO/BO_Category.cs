using RestApiLibrary.Models.DO;
using RestApiLibrary.Models.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApiLibrary.Models.BO
{
    public class BO_Category
    {
        private DbLibrary dbLibrary;
        private DO_Category doCategory;

        public BO_Category(DbLibrary dbLibrary)
        {
            this.dbLibrary = dbLibrary;
            doCategory = new DO_Category(this.dbLibrary);
        }

        public List<LibraryObject> GetAll()
        {
            try
            {
                return doCategory.GetAll().Cast<LibraryObject>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LibraryObject GetId(int categoryId)
        {
            try
            {
                return doCategory.GetId(categoryId);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public LibraryObject Create(Category category)
        {
            try
            {
                return doCategory.Create(category);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public LibraryObject Update(Category category)
        {
            try
            {
                return doCategory.Update(category);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LibraryObject ChangeState(int categoryId, bool state)
        {
            try
            {
                return doCategory.ChangeState(categoryId, state);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}