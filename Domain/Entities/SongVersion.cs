using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public required string Genre { get; set; }
        public required string Compas { get; set; }
        public required string Tempo { get; set; }
        public required string Rhythm { get; set; }
        public int? BandId { get; set; }
        public Band? Band { get; set; }
        public required int CreatedBy { get; set; }
        public Profile Creator { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public SongVersionPdf SongVersionn { get; set; } = null!;
        public SongVersionInstrumentPdf SongVersionInstrumentPdf { get; set; } = null!;
        public ICollection<SongVersionInstrumentVideo> SongVersionInstrumentVideos { get; set; } = new List<SongVersionInstrumentVideo>();

    }

}
