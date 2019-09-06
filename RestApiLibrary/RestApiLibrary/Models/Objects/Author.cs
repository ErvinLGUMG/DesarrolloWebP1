using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestApiLibrary.Models.Objects
{
    [Table("Author")]
    public class Author : LibraryObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorlId { get; set; }
        [StringLength(250, MinimumLength = 5)]
        public string Name { get; set; }
        [ForeignKey("Country")]
        public string CountryId { get; set; }
        public Country Country { get; set; }

        public int State { get; set; } = 1;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        [StringLength(45)]
        public string CreatedUser { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.UtcNow;
        [StringLength(45)]
        public string ModifiedUser { get; set; }

        //public ICollection<Document> DocumentsAuthor { get; set; }
    }
}