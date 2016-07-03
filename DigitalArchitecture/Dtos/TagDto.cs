namespace DigitalArchitecture.Dtos
{
    public class TagDto
    {
        public TagDto(DigitalArchitecture.Models.Tag entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public TagDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
