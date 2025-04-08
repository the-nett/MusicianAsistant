using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StatusInvitation
    {
        [Key]
        public int StatusId { get; set; }
        public  required string Name { get; set; } = null!;
        public required string Description { get; set; } = string.Empty;

        // Navegación inversa: Invitaciones que tienen este estado
        public ICollection<BandInvitation> BandInvitations { get; set; } = new List<BandInvitation>();
    }

}
