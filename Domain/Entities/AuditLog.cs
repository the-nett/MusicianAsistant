using System.ComponentModel.DataAnnotations;
namespace Domain.Entities
{
    public class AuditLog
    {
        [Key]
        public int AuditId { get; set; }
        public int UserId { get; set; }
        public required int ActionTypeId { get; set; }
        public required ActionType ActionType { get; set; } = null!;
        public string EntityType { get; set; } = string.Empty;
        public int? EntityId { get; set; }
        public string? Description { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        //public Profile? User { get; set; }
        
    }

}
