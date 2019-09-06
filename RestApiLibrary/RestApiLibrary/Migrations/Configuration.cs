namespace RestApiLibrary.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RestApiLibrary.Models.DbLibrary>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            // fails with cannot assign MySqlMigrationSqlGenerator toSystem.Data.Entity.Migrations.Sql.MigrationSqlGenerator
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());

            // fails with cannot assign MySqlMigrationCodeGenerator to System.Data.Entity.Migrations.Design.MigrationCodeGenerator
            CodeGenerator = new MySql.Data.Entity.MySqlMigrationCodeGenerator();
        }

        protected override void Seed(RestApiLibrary.Models.DbLibrary context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
