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
    [RoutePrefix("api/Document")]
    public class DocumentController : ApiController
    {


        // GET api/Document/ListAuthor
        [Route("ListAuthor")]
        public HttpResponseMessage GetListAuthor()
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Document boDocument = new BO_Document(dbLibrary);
                DataMessage dataMessage = new DataMessage(boDocument.GetListAuthor());
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del listado: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // GET api/Document/ListCategory
        [Route("ListCategory")]
        public HttpResponseMessage GetListCategory()
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Document boDocument = new BO_Document(dbLibrary);
                DataMessage dataMessage = new DataMessage(boDocument.GetListCategory());
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del listado: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // GET api/Document/ListDocument
        [Route("ListDocument")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Document boDocument = new BO_Document(dbLibrary);
                DataMessage dataMessage = new DataMessage(boDocument.GetAll());
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del listado: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // GET api/Document/Document
        [Route("Document")]
        public HttpResponseMessage GetDocument(int DocumentId)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Document boDocument = new BO_Document(dbLibrary);
                DataMessage dataMessage = new DataMessage(boDocument.GetId(DocumentId));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del Id: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // GET api/Document/Author
        [Route("Author")]
        public HttpResponseMessage GetAuthorId(int AuthorId)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Document boDocument = new BO_Document(dbLibrary);
                DataMessage dataMessage = new DataMessage(boDocument.GetAuthorId(AuthorId));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del Id: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // GET api/Document/Category
        [Route("Category")]
        public HttpResponseMessage GetCategoryId(int CategoryId)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Document boDocument = new BO_Document(dbLibrary);
                DataMessage dataMessage = new DataMessage(boDocument.GetCategoryId(CategoryId));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del Id: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // GET api/Document/Editorial
        [Route("Editorial")]
        public HttpResponseMessage GetEditorialId(int EditorialId)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Document boDocument = new BO_Document(dbLibrary);
                DataMessage dataMessage = new DataMessage(boDocument.GetEditorialId(EditorialId));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del Id: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // POST api/Document/Create
        [Route("Create")]
        public HttpResponseMessage Post([FromBody] Document document)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Document boDocument = new BO_Document(dbLibrary);
                DataMessage dataMessage = new DataMessage(boDocument.Create(document));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la creación del registro: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // PUT api/Document/Update
        [Route("Update")]
        public HttpResponseMessage Put([FromBody] Document document)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Document boDocument = new BO_Document(dbLibrary);
                DataMessage dataMessage = new DataMessage(boDocument.Update(document));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la actualización del registro: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // PUT api/Document/ChangeState
        [Route("ChangeState")]
        public HttpResponseMessage PutState(int DocumentId, bool State)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_Document boDocument = new BO_Document(dbLibrary);
                DataMessage dataMessage = new DataMessage(boDocument.ChangeState(DocumentId, State));
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
