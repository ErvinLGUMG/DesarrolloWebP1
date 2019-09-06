using RestApiLibrary.Models.Objects;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;

namespace RestApiLibrary.Models.DO
{
    
    public class DO_Country 
    {
        private DbLibrary dbLibrary;
        private StringBuilder regOperacion;

        public DO_Country(DbLibrary dbLibrary)
        {
            this.dbLibrary = dbLibrary;
        }
        /// <summary>
        /// Devuelve todos los registros
        /// </summary>
        /// <returns></returns>
        public List<Country> GetAll()
        {
            try
            {
                List<Country> list;

                list = dbLibrary.tc_Country.ToList();

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
        /// <param name="countryId"></param>
        /// <returns></returns>
        public Country GetId(string countryId)
        {
            try
            {
                Country row;

                row = dbLibrary.tc_Country.Where(a => a.CountryId == countryId).FirstOrDefault();

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
        public Operations Create(Country objnew)
        {
            try
            {
                Operations operations = new Operations();

                try
                {
                    dbLibrary.tc_Country.Add(objnew);
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
        public Operations Update(Country objUpd)
        {
            try
            {
                Operations operations = new Operations();

                try
                {
                    Country row;
                    row = dbLibrary.tc_Country.Where(a => a.CountryId == objUpd.CountryId).FirstOrDefault();
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
        /// <param name="countryId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public Operations ChangeState(string countryId, bool state)
        {
            try
            {
                Operations operations = new Operations();
                try
                {
                    Country row;
                    row = dbLibrary.tc_Country.Where(a => a.CountryId == countryId).FirstOrDefault();
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