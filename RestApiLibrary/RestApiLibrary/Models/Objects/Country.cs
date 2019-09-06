using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestApiLibrary.Models.Objects
{
    [Table("Country")]
    public class Country : LibraryObject
    {
     
        [Key, StringLength(5)]
        public string CountryId { get; set; }
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }
        public int State { get; set; } = 1;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        [StringLength(45)]
        public string CreatedUser { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.UtcNow;
        [StringLength(45)]
        public string ModifiedUser { get; set; }

        //public ICollection<Editorial> Editorials { get; set; }
        //public ICollection<Author> Authors { get; set; }

    }
}