using System.Data.Entity.Migrations;
using WebActivatorEx;

[assembly: PostApplicationStartMethod(typeof(DigitalArchitecture.AppActivator), "PostStart")]

namespace DigitalArchitecture
{
    public class AppActivator
    {
        public static void PostStart()
        {
            var dbMigrator = new DbMigrator(new Migrations.Configuration());
            dbMigrator.Update();
        }
    }
}
