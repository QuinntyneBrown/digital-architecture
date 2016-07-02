namespace DigitalArchitecture.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DigitalArchitecture.Data.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DigitalArchitecture.Data.DataContext context)
        {
            context.Database.Delete();
            context.Database.Create();
        }
    }
}
