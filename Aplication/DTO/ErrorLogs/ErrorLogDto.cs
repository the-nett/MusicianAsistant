namespace Aplication.DTO.ErrorLogs
{
    public class ErrorLogDto
    {
        public int IdError { get; set; }
        public string Message { get; set; } = string.Empty;
        public string StackTrace { get; set; } = string.Empty;
        public string ContextInfo { get; set; } = string.Empty;
        public int IdUser { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
