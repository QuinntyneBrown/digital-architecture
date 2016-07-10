using System.ServiceModel.Syndication;

namespace DigitalArchitecture.Services
{
    public interface IRssFeedService
    {
        SyndicationFeed Get();
    }
}
