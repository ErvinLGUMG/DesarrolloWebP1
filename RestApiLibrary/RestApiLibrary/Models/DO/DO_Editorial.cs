using RestApiLibrary.Models.Objects;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;

namespace RestApiLibrary.Models.DO
{
    public class DO_Editorial
    {
        private DbLibrary dbLibrary;
        private StringBuilder regOperacion;

        public DO_Editorial(DbLibrary dbLibrary)
        {
            this.dbLibrary = dbLibrary;
        }
        /// <summary>
        /// Devuelve todos los registros
        /// </summary>
        /// <returns></returns>
        public List<Editorial> GetAll()
        {
            try
            {
                List<Editorial> list;

                list = dbLibrary.tc_Editorial.ToList();

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Devuelve todos los registros por CountryId
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        public List<Editorial> GetCountryId(string countryId)
        {
            try
            {
                List<Editorial> list;

                list = dbLibrary.tc_Editorial.Where(a=> a.CountryId == countryId).ToList();

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Devuelve un registro por Id
        /// </summary>
        /// <param name="editorialId"></param>
        /// <returns></returns>
        public Editorial GetId(int editorialId)
        {
            try
            {
                Editorial row;

                row = dbLibrary.tc_Editorial.Where(a => a.EditorialId == editorialId).FirstOrDefault();

                return row;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Metodo para crear registro
        /// </summary>
        /// <param name="objnew"></param>
        /// <returns></returns>
        public Operations Create(Editorial objnew)
        {
            try
            {
                Operations operations = new Operations();

                try
                {
                    dbLibrary.tc_Editorial.Add(objnew);
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
        /// Metodo para actualizar registro
        /// </summary>
        /// <param name="objUpd"></param>
        /// <returns></returns>
        public Operations Update(Editorial objUpd)
        {
            try
            {
                Operations operations = new Operations();

                try
                {
                    Editorial row;
                    row = dbLibrary.tc_Editorial.Where(a => a.EditorialId == objUpd.EditorialId).FirstOrDefault();
                    row.Name = objUpd.Name;
                    dbLibrary.SaveChanges();
                    operations.Result = "OK";
                    operations.Message = "Registro actualizado";

                }
                catch (DbEntityValidationException e)
                {
                    regOperacion = new StringBuilder("No se logro actualizar el registro");
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
        /// Actualiza el estado del registro
        /// </summary>
        /// <param name="editorialId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public Operations ChangeState(int editorialId, bool state)
        {
            try
            {
                Operations operations = new Operations();
                try
                {
                    Editorial row;
                    row = dbLibrary.tc_Editorial.Where(a => a.EditorialId == editorialId).FirstOrDefault();
                    row.State = (state) ? 1 : 0;
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