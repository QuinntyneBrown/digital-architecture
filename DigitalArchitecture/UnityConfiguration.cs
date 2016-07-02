using DigitalArchitecture.Configuration;
using DigitalArchitecture.Data;
using DigitalArchitecture.Services;
using DigitalArchitecture.Utilities;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace DigitalArchitecture
{
    public class UnityConfiguration
    {
        public static IUnityContainer GetContainer()
        {
            var container = new UnityContainer().AddNewExtension<Interception>();
            container.RegisterType<IDbContext, DataContext>();
            container.RegisterType<IUow, Uow>();
            container.RegisterType<IRepositoryProvider, RepositoryProvider>();
            container.RegisterType<IIdentityService, IdentityService>();
            container.RegisterType<ILoggerFactory, LoggerFactory>();
            container.RegisterType<ICacheProvider, CacheProvider>();
            container.RegisterType<IEncryptionService, EncryptionService>();
            container.RegisterType<ILogger, Logger>();

            container.RegisterType<IAppService, AppService>();
            container.RegisterType<IArticleService, ArticleService>();
            container.RegisterType<IAuthorService, AuthorService>();
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<IGalleryService, GalleryService>();
            container.RegisterType<IPhotoService, PhotoService>();
            container.RegisterType<IPropertyService, PropertyService>();
            container.RegisterType<IRoleService, RoleService>();
            container.RegisterType<ISectionService, SectionService>();
            container.RegisterType<IUIService, UIService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IPerformanceService, PerformanceService>();
            container.RegisterType<ILogger, SeriLogger>();
            container.RegisterInstance(TraceConfiguration.LazyConfig);
            container.RegisterInstance(AuthConfiguration.LazyConfig);
                      
            return container;
        }
    }
}
