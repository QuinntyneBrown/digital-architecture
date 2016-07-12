using System.Data.Entity.Migrations;
using WebActivatorEx;
using static DigitalArchitecture.Helpers.FrontEndPreCacheHelper;
using static DigitalArchitecture.Helpers.FrontEndAppVersionHelper;

[assembly: PostApplicationStartMethod(typeof(DigitalArchitecture.AppActivator), "PostStart")]

namespace DigitalArchitecture
{
    public class AppActivator
    {
        public static void PostStart()
        {
            var dbMigrator = new DbMigrator(new Migrations.Configuration());
            dbMigrator.Update();
            PreCache();
            VersionApp();
        }
    }
}
