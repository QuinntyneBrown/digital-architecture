using System.Collections.Generic;

namespace DigitalArchitecture.Models
{
    public class App
    {
        public int Id { get; set; }
        public ICollection<UI> UIs { get; set; } = new HashSet<UI>();
        public ICollection<Property> Properties { get; set; } = new HashSet<Property>();
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
