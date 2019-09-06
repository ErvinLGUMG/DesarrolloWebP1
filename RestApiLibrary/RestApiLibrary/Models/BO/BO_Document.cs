using RestApiLibrary.Models.DO;
using RestApiLibrary.Models.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApiLibrary.Models.BO
{
    public class BO_Document
    {
        private DbLibrary dbLibrary;
        private DO_Document doDocument;

        public BO_Document(DbLibrary dbLibrary)
        {
            this.dbLibrary = dbLibrary;
            doDocument = new DO_Document(this.dbLibrary);
        }

        public List<LibraryObject> GetListAuthor()
        {
            try
            {
                return doDocument.GetListAuthor().Cast<LibraryObject>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<LibraryObject> GetListCategory()
        {
            try
            {
                return doDocument.GetListCategory().Cast<LibraryObject>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<LibraryObject> GetAll()
        {
            try
            {
                return doDocument.GetAll().Cast<LibraryObject>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<LibraryObject> GetAuthorId(int authorId)
        {
            try
            {
                return doDocument.GetAuthorId(authorId).Cast<LibraryObject>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<LibraryObject> GetCategoryId(int categoryId)
        {
            try
            {
                return doDocument.GetCategoryId(categoryId).Cast<LibraryObject>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<LibraryObject> GetEditorialId(int editorialId)
        {
            try
            {
                return doDocument.GetEditorialId(editorialId).Cast<LibraryObject>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        
        public LibraryObject GetId(int documentId)
        {
            try
            {
                return doDocument.GetId(documentId);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public LibraryObject Create(Document document)
        {
            try
            {
                return doDocument.Create(document);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public LibraryObject Update(Document document)
        {
            try
            {
                return doDocument.Update(document);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LibraryObject ChangeState(int documentId, bool state)
        {
            try
            {
                return doDocument.ChangeState(documentId, state);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}