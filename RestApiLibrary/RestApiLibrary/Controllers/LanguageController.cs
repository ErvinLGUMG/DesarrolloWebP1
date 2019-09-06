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
    [RoutePrefix("api/Language")]
    public class LanguageController : ApiController
    {
        // GET api/Language/ListLanguage
        [Route("ListLanguage")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Language boLanguage = new BO_Language(dbLibrary);
                DataMessage dataMessage = new DataMessage(boLanguage.GetAll());
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del listado: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // GET api/Language/Language
        [Route("Language")]
        public HttpResponseMessage GetLanguage(int LanguageId)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Language boLanguage = new BO_Language(dbLibrary);
                DataMessage dataMessage = new DataMessage(boLanguage.GetId(LanguageId));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del Id: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // POST api/Language/Create
        [Route("Create")]
        public HttpResponseMessage Post([FromBody] Language language)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Language boLanguage = new BO_Language(dbLibrary);
                DataMessage dataMessage = new DataMessage(boLanguage.Create(language));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la creación del registro: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // PUT api/Language/Update
        [Route("Update")]
        public HttpResponseMessage Put([FromBody] Language language)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Language boLanguage = new BO_Language(dbLibrary);
                DataMessage dataMessage = new DataMessage(boLanguage.Update(language));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la actualización del registro: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // PUT api/Language/ChangeState
        [Route("ChangeState")]
        public HttpResponseMessage PutState(int LanguageId, bool State)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Language boLanguage = new BO_Language(dbLibrary);
                DataMessage dataMessage = new DataMessage(boLanguage.ChangeState(LanguageId, State));
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
