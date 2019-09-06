using RestApiLibrary.Models;
using RestApiLibrary.Models.BO;
using RestApiLibrary.Models.Objects;
using RestApiLibrary.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RestApiLibrary.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, OPTIONS")]
    [RoutePrefix("api/Editorial")]
    public class EditorialController : ApiController
    {
        // GET api/Editorial/ListEditorial
        [Route("ListEditorial")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Editorial boEditorial = new BO_Editorial(dbLibrary);
                DataMessage dataMessage = new DataMessage(boEditorial.GetAll());
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del listado: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // GET api/Editorial/Editorial
        [Route("Editorial")]
        public HttpResponseMessage GetEditorial(int EditorialId)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Editorial boEditorial = new BO_Editorial(dbLibrary);
                DataMessage dataMessage = new DataMessage(boEditorial.GetId(EditorialId));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del Id: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // GET api/Editorial/Country
        [Route("Country")]
        public HttpResponseMessage GetCountryId(string CountryId)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Editorial boEditorial = new BO_Editorial(dbLibrary);
                DataMessage dataMessage = new DataMessage(boEditorial.GetCountryId(CountryId));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del Id: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // POST api/Editorial/Create
        [Route("Create")]
        public HttpResponseMessage Post([FromBody] Editorial editorial)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Editorial boEditorial = new BO_Editorial(dbLibrary);
                DataMessage dataMessage = new DataMessage(boEditorial.Create(editorial));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la creación del registro: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // PUT api/Editorial/Update
        [Route("Update")]
        public HttpResponseMessage Put([FromBody] Editorial editorial)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Editorial boEditorial = new BO_Editorial(dbLibrary);
                DataMessage dataMessage = new DataMessage(boEditorial.Update(editorial));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la actualización del registro: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // PUT api/Editorial/ChangeState
        [Route("ChangeState")]
        public HttpResponseMessage PutState(int EditorialId, bool State)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Editorial boEditorial = new BO_Editorial(dbLibrary);
                DataMessage dataMessage = new DataMessage(boEditorial.ChangeState(EditorialId, State));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en el cambio de estado del registro: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }
    }
}
