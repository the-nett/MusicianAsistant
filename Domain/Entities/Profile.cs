using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Profile
    {
        [Key]
        public int Id { get; set; } 

        public required string UserUniqueId { get; set; }

        public Guid? StatusInvitationId { get; set; }  // Cambiado a Guid
        //public StatusInvitation StatusInvitation { get; set; } = null!;  // Asumiendo que tienes esta entidad

        public required string FullName { get; set; }

        public int GenderId { get; set; }  
        public Gender gender { get; set; } = null!;

        public required DateOnly BirthDate { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;

        public ICollection<UserRol> UsersRoles { get; set; } = new List<UserRol>();
        public ICollection<UserBand> UsersBand { get; set; } = new List<UserBand>();
        public ICollection<BandInvitation> BandInvitations { get; set; } = new List<BandInvitation>();
        public ICollection<Band> Bands { get; set; } = new List<Band>();
        public virtual ICollection<UserInstrument> UserInstruments { get; set; } = new List<UserInstrument>();
        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
        public virtual ICollection<SongVersion> SongVersions { get; set; } = new List<SongVersion>();
        public virtual ICollection<SongVersionPdf> SongVersionPdfs { get; set; } = new List<SongVersionPdf>();
        public virtual ICollection<SongVersionInstrumentPdf> SongVersionInstrumentPdfs { get; set; } = new List<SongVersionInstrumentPdf>();
        public virtual ICollection<SongVersionInstrumentVideo> SongVersionInstrumentVideos { get; set; } = new List<SongVersionInstrumentVideo>();
    }
}
