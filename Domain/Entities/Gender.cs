using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Gender
    {
        [Key]
        public int IdGender { get; set; }
        public required string GenderName { get; set; } = string.Empty;
        public ICollection<Profile> Profiles { get; set; } = new List<Profile>();

    }
}
