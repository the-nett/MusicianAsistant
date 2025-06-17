using System.ComponentModel.DataAnnotations;
namespace Domain.Entities
{
    public class ErrorLogs
    {
        [Key]
        public int IdError { get; set; }
        public required string message { get; set; } = string.Empty;
        public required string stack_trace { get; set; } = string.Empty;
        public required string context_info { get; set; } = string.Empty;
        public required int id_user { get; set; }
        public required DateTime created_at { get; set; } = DateTime.UtcNow;
    }

}
