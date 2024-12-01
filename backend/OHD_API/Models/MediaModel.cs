using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OHD_API.Models
{
    [Table("Media")]
    public class MediaModel
    {
        [Key]
        public int MediaID { get; set; }

        [ForeignKey("Request")]
        public int? RequestID { get; set; } // Nullable for initial creation without association

        [ForeignKey("MediaType")]
        public int MediaTypeID { get; set; }

        [Required]
        [MaxLength(255)]
        public string FilePath { get; set; }

        [Required]
        [MaxLength(50)]
        public string MediaSource { get; set; }

        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public virtual RequestModel Request { get; set; }
        public virtual MediaTypeModel MediaType { get; set; }
    }
}
