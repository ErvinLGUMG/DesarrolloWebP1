using RestApiLibrary.Models.DO;
using RestApiLibrary.Models.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApiLibrary.Models.BO
{
    public class BO_SystemPermissions
    {
        private DbLibrary dbLibrary;
        private DO_SystemPermissions doSystemPermissions;

        public BO_SystemPermissions(DbLibrary dbLibrary)
        {
            this.dbLibrary = dbLibrary;
            doSystemPermissions = new DO_SystemPermissions(this.dbLibrary);
        }

        public List<LibraryObject> GetAll()
        {
            try
            {
                return doSystemPermissions.GetAll().Cast<LibraryObject>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LibraryObject GetId(string permissionsId)
        {
            try
            {
                return doSystemPermissions.GetId(permissionsId);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public LibraryObject Create(SystemPermissions systemPermissions)
        {
            try
            {
                return doSystemPermissions.Create(systemPermissions);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public LibraryObject Update(SystemPermissions systemPermissions)
        {
            try
            {
                return doSystemPermissions.Update(systemPermissions);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LibraryObject ChangeState(string permissionsId, bool state)
        {
            try
            {
                return doSystemPermissions.ChangeState(permissionsId, state);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}