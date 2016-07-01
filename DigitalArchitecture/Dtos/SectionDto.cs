namespace DigitalArchitecture.Dtos
{
    public class SectionDto
    {
        public SectionDto(DigitalArchitecture.Models.Section entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public SectionDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
