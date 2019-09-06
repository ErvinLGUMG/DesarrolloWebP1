using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;
using RestApiLibrary.Models.Objects;

namespace RestApiLibrary.Models.DO
{
    public class DO_SystemUser
    {
        private DbLibrary dbLibrary;
        private StringBuilder regOperacion;

        public DO_SystemUser(DbLibrary dbLibrary)
        {
            this.dbLibrary = dbLibrary;
        }


        public LoginUser GetLogin(string userId, string password)
        {
            try
            {
                LoginUser loginUser = new LoginUser();
                
                SystemUser user = dbLibrary.tc_SystemUser.Where(a => a.UserId == userId && a.Password == password).FirstOrDefault();
                if (user == null)
                {
                    loginUser.Estado = false;
                    return loginUser;
                }
                loginUser.UserName = user.Name;
                loginUser.Estado = true;
                loginUser.UserId = user.UserId;
                loginUser.RoleId = dbLibrary.tc_SystemUserRol.Where(a => a.UserId == user.UserId).Select(a=> a.RolId).FirstOrDefault();
                loginUser.Permisision = dbLibrary.tc_SystemRolePermission.Where(a => a.RolId == loginUser.RoleId).ToList();

                return loginUser;

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Devuelve la lista de usuarios
        /// </summary>
        /// <returns></returns>
        public List<SystemUser> GetAll()
        {
            try
            {
                List<SystemUser> list;

                list = dbLibrary.tc_SystemUser.ToList();

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Devuelve un usuario por el userid indicado
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public SystemUser GetId(string userId)
        {
            try
            {
                SystemUser user;

                user = dbLibrary.tc_SystemUser.Where(a=> a.UserId == userId).FirstOrDefault();

                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Valida si el userid y password son correctos
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public SystemUser GetValidator(string userId, string password)
        {
            try
            {
                SystemUser user;

                user = dbLibrary.tc_SystemUser.Where(a => a.UserId == userId && a.Password == password).FirstOrDefault();


                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Metodo para creación de usuarios
        /// </summary>
        /// <param name="systemUser"></param>
        /// <returns></returns>
        public Operations Create(SystemUser systemUser)
        {
            try
            {
                Operations operations = new Operations();
                
                try
                {
                    dbLibrary.tc_SystemUser.Add(systemUser);
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
        /// Metodo para actualizacion de campos del usuario
        /// </summary>
        /// <param name="systemUser"></param>
        /// <returns></returns>
        public Operations Update(SystemUser systemUser)
        {
            try
            {
                Operations operations = new Operations();
                
                try
                {
                    SystemUser user;
                    user = dbLibrary.tc_SystemUser.Where(a => a.UserId == systemUser.UserId).FirstOrDefault();
                    user.Name = systemUser.Name;
                    user.Telephone = systemUser.Telephone;
                    user.Email = systemUser.Email;
                    dbLibrary.SaveChanges();
                    operations.Result = "OK";
                    operations.Message = "Usuario actualizado" ;

                }
                catch (DbEntityValidationException e)
                {
                    regOperacion = new StringBuilder("No se logro actualizar el usuario");
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
        /// Resetea password del usuario
        /// </summary>
        /// <param name="systemUser"></param>
        /// <returns></returns>
        public Operations ResetPassword(SystemUser systemUser)
        {
            try
            {
                Operations operations = new Operations();
                try
                {
                    SystemUser user;
                    user = dbLibrary.tc_SystemUser.Where(a => a.UserId == systemUser.UserId).FirstOrDefault();
                    user.Password = systemUser.Password;
                    dbLibrary.SaveChanges();
                    operations.Result = "OK";
                    operations.Message = "Password Modificado";

                }
                catch (DbEntityValidationException e)
                {
                    regOperacion = new StringBuilder("No se logro modificar el password");
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
        /// Modifica el estado del un registro
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public Operations ChangeState(string userId, bool state)
        {
            try
            {
                Operations operations = new Operations();
                try
                {
                    SystemUser user;
                    user = dbLibrary.tc_SystemUser.Where(a => a.UserId == userId).FirstOrDefault();
                    user.State = (state) ? 1 : 0;
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