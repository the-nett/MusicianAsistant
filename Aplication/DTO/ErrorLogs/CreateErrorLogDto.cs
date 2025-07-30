namespace Aplication.DTO.ErrorLogs
{
    public class CreateErrorLogDto
    {
        
        public required string Message { get; set; }
        public required string StackTrace { get; set; }
        public required string ContextInfo { get; set; }
        public required int IdUser { get; set; }

    }
}
