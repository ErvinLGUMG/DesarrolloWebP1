using RestApiLibrary.Models.DO;
using RestApiLibrary.Models.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApiLibrary.Models.BO
{
    public class BO_SystemUserRol
    {
        private DbLibrary dbLibrary;
        private DO_SystemUserRol doSystemUserRol;

        public BO_SystemUserRol(DbLibrary dbLibrary)
        {
            this.dbLibrary = dbLibrary;
            doSystemUserRol = new DO_SystemUserRol(this.dbLibrary);
        }

        public List<LibraryObject> GetAll()
        {
            try
            {
                return doSystemUserRol.GetAll().Cast<LibraryObject>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LibraryObject GetId(string userId, string roleId)
        {
            try
            {
                return doSystemUserRol.GetId(userId, roleId);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<LibraryObject> GetUserId(string userId)
        {
            try
            {
                return doSystemUserRol.GetUserId(userId).Cast<LibraryObject>().ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<LibraryObject> GetrolId(string rolId)
        {
            try
            {
                return doSystemUserRol.GetrolId(rolId).Cast<LibraryObject>().ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public LibraryObject Create(SystemUserRol systemUserRol)
        {
            try
            {
                return doSystemUserRol.Create(systemUserRol);
            }
            catch (Exception)
            {

                throw;
            }
        }
        

        public LibraryObject ChangeState(string userId, string rolId, bool state)
        {
            try
            {
                return doSystemUserRol.ChangeState(userId, rolId, state);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}