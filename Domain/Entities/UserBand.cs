using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserBand
    {
        [Key]
        public int UserBandId { get; set; }
        public required int UserId { get; set; }
        public Profile User { get; set; } = null!;

        public required int BandId { get; set; }
        public Band Band { get; set; } = null!;

        public required int BandRoleId { get; set; } 
        public BandRole BandRole { get; set; } = null!;
    }
}
