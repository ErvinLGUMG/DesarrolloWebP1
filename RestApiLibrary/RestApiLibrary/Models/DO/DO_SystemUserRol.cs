using RestApiLibrary.Models.Objects;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;

namespace RestApiLibrary.Models.DO
{
    
    public class DO_SystemUserRol
    {
        private DbLibrary dbLibrary;
        private StringBuilder regOperacion;

        public DO_SystemUserRol(DbLibrary dbLibrary)
        {
            this.dbLibrary = dbLibrary;
        }
        /// <summary>
        /// Devuelve la lista de user roles
        /// </summary>
        /// <returns></returns>
        public List<SystemUserRol> GetAll()
        {
            try
            {
                List<SystemUserRol> list;

                list = dbLibrary.tc_SystemUserRol.ToList();

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Devuelve el userrol por userroleid indicado
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="rolId"></param>
        /// <returns></returns>
        public SystemUserRol GetId(string userId, string rolId)
        {
            try
            {
                SystemUserRol userRol;

                userRol = dbLibrary.tc_SystemUserRol.Where(a => a.UserId == userId && a.RolId == rolId).FirstOrDefault();

                return userRol;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Devuelve el los roles que tenga el usuario
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<SystemUserRol> GetUserId(string userId)
        {
            try
            {
                List<SystemUserRol> list;

                list = dbLibrary.tc_SystemUserRol.Where(a => a.UserId == userId).ToList();

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Devuelve los usuarios que tenga el role
        /// </summary>
        /// <param name="rolId"></param>
        /// <returns></returns>
        public List<SystemUserRol> GetrolId(string rolId)
        {
            try
            {
                List<SystemUserRol> list;

                list = dbLibrary.tc_SystemUserRol.Where(a => a.RolId == rolId).ToList();

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
        public Operations Create(SystemUserRol systemUserRol)
        {
            try
            {
                Operations operations = new Operations();

                try
                {
                    dbLibrary.tc_SystemUserRol.Add(systemUserRol);
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
        /// Actualiza el estado del userId role indicado
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public Operations ChangeState(string userId, string rolId, bool state)
        {
            try
            {
                Operations operations = new Operations();
                try
                {
                    SystemUserRol rol;
                    rol = dbLibrary.tc_SystemUserRol.Where(a => a.UserId == userId && a.RolId == rolId).FirstOrDefault();
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