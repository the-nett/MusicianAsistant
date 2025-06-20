using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Instrument
    {
        [Key]
        public int InstrumentId { get; set; }
        public string NameInstrument { get; set; } = string.Empty;

        public ICollection<UserInstrument> UserInstruments { get; set; } = new List<UserInstrument>();
        public ICollection<SongVersionInstrumentPdf> SongVersionInstrumentPdfs { get; set; } = null!;
        public ICollection<SongVersionInstrumentVideo> SongVersionInstrumentVideos { get; set; } = null!;
        public ICollection<SongVersionInstrumentText> SongVersionInstrumentTexts { get; set; } = new List<SongVersionInstrumentText>();

    }
}
