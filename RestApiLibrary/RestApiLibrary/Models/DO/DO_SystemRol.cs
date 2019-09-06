using RestApiLibrary.Models.Objects;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;

namespace RestApiLibrary.Models.DO
{
    public class DO_SystemRol 
    {
        private DbLibrary dbLibrary;
        private StringBuilder regOperacion;

        public DO_SystemRol(DbLibrary dbLibrary)
        {
            this.dbLibrary = dbLibrary;
        }

        /// <summary>
        /// Devuelve la lista de roles
        /// </summary>
        /// <returns></returns>
        public List<SystemRol> GetAll()
        {
            try
            {
                List<SystemRol> list;

                list = dbLibrary.tc_SystemRol.ToList();

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Devuelve el rol por roleid indicado
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public SystemRol GetId(string roleId)
        {
            try
            {
                SystemRol rol;

                rol = dbLibrary.tc_SystemRol.Where(a => a.RoleId == roleId).FirstOrDefault();

                return rol;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Agrega un nuevo registro a la entidad de roles
        /// </summary>
        /// <param name="systemRol"></param>
        /// <returns></returns>
        public Operations Create(SystemRol systemRol)
        {
            try
            {
                Operations operations = new Operations();

                try
                {
                    dbLibrary.tc_SystemRol.Add(systemRol);
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
        /// Actualiza el registro del rol indicado
        /// </summary>
        /// <param name="systemRol"></param>
        /// <returns></returns>
        public Operations Update(SystemRol systemRol)
        {
            try
            {
                Operations operations = new Operations();

                try
                {
                    SystemRol rol;
                    rol = dbLibrary.tc_SystemRol.Where(a => a.RoleId == systemRol.RoleId).FirstOrDefault();
                    rol.Name = systemRol.Name;
                    dbLibrary.SaveChanges();
                    operations.Result = "OK";
                    operations.Message = "Rol actualizado";

                }
                catch (DbEntityValidationException e)
                {
                    regOperacion = new StringBuilder("No se logro actualizar el rol");
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
        /// Actualiza el estado del role indicado
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public Operations ChangeState(string roleId, bool state)
        {
            try
            {
                Operations operations = new Operations();
                try
                {
                    SystemRol rol;
                    rol = dbLibrary.tc_SystemRol.Where(a => a.RoleId == roleId).FirstOrDefault();
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