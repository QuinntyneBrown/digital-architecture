using System.Collections.Generic;

namespace DigitalArchitecture.Models
{
    public class Gallery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<GalleryDigitalAsset> GalleryDigitalAssets { get; set; } = new HashSet<GalleryDigitalAsset>();
    }
}
