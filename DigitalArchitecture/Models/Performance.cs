using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalArchitecture.Models
{
    [Table("Performance")]
    public class Performance
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string Message { get; set; }
        public string MessageTemplate { get; set; }
        public string Level { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        [Column(TypeName="datetime2")]
        public DateTime? StartedTime { get; set; }
        public string Exception { get; set; }
        [Column(TypeName = "xml")]
        public string Properties { get; set; }
        public string LogEvent { get; set; }
        public string HttpRequestId { get; set; }
        public string UserName { get; set; }
        public string OperationName { get; set; }
        public string OperationResult { get; set; }
        public int TimeTakenMsec { get; set; }        
    }
}
