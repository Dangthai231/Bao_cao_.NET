using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.UI.Models
{
    public class DocumentDto
    {
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty;
        public string FileSize { get; set; } = string.Empty;
        public string UploadDate { get; set; } = string.Empty;
        public string UploadedBy { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty; // Đường dẫn lưu file vật lý trên máy chủ
    }
}
