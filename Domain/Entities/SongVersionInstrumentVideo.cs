using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SongVersionInstrumentVideo
    {
        [Key]
        public int VideoId { get; set; }
        public required string VideoName { get; set; } = string.Empty;
        public required int VersionId { get; set; }
        public SongVersion Version { get; set; } = null!;
        public required int InstrumentId { get; set; }
        public Instrument Instrument { get; set; } = null!;
        public required int UploadedBy { get; set; }
        public Profile Uploader { get; set; } = null!;
        public required string VideoUrl { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
