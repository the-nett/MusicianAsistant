using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class SongVersion
    {
        [Key]
        public int VersionId { get; set; }
        public required string VersionName { get; set; } 
        public required int SongId { get; set; }
        public Song Song { get; set; } = null!;
        public required string Album { get; set; }
        public required string AlbumCoverPath { get; set; }
        public required string Author { get; set; }
        public required string Compas { get; set; }
        public required int Tempo { get; set; }
        public required string Rhythm { get; set; }
        public required int CreatedBy { get; set; }
        public required bool IsShared { get; set; }
        public Profile Creator { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public SongVersionPdf SongVersionn { get; set; } = null!;
        public ICollection<SongVersionInstrumentPdf> SongVersionInstrumentPdfs { get; set; } = null!;
        public ICollection<SongVersionInstrumentVideo> SongVersionInstrumentVideos { get; set; } = new List<SongVersionInstrumentVideo>();
        public ICollection<SongVersionInstrumentText> SongVersionInstrumentTexts { get; set; } = new List<SongVersionInstrumentText>();
        public ICollection<SongVersionAudio> SongVersionAudios { get; set; } = new List<SongVersionAudio>();
    }

}
