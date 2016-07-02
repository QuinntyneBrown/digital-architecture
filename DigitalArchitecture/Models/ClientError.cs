namespace DigitalArchitecture.Models
{
    public class ClientError
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public string Message { get; set; }        
        public string StackTrace { get; set; }
    }
}
