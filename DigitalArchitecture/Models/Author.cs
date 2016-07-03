using System.Collections;
using System.Collections.Generic;

namespace DigitalArchitecture.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool IsDeleted { get; set; }
        public int? PhotoId { get; set; }
        public Photo Photo { get; set; }
        public ICollection<Article> Articles { get; set; } = new HashSet<Article>();
    }
}
