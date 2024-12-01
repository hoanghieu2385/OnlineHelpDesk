using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OHD_API.Models
{
    [Table("Requests")]
    public class RequestModel
    {
        [Key]
        [Column("RequestID")]
        public int RequestID { get; set; }
        public string UserID { get; set; }
        public int FacilityID { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}