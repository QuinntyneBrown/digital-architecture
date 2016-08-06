using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalArchitecture.Models
{
    public class Article
    {
        public int Id { get; set; }
        [ForeignKey("Author")]
        public int? AuthorId { get; set; }
        public string Name { get; set; }
        public string Excerpt { get; set; }
        public string ArticleBody { get; set; }
        public string Headline { get; set; }
        public string AlternativeHeadline { get; set; }
        public string Url { get; set; }
        public ICollection<ArticleDigitalAsset> Images { get; set; } = new HashSet<ArticleDigitalAsset>();
        public ICollection<ArticleTag> Tags { get; set; } = new HashSet<ArticleTag>();
        public ICollection<ArticleCategory> Categories { get; set; } = new HashSet<ArticleCategory>();
        public Author Author { get; set; }
        public DateTime? DatePublished { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}
