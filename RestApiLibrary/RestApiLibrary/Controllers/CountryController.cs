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
    [RoutePrefix("api/Country")]
    public class CountryController : ApiController
    {
        // GET api/Country/ListCountry
        [Route("ListCountry")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Country boCountry = new BO_Country(dbLibrary);
                DataMessage dataMessage = new DataMessage(boCountry.GetAll());
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del listado: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // GET api/Country/Country
        [Route("Country")]
        public HttpResponseMessage GetCountry(string CountryId)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Country boCountry = new BO_Country(dbLibrary);
                DataMessage dataMessage = new DataMessage(boCountry.GetId(CountryId));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del Id: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // POST api/Country/Create
        [Route("Create")]
        public HttpResponseMessage Post([FromBody] Country country)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Country boCountry = new BO_Country(dbLibrary);
                DataMessage dataMessage = new DataMessage(boCountry.Create(country));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la creación del registro: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // PUT api/Country/Update
        [Route("Update")]
        public HttpResponseMessage Put([FromBody] Country country)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Country boCountry = new BO_Country(dbLibrary);
                DataMessage dataMessage = new DataMessage(boCountry.Update(country));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la actualización del registro: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // PUT api/Country/ChangeState
        [Route("ChangeState")]
        public HttpResponseMessage PutState(string CountryId, bool State)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Country boCountry = new BO_Country(dbLibrary);
                DataMessage dataMessage = new DataMessage(boCountry.ChangeState(CountryId, State));
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
