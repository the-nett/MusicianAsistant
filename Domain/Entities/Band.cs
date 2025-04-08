using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Band
    {
        [Key]
        public int BandId { get; set; }
        public required string Name { get; set; } = string.Empty;
        public required int CreatedBy { get; set; }
        public Profile Creator { get; set; } = null!;
        public required DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<UserBand> UsersBand { get; set; } = new List<UserBand>();
        //public ICollection<BandInvitation> BandInvitations { get; set; } = new List<BandInvitation>();
        public ICollection<SongVersion> Songs { get; set; } = new List<SongVersion>();
    }
}
