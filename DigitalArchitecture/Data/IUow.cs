using DigitalArchitecture.Models;

namespace DigitalArchitecture.Data
{
    public interface IUow
    {
        IRepository<App> Apps { get; }
        IRepository<Category> Categories { get; }
        IRepository<Gallery> Galleries { get; }
        IRepository<UI> UIs { get; }
        IRepository<Section> Sections { get; }
        IRepository<Property> Properties { get; }
        IRepository<Article> Articles { get; }
        IRepository<User> Users { get; }
        IRepository<Role> Roles { get; }
        IRepository<Author> Authors { get; }
        IRepository<Photo> Photos { get; }
        IRepository<Performance> Performance { get; }
        IRepository<Tag> Tags { get; }
        void SaveChanges();
    }
}
