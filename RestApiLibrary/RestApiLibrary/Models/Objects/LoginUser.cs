using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApiLibrary.Models.Objects
{
    public class LoginUser : LibraryObject
    {
        public bool Estado { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string RoleId { get; set; }
        public List<SystemRolePermission> Permisision { get; set; }
    }
}