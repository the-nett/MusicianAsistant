using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ActionType
    {
        [Key]
        public int ActionTypeId { get; set; }
        public required string Name { get; set; } = string.Empty;
        public required string Description { get; set; } = string.Empty;
    }

}
