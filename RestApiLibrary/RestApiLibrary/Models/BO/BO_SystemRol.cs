using RestApiLibrary.Models.DO;
using RestApiLibrary.Models.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApiLibrary.Models.BO
{
    public class BO_SystemRol
    {
        private DbLibrary dbLibrary;
        private DO_SystemRol doSystemRol;

        public BO_SystemRol(DbLibrary dbLibrary)
        {
            this.dbLibrary = dbLibrary;
            doSystemRol = new DO_SystemRol(this.dbLibrary);
        }

        public List<LibraryObject> GetAll()
        {
            try
            {
                return doSystemRol.GetAll().Cast<LibraryObject>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LibraryObject GetId(string roleId)
        {
            try
            {
                return doSystemRol.GetId(roleId);
            }
            catch (Exception)
            {

                throw;
            }

        }
        
        public LibraryObject Create(SystemRol systemRol)
        {
            try
            {
                return doSystemRol.Create(systemRol);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public LibraryObject Update(SystemRol systemRol)
        {
            try
            {
                return doSystemRol.Update(systemRol);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LibraryObject ChangeState(string roleId, bool state)
        {
            try
            {
                return doSystemRol.ChangeState(roleId, state);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}