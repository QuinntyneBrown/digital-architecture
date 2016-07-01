namespace DigitalArchitecture.Dtos
{
    public class CategoryDto
    {
        public CategoryDto(DigitalArchitecture.Models.Category entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public CategoryDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
