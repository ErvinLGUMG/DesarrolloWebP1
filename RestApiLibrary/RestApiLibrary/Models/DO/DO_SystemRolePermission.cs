using RestApiLibrary.Models.Objects;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;

namespace RestApiLibrary.Models.DO
{
    public class DO_SystemRolePermission
    {
        private DbLibrary dbLibrary;
        private StringBuilder regOperacion;

        public DO_SystemRolePermission(DbLibrary dbLibrary)
        {
            this.dbLibrary = dbLibrary;
        }

        /// <summary>
        /// Devuelve la lista de permisos roles
        /// </summary>
        /// <returns></returns>
        public List<SystemRolePermission> GetAll()
        {
            try
            {
                List<SystemRolePermission> list;

                list = dbLibrary.tc_SystemRolePermission.ToList();

                return list;
            }
            catch (Exception)
            {

                throw;

            }
        }
        /// <summary>
        /// Devuelve los permisos de un permiso y role
        /// </summary>
        /// <param name="permissionId"></param>
        /// <param name="rolId"></param>
        /// <returns></returns>
        public SystemRolePermission GetId(string permissionId, string rolId)
        {
            try
            {
                SystemRolePermission permissionRol;

                permissionRol = dbLibrary.tc_SystemRolePermission.Where(a => a.PermissionsId == permissionId 
                                && a.RolId == rolId).FirstOrDefault();

                return permissionRol;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Devuelve el los roles que tenga el permiso
        /// </summary>
        /// <param name="permissionId"></param>
        /// <returns></returns>
        public List<SystemRolePermission> GetPermissionId(string permissionId)
        {
            try
            {
                List<SystemRolePermission> list;

                list = dbLibrary.tc_SystemRolePermission.Where(a => a.PermissionsId == permissionId).ToList();

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Devuelve los permisos que tenga el role
        /// </summary>
        /// <param name="rolId"></param>
        /// <returns></returns>
        public List<SystemRolePermission> GetrolId(string rolId)
        {
            try
            {
                List<SystemRolePermission> list;

                list = dbLibrary.tc_SystemRolePermission.Where(a => a.RolId == rolId).ToList();

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Agrega un nuevo registro a la entidad de userroles
        /// </summary>
        /// <param name="SystemUserRol"></param>
        /// <returns></returns>
        public Operations Create(SystemRolePermission systemRolePermission)
        {
            try
            {
                Operations operations = new Operations();

                try
                {
                    dbLibrary.tc_SystemRolePermission.Add(systemRolePermission);
                    dbLibrary.SaveChanges();
                    operations.Result = "OK";
                    operations.Message = "Registro creado";
                }
                catch (DbEntityValidationException e)
                {
                    regOperacion = new StringBuilder("No se logro crear el registro:-");
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        regOperacion.AppendFormat("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            regOperacion.AppendFormat("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }

                    operations.Result = "Error";
                    operations.Message = regOperacion.ToString();
                }

                return operations;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Actualiza el estado del permissionId role indicado
        /// </summary>
        /// <param name="permissionId"></param>
        /// <param name="roleId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public Operations ChangeState(string permissionId, string rolId, bool state)
        {
            try
            {
                Operations operations = new Operations();
                try
                {
                    SystemRolePermission rol;
                    rol = dbLibrary.tc_SystemRolePermission.Where(a => a.PermissionsId == permissionId && a.RolId == rolId).FirstOrDefault();
                    rol.State = (state) ? 1 : 0;
                    dbLibrary.SaveChanges();
                    operations.Result = "OK";
                    operations.Message = "Estado Modificado";

                }
                catch (DbEntityValidationException e)
                {
                    regOperacion = new StringBuilder("No se logro actualizar el estado");
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        regOperacion.AppendFormat("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            regOperacion.AppendFormat("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }

                    operations.Result = "Error";
                    operations.Message = regOperacion.ToString();
                }

                return operations;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}