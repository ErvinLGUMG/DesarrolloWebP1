using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestApiLibrary.Models.DO;
using RestApiLibrary.Models.Objects;

namespace RestApiLibrary.Models.BO
{
    public class BO_SystemUser
    {
        private DbLibrary dbLibrary;
        private DO_SystemUser doSystemUser;

        public BO_SystemUser(DbLibrary dbLibrary)
        {
            this.dbLibrary = dbLibrary;
            doSystemUser = new DO_SystemUser(this.dbLibrary);
        }

        public LibraryObject GetLogin(string userId, string password)
        {
            try
            {
                return doSystemUser.GetLogin(userId, password);
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
                return doSystemUser.GetAll().Cast<LibraryObject>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LibraryObject GetId(string userId)
        {
            try
            {
                return doSystemUser.GetId(userId);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public LibraryObject GetValidator(string userId, string password)
        {
            try
            {
                return doSystemUser.GetValidator(userId, password);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public LibraryObject Create(SystemUser systemUser)
        {
            try
            {
                return doSystemUser.Create(systemUser);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public LibraryObject Update(SystemUser systemUser)
        {
            try
            {
                return doSystemUser.Update(systemUser);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LibraryObject ResetPassword(SystemUser systemUser)
        {
            try
            {
                return doSystemUser.ResetPassword(systemUser);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public LibraryObject ChangeState(string userId, bool state)
        {
            try
            {
                return doSystemUser.ChangeState(userId, state);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}