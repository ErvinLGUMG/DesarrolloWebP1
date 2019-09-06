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
    [RoutePrefix("api/Category")]
    public class CategoryController : ApiController
    {
        // GET api/Category/ListCategory
        [Route("ListCategory")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Category boCategory = new BO_Category(dbLibrary);
                DataMessage dataMessage = new DataMessage(boCategory.GetAll());
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del listado: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // GET api/Category/Category
        [Route("Category")]
        public HttpResponseMessage GetCategory(int CategoryId)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Category boCategory = new BO_Category(dbLibrary);
                DataMessage dataMessage = new DataMessage(boCategory.GetId(CategoryId));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del Id: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // POST api/Category/Create
        [Route("Create")]
        public HttpResponseMessage Post([FromBody] Category category)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Category boCategory = new BO_Category(dbLibrary);
                DataMessage dataMessage = new DataMessage(boCategory.Create(category));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la creación del registro: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // PUT api/Category/Update
        [Route("Update")]
        public HttpResponseMessage Put([FromBody] Category category)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Category boCategory = new BO_Category(dbLibrary);
                DataMessage dataMessage = new DataMessage(boCategory.Update(category));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la actualización del registro: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // PUT api/Category/ChangeState
        [Route("ChangeState")]
        public HttpResponseMessage PutState(int CategoryId, bool State)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Category boCategory = new BO_Category(dbLibrary);
                DataMessage dataMessage = new DataMessage(boCategory.ChangeState(CategoryId, State));
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
