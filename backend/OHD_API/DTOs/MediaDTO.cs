namespace OHD_API.DTOs
{
    public class MediaDTO
    {
        public int MediaID { get; set; }
        public int MediaTypeID { get; set; }
        public string FilePath { get; set; }
        public string MediaSource { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
