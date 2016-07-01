namespace DigitalArchitecture.Dtos
{
    public class AppDto
    {
        public AppDto(DigitalArchitecture.Models.App entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public AppDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
