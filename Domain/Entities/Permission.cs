using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<RolePermission> RolesPermissions { get; set; } = new List<RolePermission>();
    }

}
