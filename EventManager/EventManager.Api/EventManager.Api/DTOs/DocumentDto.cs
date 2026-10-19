namespace EventManager.Api.DTOs
{
    public class DocumentDto
    {
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty;
        public string FileSize { get; set; } = string.Empty;
        public string UploadDate { get; set; } = string.Empty;
        public string UploadedBy { get; set; } = string.Empty;
    }
}
