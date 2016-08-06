using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalArchitecture.Models
{
    public class ArticleDigitalAsset
    {
        public int Id { get; set; }
        [ForeignKey("Article")]
        public int? ArticleId { get; set; }
        [ForeignKey("Image")]
        public int? DigitalAssetId { get; set; }
        public DigitalAsset DigitalAsset { get; set; }
        public Article Article { get; set; }
    }
}
