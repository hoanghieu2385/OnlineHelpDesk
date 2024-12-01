using Microsoft.AspNetCore.Mvc;
using OHD_API.Services;
using OHD_API.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OHD_API.Models
{
    [Table("MediaType")]    
    public class MediaModel
    {
        [Key]
        [Column("MediaTypeID")]
        public int MediaTypeID { get; set;}
        public string MediaTypeName { get; set;}
    }
}