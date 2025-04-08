using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SongVersionPdf
    {
        [Key]
        public int PdfId { get; set; }
        public required int VersionId { get; set; }
        public SongVersion Version { get; set; } = null!;
        public required int UploadedBy { get; set; }
        public Profile Uploader { get; set; } = null!;
        public string FilePath { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
