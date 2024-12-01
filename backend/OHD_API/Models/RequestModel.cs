using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OHD_API.Models
{
    [Table("Requests")]
    public class RequestModel
    {
        [Key]
        public int RequestID { get; set; }

        [ForeignKey("User")]
        public string UserID { get; set; }

        [ForeignKey("Facility")]
        public int FacilityID { get; set; }

        [Required]
        public string Description { get; set; }

        [MaxLength(255)]
        public string Location { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public virtual ICollection<MediaModel> Media { get; set; } = new List<MediaModel>();
        public virtual FacilityModel Facility { get; set; }
        public virtual User User { get; set; }
    }
}
