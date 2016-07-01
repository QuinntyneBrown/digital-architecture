namespace DigitalArchitecture.Data
{
    public interface IUow
    {
        IRepository<Models.Article> Articles { get; }
        void SaveChanges();
    }
}
