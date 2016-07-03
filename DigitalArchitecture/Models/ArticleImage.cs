using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalArchitecture.Models
{
    public class ArticleImage
    {
        public int Id { get; set; }
        [ForeignKey("Article")]
        public int? ArticleId { get; set; }
        [ForeignKey("Image")]
        public int? ImageId { get; set; }
        public Image Image { get; set; }
        public Article Article { get; set; }
    }
}
