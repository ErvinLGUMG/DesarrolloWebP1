using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using RestApiLibrary.Models;
using RestApiLibrary.Models.BO;
using RestApiLibrary.Models.Objects;
using RestApiLibrary.Models.Responses;

namespace RestApiLibrary.Controllers
{
    //[Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, OPTIONS")]
    [RoutePrefix("api/Security")]
    public class SecurityController : ApiController
    {

        // POST api/Security/LoginUser
        [Route("LoginUser")]
        public HttpResponseMessage PostLogin(User user)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_SystemUser boSystemUser = new BO_SystemUser(dbLibrary);
                DataMessage dataMessage = new DataMessage(boSystemUser.GetLogin(user.username, user.password));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del listado de usuarios: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }




        // GET api/Security/ListUsers
        [Route("ListUsers")]
        public HttpResponseMessage GetUsers()
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_SystemUser boSystemUser = new BO_SystemUser(dbLibrary);
                DataMessage dataMessage = new DataMessage(boSystemUser.GetAll());
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del listado de usuarios: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // GET api/Security/ListRoles
        [Route("ListRoles")]
        public HttpResponseMessage GetRoles()
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_SystemRol boSystemRol = new BO_SystemRol(dbLibrary);
                DataMessage dataMessage = new DataMessage(boSystemRol.GetAll());
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del listado de roles: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // GET api/Security/ListPermissions
        [Route("ListPermissions")]
        public HttpResponseMessage GetPermissions()
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_SystemPermissions boSystemPermissions = new BO_SystemPermissions(dbLibrary);
                DataMessage dataMessage = new DataMessage(boSystemPermissions.GetAll());
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del listado de permisos: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // GET api/Security/ListUserRoles
        [Route("ListUserRoles")]
        public HttpResponseMessage GetUserRoles()
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_SystemUserRol boSystemUserRol = new BO_SystemUserRol(dbLibrary);
                DataMessage dataMessage = new DataMessage(boSystemUserRol.GetAll());
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del listado de usuarios y roles: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // GET api/Security/ListRolePermission
        [Route("ListRolePermission")]
        public HttpResponseMessage GetRolePermission()
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_SystemRolePermission boSystemRolePermission = new BO_SystemRolePermission(dbLibrary);
                DataMessage dataMessage = new DataMessage(boSystemRolePermission.GetAll());
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del listado de permisos y roles: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }


        // GET api/Security/User
        [Route("User")]
        public HttpResponseMessage GetUser(string UserId)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_SystemUser boSystemUser = new BO_SystemUser(dbLibrary);
                DataMessage dataMessage = new DataMessage(boSystemUser.GetId(UserId));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del usuario: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // GET api/Security/Role
        [Route("Role")]
        public HttpResponseMessage GetRol(string RoleId)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_SystemRol boSystemRol = new BO_SystemRol(dbLibrary);
                DataMessage dataMessage = new DataMessage(boSystemRol.GetId(RoleId));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del rol: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // GET api/Security/Permissions
        [Route("Permissions")]
        public HttpResponseMessage GetPermissions(string PermissionsId)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_SystemPermissions boSystemPermissions = new BO_SystemPermissions(dbLibrary);
                DataMessage dataMessage = new DataMessage(boSystemPermissions.GetId(PermissionsId));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del Permissions: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // GET api/Security/UserRol
        [Route("UserRol")]
        public HttpResponseMessage GetUserRol(string UserId, string RoleId)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_SystemUserRol boSystemUserRol = new BO_SystemUserRol(dbLibrary);
                DataMessage dataMessage = new DataMessage(boSystemUserRol.GetId(UserId, RoleId));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del user role: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // GET api/Security/RolePermission
        [Route("RolePermission")]
        public HttpResponseMessage GetRolePermission(string PermissionId, string RoleId)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_SystemRolePermission boSystemRolePermission = new BO_SystemRolePermission(dbLibrary);
                DataMessage dataMessage = new DataMessage(boSystemRolePermission.GetId(PermissionId, RoleId));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del role permisision: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        

        // GET api/Security/UserRoles
        [Route("UserRoles")]
        public HttpResponseMessage GetUserRoles(string UserId)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_SystemUserRol boSystemUserRol = new BO_SystemUserRol(dbLibrary);
                DataMessage dataMessage = new DataMessage(boSystemUserRol.GetUserId(UserId));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del user role: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // GET api/Security/RolesUser
        [Route("RolesUser")]
        public HttpResponseMessage GetRolesUser(string RoleId)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_SystemUserRol boSystemUserRol = new BO_SystemUserRol(dbLibrary);
                DataMessage dataMessage = new DataMessage(boSystemUserRol.GetrolId(RoleId));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del roles users: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }


        // GET api/Security/RolesPermission
        [Route("RolesPermission")]
        public HttpResponseMessage GetRolesPermission(string PermissionId)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_SystemRolePermission boSystemRolePermission = new BO_SystemRolePermission(dbLibrary);
                DataMessage dataMessage = new DataMessage(boSystemRolePermission.GetPermissionId(PermissionId));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del permisos role: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // GET api/Security/PermissionRoles
        [Route("PermissionRoles")]
        public HttpResponseMessage GetPermissionRoles(string RoleId)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_SystemRolePermission boSystemRolePermission = new BO_SystemRolePermission(dbLibrary);
                DataMessage dataMessage = new DataMessage(boSystemRolePermission.GetrolId(RoleId));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del roles users: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // GET api/Security/ValidatorUser
        [Route("ValidatorUser")]
        public HttpResponseMessage GetValidator(string UserId, string Password)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_SystemUser boSystemUser = new BO_SystemUser(dbLibrary);
                DataMessage dataMessage = new DataMessage(boSystemUser.GetValidator(UserId, Password));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la obtención del usuario: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // POST api/Security/CreateUser
        [Route("CreateUser")]
        public HttpResponseMessage Post([FromBody] SystemUser systemUser)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_SystemUser boSystemUser = new BO_SystemUser(dbLibrary);
                DataMessage dataMessage = new DataMessage(boSystemUser.Create(systemUser));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la creación del usuario: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // POST api/Security/CreateRol
        [Route("CreateRol")]
        public HttpResponseMessage Post([FromBody] SystemRol systemRol)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_SystemRol boSystemRol = new BO_SystemRol(dbLibrary);
                DataMessage dataMessage = new DataMessage(boSystemRol.Create(systemRol));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la creación del rol: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // POST api/Security/CreatePermissions
        [Route("CreatePermissions")]
        public HttpResponseMessage Post([FromBody] SystemPermissions systemPermissions)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_SystemPermissions boSystemPermissions = new BO_SystemPermissions(dbLibrary);
                DataMessage dataMessage = new DataMessage(boSystemPermissions.Create(systemPermissions));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la creación del Permissions: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }


        // POST api/Security/CreateUserRol
        [Route("CreateUserRol")]
        public HttpResponseMessage Post([FromBody] SystemUserRol systemUserRol)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_SystemUserRol boSystemUserRol = new BO_SystemUserRol(dbLibrary);
                DataMessage dataMessage = new DataMessage(boSystemUserRol.Create(systemUserRol));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la creación del UserRol: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // POST api/Security/CreateRolePermission
        [Route("CreateRolePermission")]
        public HttpResponseMessage Post([FromBody] SystemRolePermission systemRolePermission)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_SystemRolePermission boSystemRolePermission = new BO_SystemRolePermission(dbLibrary);
                DataMessage dataMessage = new DataMessage(boSystemRolePermission.Create(systemRolePermission));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la creación del permiso role: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // PUT api/Security/UpdateUser
        [Route("UpdateUser")]
        public HttpResponseMessage Put([FromBody] SystemUser systemUser)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_SystemUser boSystemUser = new BO_SystemUser(dbLibrary);
                DataMessage dataMessage = new DataMessage(boSystemUser.Update(systemUser));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la actualización del usuario: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // PUT api/Security/UpdateRol
        [Route("UpdateRol")]
        public HttpResponseMessage Put([FromBody] SystemRol systemRol)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_SystemRol boSystemRol = new BO_SystemRol(dbLibrary);
                DataMessage dataMessage = new DataMessage(boSystemRol.Update(systemRol));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la actualización del rol: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // PUT api/Security/UpdatePermissions
        [Route("UpdatePermissions")]
        public HttpResponseMessage Put([FromBody] SystemPermissions systemPermissions)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_SystemPermissions boSystemPermissions = new BO_SystemPermissions(dbLibrary);
                DataMessage dataMessage = new DataMessage(boSystemPermissions.Update(systemPermissions));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en la actualización del Permissions: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }
        


        // PUT api/Security/ResetPassword
        [Route("ResetPassword")]
        public HttpResponseMessage PutReset([FromBody] SystemUser systemUser)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_SystemUser boSystemUser = new BO_SystemUser(dbLibrary);
                DataMessage dataMessage = new DataMessage(boSystemUser.ResetPassword(systemUser));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en el cambio de password del usuario: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // PUT api/Security/ChangeStateUser
        [Route("ChangeStateUser")]
        public HttpResponseMessage PutStateUser(string UserId, bool State)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_SystemUser boSystemUser = new BO_SystemUser(dbLibrary);
                DataMessage dataMessage = new DataMessage(boSystemUser.ChangeState(UserId, State));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en el cambio de estado del usuario: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // PUT api/Security/ChangeStateRol
        [Route("ChangeStateRol")]
        public HttpResponseMessage PutStateRol(string RoleId, bool State)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_SystemRol boSystemRol = new BO_SystemRol(dbLibrary);
                DataMessage dataMessage = new DataMessage(boSystemRol.ChangeState(RoleId, State));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en el cambio de estado del rol: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // PUT api/Security/ChangeStatePermissions
        [Route("ChangeStatePermissions")]
        public HttpResponseMessage PutStatePermissions(string PermissionsId, bool State)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_SystemPermissions boSystemPermissions = new BO_SystemPermissions(dbLibrary);
                DataMessage dataMessage = new DataMessage(boSystemPermissions.ChangeState(PermissionsId, State));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en el cambio de estado del Permissions: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // PUT api/Security/ChangeStateUserRol
        [Route("ChangeStateUserRol")]
        public HttpResponseMessage PutStateUserRol(string UserId, string RoleId, bool State)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_SystemUserRol boSystemUserRol = new BO_SystemUserRol(dbLibrary);
                DataMessage dataMessage = new DataMessage(boSystemUserRol.ChangeState(UserId, RoleId, State));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en el cambio de estado del user role: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

        // PUT api/Security/ChangeStateRolePermission
        [Route("ChangeStateRolePermission")]
        public HttpResponseMessage PutStateRolePermission(string PermissionId, string RoleId, bool State)
        {
            try
            {
                DbLibrary dbLibrary = new DbLibrary();
                BO_SystemRolePermission boSystemRolePermission = new BO_SystemRolePermission(dbLibrary);
                DataMessage dataMessage = new DataMessage(boSystemRolePermission.ChangeState(PermissionId, RoleId, State));
                return Request.CreateResponse(HttpStatusCode.OK, dataMessage);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Excepción en el cambio de estado del permiso role: " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.BadRequest, mensaje);
            }
        }

    }
}
