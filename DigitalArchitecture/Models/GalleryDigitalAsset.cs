namespace DigitalArchitecture.Models
{
    public class GalleryDigitalAsset
    {
        public int Id { get; set; }
        public int GalleryId { get; set; }
        public int DigitalAssetId { get; set; }
        public Gallery Gallery { get; set; }
        public DigitalAsset DigitalAsset { get; set; }
    }
}
