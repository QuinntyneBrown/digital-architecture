namespace DigitalArchitecture.Dtos
{
    public class PhotoDto
    {
        public PhotoDto(DigitalArchitecture.Models.Photo entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public PhotoDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
