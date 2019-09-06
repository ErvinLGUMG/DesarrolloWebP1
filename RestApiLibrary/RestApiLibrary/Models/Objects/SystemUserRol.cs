using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestApiLibrary.Models.Objects
{
    [Table("SystemUserRol")]
    public class SystemUserRol : LibraryObject
    {
        
        [Key, ForeignKey("SystemUser"), Column(Order =1)]
        public string UserId { get; set; }
        public SystemUser SystemUser { get; set; }

        [Key, ForeignKey("SystemRol"), Column(Order = 2)]
        public string RolId { get; set; }
        public SystemRol SystemRol { get; set; }
        public int State { get; set; } = 1;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        [StringLength(45)]
        public string CreatedUser { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.UtcNow;
        [StringLength(45)]
        public string ModifiedUser { get; set; }
    }
}