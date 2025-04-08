using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BandInvitation
    {
        [Key]
        public int InvitationId { get; set; }
        public required int BandId { get; set; }//------------------------------Pendiente
        //public Band Band { get; set; } = null!;

        public required string Target { get; set; } // Email o número de teléfono
        public required string DeliveryMethod { get; set; }// 'email', 'whatsapp', 'sms'

        // Relación con Status (Estado)
        public required int StatusInvitationId { get; set; }
        public StatusInvitation Status { get; set; } = null!;

        public required int InvitedBy { get; set; }
        public Profile InvitedByProfile { get; set; } = null!;

        public required string Message { get; set; }
        public string? Token { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? AcceptedAt { get; set; }
    }

}
