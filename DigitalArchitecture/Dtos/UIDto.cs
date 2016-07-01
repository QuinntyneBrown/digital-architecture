namespace DigitalArchitecture.Dtos
{
    public class UIDto
    {
        public UIDto(DigitalArchitecture.Models.UI entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public UIDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
