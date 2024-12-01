using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OHD_API.Models
{
    [Table("Assignments")]
    public class AssignmentModel
    {
        [Key]
        [Column("AssignementID")]
        public int AssignmentID { get; set; }
        public int RequestID { get; set; }
        public string AssigneeID { get; set; }
        public DateTime AssignedAt { get; set; }
        public DateTime CompletedAt { get; set; }
    }
}