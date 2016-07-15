using System.Data.Entity.Migrations;
using WebActivatorEx;
using static DigitalArchitecture.Helpers.FrontEndPreCacheHelper;
using static DigitalArchitecture.Helpers.FrontEndAppVersionHelper;
using static DigitalArchitecture.Helpers.LocalStorageHelper;

[assembly: PostApplicationStartMethod(typeof(DigitalArchitecture.AppActivator), "PostStart")]

namespace DigitalArchitecture
{
    public class AppActivator
    {
        public static void PostStart()
        {
            var dbMigrator = new DbMigrator(new Migrations.Configuration());
            dbMigrator.Update();

#if DEBUG
            SetLocalStorageKey();
            PreCache();
            VersionApp();            
#endif
        }
    }
}
