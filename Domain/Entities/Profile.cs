using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Profile
    {
        [Key]
        public int Id { get; set; } 
        public required string Role { get; set; } = string.Empty;

        public required string UserUniqueId { get; set; }

        public required string FullName { get; set; }

        public int GenderId { get; set; }  
        public Gender gender { get; set; } = null!;

        public required DateOnly BirthDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
        public virtual ICollection<UserInstrument> UserInstruments { get; set; } = new List<UserInstrument>();
        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
        public virtual ICollection<SongVersion> SongVersions { get; set; } = new List<SongVersion>();
        public virtual ICollection<SongVersionPdf> SongVersionPdfs { get; set; } = new List<SongVersionPdf>();
        public virtual ICollection<SongVersionInstrumentPdf> SongVersionInstrumentPdfs { get; set; } = new List<SongVersionInstrumentPdf>();
        public virtual ICollection<SongVersionInstrumentVideo> SongVersionInstrumentVideos { get; set; } = new List<SongVersionInstrumentVideo>();
    }
}
