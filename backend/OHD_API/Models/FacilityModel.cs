using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OHD_API.Models
{
    [Table("Facilities")]
    public class FacilityModel
    {
        [Key]
        public int FacilityID { get; set; }

        [Required]
        [MaxLength(100)]
        public string FacilityName { get; set; }

        [MaxLength(255)]
        public string FacilityLocation { get; set; }

        [ForeignKey("FacilityHead")]
        public string Facility_head_ID { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
