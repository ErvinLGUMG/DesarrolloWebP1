using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestApiLibrary.Models.Objects
{
    [Table("SystemRol")]
    public class SystemRol : LibraryObject
    {
        [Key, StringLength(45)]
        public string RoleId { get; set; }
        [StringLength(250, MinimumLength = 5)]
        public string Name { get; set; }
        public int State { get; set; } = 1;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        [StringLength(45)]
        public string CreatedUser { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.UtcNow;
        [StringLength(45)]
        public string ModifiedUser { get; set; }

        //public ICollection<SystemUserRol> SystemUserRoles { get; set; }
        //public ICollection<SystemRolePermission> SystemRolesPermission { get; set; }
    }
}
