using RestApiLibrary.Models.DO;
using RestApiLibrary.Models.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApiLibrary.Models.BO
{
    public class BO_SystemRolePermission
    {
        private DbLibrary dbLibrary;
        private DO_SystemRolePermission doSystemRolePermission;

        public BO_SystemRolePermission(DbLibrary dbLibrary)
        {
            this.dbLibrary = dbLibrary;
            doSystemRolePermission = new DO_SystemRolePermission(this.dbLibrary);
        }

        public List<LibraryObject> GetAll()
        {
            try
            {
                return doSystemRolePermission.GetAll().Cast<LibraryObject>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LibraryObject GetId(string permissionId, string roleId)
        {
            try
            {
                return doSystemRolePermission.GetId(permissionId, roleId);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<LibraryObject> GetPermissionId(string permissionId)
        {
            try
            {
                return doSystemRolePermission.GetPermissionId(permissionId).Cast<LibraryObject>().ToList();
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
                return doSystemRolePermission.GetrolId(rolId).Cast<LibraryObject>().ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public LibraryObject Create(SystemRolePermission systemRolePermission)
        {
            try
            {
                return doSystemRolePermission.Create(systemRolePermission);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public LibraryObject ChangeState(string permissionId, string rolId, bool state)
        {
            try
            {
                return doSystemRolePermission.ChangeState(permissionId, rolId, state);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}