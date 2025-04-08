using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BandRole
    {
        [Key]
        public int BandRoleId { get; set; }
        public required string Name { get; set; } = string.Empty;
        public ICollection<UserBand> UsersBand { get; set; } = new List<UserBand>();
    }
}
