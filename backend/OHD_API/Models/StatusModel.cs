using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OHD_API.Models
{
    [Table("Statuses")]
    public class StatusModel
    {
        [Key]
        [Column("StatusID")]
        public int StatusID { get; set; }
        public string StatusName { get; set; }
    }
}