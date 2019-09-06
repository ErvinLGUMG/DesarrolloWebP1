using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestApiLibrary.Models.Objects
{
    [Table("SystemRolePermission")]
    public class SystemRolePermission : LibraryObject
    {
    
        [Key, ForeignKey("SystemRol"), Column(Order = 1)]
        public string RolId { get; set; }
        public SystemRol SystemRol { get; set; }

        [Key, ForeignKey("SystemPermissions"), Column(Order = 2)]
        public string PermissionsId { get; set; }
        public SystemPermissions SystemPermissions { get; set; }

        public int State { get; set; } = 1;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        [StringLength(45)]
        public string CreatedUser { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.UtcNow;
        [StringLength(45)]
        public string ModifiedUser { get; set; }
    }
}