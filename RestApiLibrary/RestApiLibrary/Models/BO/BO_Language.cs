using RestApiLibrary.Models.DO;
using RestApiLibrary.Models.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApiLibrary.Models.BO
{
    public class BO_Language
    {
        private DbLibrary dbLibrary;
        private DO_Language doLanguage;

        public BO_Language(DbLibrary dbLibrary)
        {
            this.dbLibrary = dbLibrary;
            doLanguage = new DO_Language(this.dbLibrary);
        }

        public List<LibraryObject> GetAll()
        {
            try
            {
                return doLanguage.GetAll().Cast<LibraryObject>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        

        public LibraryObject GetId(int languageId)
        {
            try
            {
                return doLanguage.GetId(languageId);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public LibraryObject Create(Language language)
        {
            try
            {
                return doLanguage.Create(language);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public LibraryObject Update(Language language)
        {
            try
            {
                return doLanguage.Update(language);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LibraryObject ChangeState(int languageId, bool state)
        {
            try
            {
                return doLanguage.ChangeState(languageId, state);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}