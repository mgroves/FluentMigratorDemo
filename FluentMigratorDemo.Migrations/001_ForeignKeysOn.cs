using FluentMigrator;

namespace FluentMigratorDemo.Migrations;

[Migration(1)]
public class ForeignKeysOn : Migration
{
    public override void Up()
    {
        IfDatabase("SQLite")
            .Execute.Sql("PRAGMA foreign_keys = ON;");
    }

    public override void Down()
    {
        IfDatabase("SQLite")
            .Execute.Sql("PRAGMA foreign_keys = OFF;");
    }
}