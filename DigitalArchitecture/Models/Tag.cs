using System.Collections.Generic;

namespace DigitalArchitecture.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ArticleTag> Articles { get; set; } = new HashSet<ArticleTag>();
        public bool IsDeleted { get; set; }
    }
}
