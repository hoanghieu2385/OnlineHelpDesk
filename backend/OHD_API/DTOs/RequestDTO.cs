namespace OHD_API.DTOs
{
    public class RequestDTO
    {
        public int RequestID { get; set; }
        public string UserID { get; set; }
        public int FacilityID { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<MediaDTO> Media { get; set; }
    }

}
