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
    [RoutePrefix("api/Author")]
    public class AuthorController : ApiController
    {
        // GET api/Author/ListAuthor
        [Route("ListAuthor")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Author boAuthor = new BO_Author(dbLibrary);
                DataMessage dataMessage = new DataMessage(boAuthor.GetAll());
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del listado: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // GET api/Author/Author
        [Route("Author")]
        public HttpResponseMessage GetAuthor(int AuthorId)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Author boAuthor = new BO_Author(dbLibrary);
                DataMessage dataMessage = new DataMessage(boAuthor.GetId(AuthorId));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del Id: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // GET api/Author/Country
        [Route("Country")]
        public HttpResponseMessage GetCountryId(string CountryId)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Author boAuthor = new BO_Author(dbLibrary);
                DataMessage dataMessage = new DataMessage(boAuthor.GetCountryId(CountryId));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del Id: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // POST api/Author/Create
        [Route("Create")]
        public HttpResponseMessage Post([FromBody] Author author)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Author boAuthor = new BO_Author(dbLibrary);
                DataMessage dataMessage = new DataMessage(boAuthor.Create(author));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la creación del registro: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // PUT api/Author/Update
        [Route("Update")]
        public HttpResponseMessage Put([FromBody] Author author)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Author boAuthor = new BO_Author(dbLibrary);
                DataMessage dataMessage = new DataMessage(boAuthor.Update(author));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la actualización del registro: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // PUT api/Author/ChangeState
        [Route("ChangeState")]
        public HttpResponseMessage PutState(int AuthorId, bool State)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Author boAuthor = new BO_Author(dbLibrary);
                DataMessage dataMessage = new DataMessage(boAuthor.ChangeState(AuthorId, State));
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
