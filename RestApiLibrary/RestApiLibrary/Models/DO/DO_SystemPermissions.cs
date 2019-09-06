using RestApiLibrary.Models.Objects;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;

namespace RestApiLibrary.Models.DO
{
    public class DO_SystemPermissions 
    {
        private DbLibrary dbLibrary;
        private StringBuilder regOperacion;

        public DO_SystemPermissions(DbLibrary dbLibrary)
        {
            this.dbLibrary = dbLibrary;
        }

        /// <summary>
        /// Devuelve la lista de permisos
        /// </summary>
        /// <returns></returns>
        public List<SystemPermissions> GetAll()
        {
            try
            {
                List<SystemPermissions> list;

                list = dbLibrary.tc_SystemPermissions.ToList();

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Devuelve el permiso por permissionId indicado
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public SystemPermissions GetId(string permissionsId)
        {
            try
            {
                SystemPermissions permissions;

                permissions = dbLibrary.tc_SystemPermissions.Where(a => a.PermissionsId == permissionsId).FirstOrDefault();

                return permissions;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Agrega un nuevo registro a la entidad de permissions
        /// </summary>
        /// <param name="systemPermissions"></param>
        /// <returns></returns>
        public Operations Create(SystemPermissions systemPermissions)
        {
            try
            {
                Operations operations = new Operations();

                try
                {
                    dbLibrary.tc_SystemPermissions.Add(systemPermissions);
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
        /// Actualiza el registro del permissions indicado
        /// </summary>
        /// <param name="SystemPermissions"></param>
        /// <returns></returns>
        public Operations Update(SystemPermissions systemPermissions)
        {
            try
            {
                Operations operations = new Operations();

                try
                {
                    SystemPermissions permissions;
                    permissions = dbLibrary.tc_SystemPermissions.Where(a => a.PermissionsId == systemPermissions.PermissionsId).FirstOrDefault();
                    permissions.Name = systemPermissions.Name;
                    dbLibrary.SaveChanges();
                    operations.Result = "OK";
                    operations.Message = "Permiso actualizado";

                }
                catch (DbEntityValidationException e)
                {
                    regOperacion = new StringBuilder("No se logro actualizar el permiso");
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
        /// <summary>
        /// Actualiza el estado del permissions indicado
        /// </summary>
        /// <param name="permissionsId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public Operations ChangeState(string permissionsId, bool state)
        {
            try
            {
                Operations operations = new Operations();
                try
                {
                    SystemPermissions permissions;
                    permissions = dbLibrary.tc_SystemPermissions.Where(a => a.PermissionsId == permissionsId).FirstOrDefault();
                    permissions.State = (state) ? 1 : 0;
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