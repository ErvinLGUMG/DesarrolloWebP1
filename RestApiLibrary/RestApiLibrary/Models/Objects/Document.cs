using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestApiLibrary.Models.Objects
{
    [Table("Document")]
    public class Document : LibraryObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DocumentId { get; set; }
        [StringLength(250, MinimumLength = 5)]
        public string Title { get; set; }
        [StringLength(500, MinimumLength = 5)]
        public string Description { get; set; }
        [StringLength(250, MinimumLength = 5)]
        public string ImagenPath { get; set; }
        [StringLength(250, MinimumLength = 5)]
        public string PdfPath { get; set; }
        public int Private { get; set; }

        [ForeignKey("SystemUser"), Column("OwnerId")]   
        public string UserId { get; set; }
        public SystemUser SystemUser { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        [ForeignKey("Editorial")]
        public int EditorialId { get; set; }
        public Editorial Editorial { get; set; }

        public DateTime PublicationDate { get; set; } = DateTime.UtcNow;

        public int State { get; set; } = 1;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        [StringLength(45)]
        public string CreatedUser { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.UtcNow;
        [StringLength(45)]
        public string ModifiedUser { get; set; }
    }
}